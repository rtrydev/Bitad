using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BitadAPI.Dto;
using BitadAPI.Models;
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
            if (!ModelState.IsValid) return BadRequest();
            var ip = _accessor.HttpContext.Connection.RemoteIpAddress.ToString();
            var result = await _userService.RegisterUser(registrationData, ip);
            if (result is null) return Forbid();

            return Ok(result);
        }

        [HttpPost("AuthenticateUser")]
        public async Task<ActionResult<DtoUser>> AuthenticateUser([FromBody] DtoUserLogin userLogin)
        {
            var result = await _userService.AuthenticateUser(userLogin);
            if (result is null) return NotFound();
            if (result.Code == 2) return Forbid();
            
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

        [HttpPut("SelectWorkshop")]
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

        [HttpPut("CheckAttendance")]
        [Authorize]
        public async Task<ActionResult<DtoAttendanceResult>> CheckAttendance(string attendanceCode)
        {
            var id = Int32.Parse(User.Claims.First(p => p.Type == "id").Value);
            var presentedToken = HttpContext.Request.Headers.FirstOrDefault(x => x.Key == "Authorization").Value;
            if (await _jwtService.CheckAuthorization(id, presentedToken) is UnauthorizedResult)
            {
                return Unauthorized();
            }

            var result = await _userService.CheckAttendance(id, attendanceCode);
            HttpContext.Response.Headers.Add("AuthToken", result.Token);
            return Ok(result.Body);

        }

        [HttpPut("ActivateAccount")]
        public async Task<ActionResult<DtoUser>> ActivateAccount(string activationCode)
        {
            var result = await _userService.ActivateAccount(activationCode);
            if (result is null) return Forbid();
            return result;
        }

        [HttpGet("Winners")]
        [Authorize]
        public async Task<ActionResult<ICollection<DtoUser>>> GetWinners(int numberOfWinners)
        {
            var id = Int32.Parse(User.Claims.First(p => p.Type == "id").Value);
            var presentedToken = HttpContext.Request.Headers.FirstOrDefault(x => x.Key == "Authorization").Value;
            if (await _jwtService.CheckAuthorization(id, presentedToken) is UnauthorizedResult)
            {
                return Unauthorized();
            }

            var userRole = (await _userService.GetUserById(id)).Body.Role;
            if (userRole != UserRole.Super)
            {
                return Forbid();
            }
            var result = await _userService.GetWinners(id, numberOfWinners);
            HttpContext.Response.Headers.Add("AuthToken", result.Token);
            return Ok(result.Body);
        }

    }
}
