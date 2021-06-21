using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BitadAPI.Dto;
using BitadAPI.Models;
using BitadAPI.Repositories;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.IdentityModel.Tokens;

namespace BitadAPI.Services
{
    public interface IUserService
    {
        public Task<TokenRefreshResponse<DtoUser>> AuthenticateUser(DtoUserLogin userLogin);
        public Task<TokenRefreshResponse<DtoUser>> GetUserById(int id);
        public Task<TokenRefreshResponse<ICollection<DtoLeader>>> GetLeaders(int userid);
        public Task<DtoRegistrationResponse> RegisterUser(DtoRegistration registrationData);
        public Task<TokenRefreshResponse<DtoWorkshop>> SelectWorkshop(int userId, string workshopCode);

    }

    public class UserService : IUserService
    {
        private IUserRepository _userRepository;
        private IWorkshopRepository _workshopRepository;
        private IMapper _mapper;
        private IJwtService _jwtService;

        public UserService(IUserRepository userRepository, IWorkshopRepository workshopRepository, IMapper mapper, IJwtService jwtService)
        {
            _userRepository = userRepository;
            _workshopRepository = workshopRepository;
            _mapper = mapper;
            _jwtService = jwtService;
        }

        public async Task<TokenRefreshResponse<DtoUser>> AuthenticateUser(DtoUserLogin userLogin)
        {
            var user = await _userRepository.GetByPredicate(x => x.Username == userLogin.Username);
            if (user is null) return null;

            var hashedPassword = HashPassword(userLogin.Password, user.PasswordSalt);

            if (user.Password != hashedPassword) return null;

            var dtoUser = _mapper.Map<DtoUser>(user);
            return new TokenRefreshResponse<DtoUser>
            {
                Token = await _jwtService.GetNewToken(user.Id),
                Body = dtoUser
            };
            
        }

        public async Task<TokenRefreshResponse<ICollection<DtoLeader>>> GetLeaders(int userId)
        {
            var leaders = new List<DtoLeader>(20);
            var topUsers = await _userRepository.GetTopUsers(20);
            var position = 1;
            foreach(var user in topUsers)
            {
                leaders.Add(new DtoLeader
                {
                    Email = user.Email,
                    Points = user.CurrentScore,
                    Position = position++
                });
            }
            return new TokenRefreshResponse<ICollection<DtoLeader>>
            {
                Token = await _jwtService.GetNewToken(userId),
                Body = leaders
            };
        }

        public async Task<TokenRefreshResponse<DtoUser>> GetUserById(int id)
        {
            var user = await _userRepository.GetById(id);
            var dtoUser = _mapper.Map<DtoUser>(user);
            return new TokenRefreshResponse<DtoUser>
            {
                Body = dtoUser,
                Token = await _jwtService.GetNewToken(id)
            };
        }

        

        public async Task<DtoRegistrationResponse> RegisterUser(DtoRegistration registrationData)
        {
            if (await _userRepository.GetByPredicate(x => x.Email == registrationData.Email || x.Username == registrationData.Username) is not null)
                return null;

            var hashed = HashPassword(registrationData.Password);

            var user = new User
            {
                FirstName = registrationData.FirstName,
                LastName = registrationData.LastName,
                Username = registrationData.Username,
                Email = registrationData.Email,
                CurrentScore = 0,
                Password = hashed.password,
                PasswordSalt = hashed.salt,
                Workshop = await _workshopRepository.GetByCode(registrationData.WorkshopCode)
            };


            var resultUser = await _userRepository.CreateUser(user);

            if (resultUser is null) return null;
            if (resultUser.Workshop is not null)
            {
                resultUser.Workshop = await _workshopRepository.AddParticipant(resultUser.Workshop.Id, resultUser);
            }

            return new DtoRegistrationResponse
            {
                Username = registrationData.Username,
                FirstName = registrationData.FirstName,
                LastName = registrationData.LastName,
                Email = registrationData.Email,
                Workshop = _mapper.Map<DtoWorkshop>(resultUser.Workshop)
            };
        }

        public async Task<TokenRefreshResponse<DtoWorkshop>> SelectWorkshop(int userId, string workshopCode)
        {
            var workshop = await _workshopRepository.GetByCode(workshopCode);
            var refreshToken = await _jwtService.GetNewToken(userId);

            if (workshop.ParticipantsNumber >= workshop.MaxParticipants)
            {
                return new TokenRefreshResponse<DtoWorkshop>
                {
                    Body = null,
                    Token = refreshToken
                };
            }

            var user = await _userRepository.GetById(userId);

            if(user.Workshop is not null)
                return new TokenRefreshResponse<DtoWorkshop>
                {
                    Body = null,
                    Token = refreshToken
                };

            user.Workshop = workshop;
            var result = await _userRepository.UpdateUser(user);
            return new TokenRefreshResponse<DtoWorkshop>
            {
                Body = _mapper.Map<DtoWorkshop>(workshop),
                Token = refreshToken
            };
        }

        private string GenerateLoginCode()
        {
            var rnd = new Random();
            var codeBuilder = new StringBuilder();
            for(int i=0; i < 4; i++)
            {
                codeBuilder.Append((char)rnd.Next('A', 'Z'));
            }
            return codeBuilder.ToString();
        }

        private (string password, string salt) HashPassword(string password)
        {
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            var stringSalt = Convert.ToBase64String(salt);

            // derive a 256-bit subkey (use HMACSHA1 with 10,000 iterations)
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

            return (hashed, stringSalt);
        }

        private string HashPassword(string password, string salt)
        {
            byte[] saltBytes = Convert.FromBase64String(salt);

            // derive a 256-bit subkey (use HMACSHA1 with 10,000 iterations)
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: saltBytes,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

            return hashed;
        }
    }
}
