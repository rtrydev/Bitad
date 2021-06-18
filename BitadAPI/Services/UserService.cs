using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BitadAPI.Dto;
using BitadAPI.Models;
using BitadAPI.Repositories;
using Microsoft.IdentityModel.Tokens;

namespace BitadAPI.Services
{
    public interface IUserService
    {
        public Task<DtoUserLogon> AuthenticateUser(string userEmail, string userCode);
        public Task<DtoUser> GetUserById(int id);
        public Task<ICollection<DtoLeader>> GetLeaders();
        public Task<DtoRegistrationResponse> RegisterUser(DtoRegistration registrationData);
    }

    public class UserService : IUserService
    {
        private IUserRepository _userRepository;
        private IWorkshopRepository _workshopRepository;
        private IMapper _mapper;

        public UserService(IUserRepository userRepository, IWorkshopRepository workshopRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _workshopRepository = workshopRepository;
            _mapper = mapper;
        }

        public async Task<DtoUserLogon> AuthenticateUser(string userEmail, string userCode)
        {
            var user = await _userRepository.GetByPredicate(x => x.Email == userEmail && x.Code == userCode);
            var dtoUser = _mapper.Map<DtoUser>(user);
            return new DtoUserLogon
            {
                Token = GenerateJwtToken(user),
                User = dtoUser
            };
        }

        public async Task<ICollection<DtoLeader>> GetLeaders()
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
            return leaders;
        }

        public async Task<DtoUser> GetUserById(int id)
        {
            var user = await _userRepository.GetById(id);
            return _mapper.Map<DtoUser>(user);
        }

        public async Task<DtoRegistrationResponse> RegisterUser(DtoRegistration registrationData)
        {
            if (await _userRepository.GetByPredicate(x => x.Email == registrationData.Email) is not null)
                return null;

            var user = new User
            {
                Name = registrationData.FirstName + " " + registrationData.LastName,
                Email = registrationData.Email,
                CurrentScore = 0,
                Code = GenerateLoginCode(),
                Workshop = await _workshopRepository.GetByCode(registrationData.WorkshopCode)
            };

            var result = await _userRepository.CreateUser(user);

            if (result is null) return null;
            if (result.Workshop is not null)
            {
                result.Workshop = await _workshopRepository.IncrementParticipantCount(result.Workshop.Id);
            }

            return new DtoRegistrationResponse
            {
                FirstName = registrationData.FirstName,
                LastName = registrationData.LastName,
                Email = registrationData.Email,
                LoginCode = result.Code,
                Workshop = _mapper.Map<DtoWorkshop>(result.Workshop)
            };
        }

        private string GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("secretstringverysecure");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
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
    }
}
