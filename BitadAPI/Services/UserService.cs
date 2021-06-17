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
    }

    public class UserService : IUserService
    {
        private IUserRepository userRepository;
        private IMapper _mapper;

        public UserService(IUserRepository repository, IMapper mapper)
        {
            userRepository = repository;
            _mapper = mapper;
        }

        public async Task<DtoUserLogon> AuthenticateUser(string userEmail, string userCode)
        {
            var user = await userRepository.GetByPredicate(x => x.Email == userEmail && x.Code == userCode);
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
            var topUsers = await userRepository.GetTopUsers(20);
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
            var user = await userRepository.GetById(id);
            return _mapper.Map<DtoUser>(user);
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
    }
}
