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
    public class UserController : AuthorizedController
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
            var result = await MakeAuthorizedServiceCall(_userService.GetUserById, _jwtService);
            return result;
        }

        [Authorize]
        [HttpGet("GetLeaderboard")]
        public async Task<ActionResult<ICollection<DtoLeader>>> GetLeaderboard()
        {
            var result = await MakeAuthorizedServiceCall(_userService.GetLeaders, _jwtService);
            return result;
        }

        [HttpPut("ActivateAccount")]
        public async Task<ActionResult<DtoUser>> ActivateAccount(string activationCode)
        {
            var result = await _userService.ActivateAccount(activationCode);
            if (result is null) return Forbid();
            return result;
        }

        [HttpPut("IssuePasswordReset")]
        public async Task<ActionResult> IssuePasswordReset(string email)
        {
            var result = await _userService.IssuePasswordReset(email);
            if (result is not null) return Ok();
            return Forbid();
        }

        [HttpPatch("ResetPassword")]
        public async Task<ActionResult> ResetPassword(string code, string password)
        {
            var result = await _userService.ResetPassword(code, password);
            if (result is not null) return Ok();
            return Forbid();
        }

        [HttpPut("RequestActivationResend")]
        public async Task<ActionResult> RequestActivationResend(string email)
        {
            var result = await _userService.ResendActivation(email);
            if (result is not null) return Ok();
            return Forbid();

        }

        [HttpPut("ConfirmAccount")]
        public async Task<ActionResult> ConfirmAccount(string confirmCode)
        {
            var result = await _userService.ConfirmAccount(confirmCode);
            if (result is null) return Forbid();
            return Ok();
        }

    }
}
