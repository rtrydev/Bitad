using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BitadAPI.Models;
using BitadAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace BitadAPI.Services
{
    public interface IJwtService
    {
        public Task<ActionResult> CheckAuthorization(int userId, string presentedToken);
        public Task<string> GetNewToken(int userId);
    }

    public class JwtService : IJwtService
    {
        private IUserRepository _userRepository;

        public JwtService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ActionResult> CheckAuthorization(int userId, string presentedToken)
        {
            var actualToken = await GetUsersCurrentToken(userId);

            if (actualToken is null) return new UnauthorizedResult();

            if (!presentedToken.Equals("Bearer " + actualToken))
            {
                return new UnauthorizedResult();
            }

            return null;
        }

        public async Task<string> GetNewToken(int userId)
        {
            var user = await _userRepository.GetById(userId);
            var newToken = GenerateJwtToken(user);
            user.CurrentJwt = newToken;
            var result = await _userRepository.UpdateUser(user);
            return result.CurrentJwt;
        }

        private async Task<string> GetUsersCurrentToken(int id)
        {
            var user = await _userRepository.GetById(id);
            return user.CurrentJwt;
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
