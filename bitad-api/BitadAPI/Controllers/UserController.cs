using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BitadAPI.Dto;
using BitadAPI.Repositories;
using BitadAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BitadAPI.Controllers
{
    [Route("[controller]")]
    public class UserController : Controller
    {
        private IUserService _userService;
        private IJwtService _jwtService;
        private IHttpContextAccessor _accessor;

        public UserController(IUserService userService, IJwtService jwtService, IHttpContextAccessor accessor)
        {
            _userService = userService;
            _jwtService = jwtService;
            _accessor = accessor;
        }

        [HttpPost("RegisterUser")]
        public async Task<ActionResult<DtoRegistrationResponse>> RegisterUser([FromBody] DtoRegistration registrationData)
        {
            var ip = _accessor.HttpContext.Connection.RemoteIpAddress.ToString();
            var result = await _userService.RegisterUser(registrationData, ip);
            if (result is null) return Forbid();

            return Ok(result);
        }

        [HttpPost("AuthenticateUser")]
        public async Task<ActionResult<DtoUser>> AuthenticateUser([FromBody] DtoUserLogin userLogin)
        {
            var result = await _userService.AuthenticateUser(userLogin);
            if (result is null) return Forbid();
            HttpContext.Response.Headers.Add("AuthToken", result.Token);

            return Ok(result.Body);
        }

        [Authorize]
        [HttpGet("GetUser")]
        public async Task<ActionResult<DtoUser>> GetUser()
        {
            var id = Int32.Parse(User.Claims.First(p => p.Type == "id").Value);
            var presentedToken = HttpContext.Request.Headers.FirstOrDefault(x => x.Key == "Authorization").Value;
            if(await _jwtService.CheckAuthorization(id, presentedToken) is UnauthorizedResult)
            {
                return Unauthorized();
            }
            
            var result = await _userService.GetUserById(id);
            HttpContext.Response.Headers.Add("AuthToken", result.Token);
            return Ok(result.Body);
        }

        [Authorize]
        [HttpGet("GetLeaderboard")]
        public async Task<ActionResult<ICollection<DtoLeader>>> GetLeaderboard()
        {
            var id = Int32.Parse(User.Claims.First(p => p.Type == "id").Value);
            var presentedToken = HttpContext.Request.Headers.FirstOrDefault(x => x.Key == "Authorization").Value;
            if (await _jwtService.CheckAuthorization(id, presentedToken) is UnauthorizedResult)
            {
                return Unauthorized();
            }
            var result = await _userService.GetLeaders(id);
            HttpContext.Response.Headers.Add("AuthToken", result.Token);

            return Ok(result.Body);
        }

        [HttpPost("SelectWorkshop")]
        [Authorize]
        public async Task<ActionResult<DtoWorkshop>> SelectWorkshop(string workshopCode)
        {
            var id = Int32.Parse(User.Claims.First(p => p.Type == "id").Value);
            var presentedToken = HttpContext.Request.Headers.FirstOrDefault(x => x.Key == "Authorization").Value;
            if (await _jwtService.CheckAuthorization(id, presentedToken) is UnauthorizedResult)
            {
                return Unauthorized();
            }

            var result = await _userService.SelectWorkshop(id, workshopCode);
            HttpContext.Response.Headers.Add("AuthToken", result.Token);

            if (result.Body is null) return Forbid();
            return Ok(result.Body);
        }
    }
}
