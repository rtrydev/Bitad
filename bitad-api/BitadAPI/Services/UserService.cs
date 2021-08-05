using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BitadAPI.Dto;
using BitadAPI.Models;
using BitadAPI.Repositories;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace BitadAPI.Services
{
    public interface IUserService
    {
        public Task<TokenRefreshResponse<DtoUser>> AuthenticateUser(DtoUserLogin userLogin);
        public Task<TokenRefreshResponse<DtoUser>> GetUserById(int id);
        public Task<TokenRefreshResponse<ICollection<DtoLeader>>> GetLeaders(int userid);
        public Task<DtoRegistrationResponse> RegisterUser(DtoRegistration registrationData, string ip);
        public Task<TokenRefreshResponse<DtoWorkshop>> SelectWorkshop(int userId, string workshopCode);
        public Task<TokenRefreshResponse<DtoUser>> CheckAttendance(int issuerId, string attendanceCode);
        public Task<DtoUser> ActivateAccount(string activationCode);

    }

    public class UserService : IUserService
    {
        private IUserRepository _userRepository;
        private IWorkshopRepository _workshopRepository;
        private IMapper _mapper;
        private IJwtService _jwtService;
        private IMailService _mailService;

        public UserService(IUserRepository userRepository, IWorkshopRepository workshopRepository, IMapper mapper, IJwtService jwtService, IMailService mailService)
        {
            _userRepository = userRepository;
            _workshopRepository = workshopRepository;
            _mapper = mapper;
            _jwtService = jwtService;
            _mailService = mailService;
        }

        public async Task<TokenRefreshResponse<DtoUser>> AuthenticateUser(DtoUserLogin userLogin)
        {
            var user = await _userRepository.GetByPredicate(x => x.Username == userLogin.Username);
            if (user is null) return null;

            var hashedPassword = HashPassword(userLogin.Password, user.PasswordSalt);

            if (user.Password != hashedPassword) return null;

            if (user.ActivationDate is null)
            {
                return new TokenRefreshResponse<DtoUser>
                {
                    Token = null,
                    Body = null,
                    Code = 2
                };
            }

            var dtoUser = _mapper.Map<DtoUser>(user);
            return new TokenRefreshResponse<DtoUser>
            {
                Token = await _jwtService.GetNewToken(user.Id),
                Body = dtoUser,
                Code = 0
            };

        }

        public async Task<TokenRefreshResponse<ICollection<DtoLeader>>> GetLeaders(int userId)
        {
            var leaders = new List<DtoLeader>(20);
            var topUsers = await _userRepository.GetTopUsers(20);
            var position = 1;
            foreach (var user in topUsers)
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
                Body = leaders,
                Code = 0
            };
        }

        public async Task<TokenRefreshResponse<DtoUser>> GetUserById(int id)
        {
            var user = await _userRepository.GetById(id);
            var dtoUser = _mapper.Map<DtoUser>(user);
            return new TokenRefreshResponse<DtoUser>
            {
                Body = dtoUser,
                Token = await _jwtService.GetNewToken(id),
                Code = 0
            };
        }



        public async Task<DtoRegistrationResponse> RegisterUser(DtoRegistration registrationData, string ip)
        {
            var registered = await _userRepository.GetManyByPredicate(x => x.CreationIp == ip);
            if (registered.Count > 3)
                return null;

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
                Workshop = await _workshopRepository.GetByCode(registrationData.WorkshopCode),
                CreationIp = ip,
                ActivationCode = GenerateRandomCode(),
                ConfirmCode = GenerateRandomCode(),
                AttendanceCode = GenerateRandomCode(),
                Role = UserRole.Guest
                
            };


            var resultUser = await _userRepository.CreateUser(user);

            if (resultUser is null) return null;
            if (resultUser.Workshop is not null)
            {
                resultUser.Workshop = await _workshopRepository.AddParticipant(resultUser.Workshop.Id, resultUser);
            }
            //wysylanie emaili aktywacyjnych - na razie wylaczone
            //_ = Task.Run(async () => await _mailService.SendActivationMail(user.Email, user.ActivationCode, user.Username));

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

            if (workshop is null || workshop.ParticipantsNumber >= workshop.MaxParticipants)
            {
                return new TokenRefreshResponse<DtoWorkshop>
                {
                    Body = null,
                    Token = refreshToken,
                    Code = 403
                };
            }

            var user = await _userRepository.GetById(userId);

            if(user.Workshop is not null)
                return new TokenRefreshResponse<DtoWorkshop>
                {
                    Body = null,
                    Token = refreshToken,
                    Code = 1
                };

            user.Workshop = workshop;
            var result = await _userRepository.UpdateUser(user);
            return new TokenRefreshResponse<DtoWorkshop>
            {
                Body = _mapper.Map<DtoWorkshop>(workshop),
                Token = refreshToken,
                Code = 0
            };
        }

        public async Task<TokenRefreshResponse<DtoUser>> CheckAttendance(int issuerId, string attendanceCode)
        {
            var issuer = await _userRepository.GetById(issuerId);
            var refreshToken = await _jwtService.GetNewToken(issuerId);
            if (issuer.Role != UserRole.Admin)
            {
                return new TokenRefreshResponse<DtoUser>
                {
                    Body = null,
                    Token = refreshToken,
                    Code = 403
                };
            }
                
            var user = await _userRepository.GetByPredicate(x => x.AttendanceCode == attendanceCode);
            if (user is null)
            {
                return new TokenRefreshResponse<DtoUser>
                {
                    Body = null,
                    Token = refreshToken,
                    Code = 404
                };
            }

            if (user.ActivationDate is null)
            {
                return new TokenRefreshResponse<DtoUser>
                {
                    Body = null,
                    Token = refreshToken,
                    Code = 2
                };
            }
            
            if (user.AttendanceCheckDate is not null)
            {
                return new TokenRefreshResponse<DtoUser>
                {
                    Body = null,
                    Token = refreshToken,
                    Code = 1
                };
            }
            
            user.AttendanceCheckDate = DateTime.Now;
            var result = await _userRepository.UpdateUser(user);
            return new TokenRefreshResponse<DtoUser>
            {
                Body = _mapper.Map<DtoUser>(result),
                Token = refreshToken,
                Code = 0
            }; 

        }

        public async Task<DtoUser> ActivateAccount(string activationCode)
        {
            var user = await _userRepository.GetByPredicate(x => x.ActivationCode == activationCode);
            if (user is null) return null;
            if (user.ActivationDate is not null) return null;
            user.ActivationDate = DateTime.Now;
            var result = await _userRepository.UpdateUser(user);
            return _mapper.Map<DtoUser>(result);
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

        private string GenerateRandomCode()
        {
            Guid g = Guid.NewGuid();
            string stringCode = Convert.ToBase64String(g.ToByteArray());
            return stringCode.Replace("=", "").
                Replace("/", "").
                Replace("+", "");
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
