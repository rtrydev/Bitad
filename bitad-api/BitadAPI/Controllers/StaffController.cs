using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BitadAPI.Dto;
using BitadAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Crypto.Prng;

namespace BitadAPI.Controllers
{
    [Route("[controller]")]
    public class StaffController : Controller
    {
        private IStaffService staffService;
        private IJwtService _jwtService;

        public StaffController(IStaffService service, IJwtService jwtService)
        {
            staffService = service;
            _jwtService = jwtService;
        }

        [HttpGet("GetStaff")]
        public async Task<ActionResult<ICollection<DtoStaff>>> GetStaff()
        {
            return Ok(await staffService.GetAll());
        }

        [HttpGet("GetStaffAdmin")]
        [Authorize]
        public async Task<ActionResult<ICollection<DtoStaff>>> GetStaffAdmin()
        {
            var id = Int32.Parse(User.Claims.First(p => p.Type == "id").Value);
            var presentedToken = HttpContext.Request.Headers.FirstOrDefault(x => x.Key == "Authorization").Value;
            if (await _jwtService.CheckAuthorization(id, presentedToken) is UnauthorizedResult)
            {
                return Unauthorized();
            }
            var result = await staffService.GetAllAdmin(id);
            HttpContext.Response.Headers.Add("AuthToken", result.Token);
            if (result.Code == 403) return Forbid();
            return Ok(result.Body);
        }

        [HttpPost("SendConfirmationMails")]
        [Authorize]
        public async Task<ActionResult> SendConfirmationMails()
        {
            var id = Int32.Parse(User.Claims.First(p => p.Type == "id").Value);
            var presentedToken = HttpContext.Request.Headers.FirstOrDefault(x => x.Key == "Authorization").Value;
            if (await _jwtService.CheckAuthorization(id, presentedToken) is UnauthorizedResult)
            {
                return Unauthorized();
            }
            var result = await staffService.SendConfirmationMails(id);
            HttpContext.Response.Headers.Add("AuthToken", result.Token);
            if (result.Code == 403) return Forbid();
            return Ok();
        }

        [HttpPost("ExcludeInactiveUsersFromWorkshops")]
        [Authorize]
        public async Task<ActionResult> ExcludeInactiveUsersFromWorkshops()
        {
            var id = Int32.Parse(User.Claims.First(p => p.Type == "id").Value);
            var presentedToken = HttpContext.Request.Headers.FirstOrDefault(x => x.Key == "Authorization").Value;
            if (await _jwtService.CheckAuthorization(id, presentedToken) is UnauthorizedResult)
            {
                return Unauthorized();
            }
            var result = await staffService.ExcludeInactiveUsersFromWorkshops(id);
            HttpContext.Response.Headers.Add("AuthToken", result.Token);
            if (result.Code == 403) return Forbid();
            return Ok();
        }

        [HttpPut("BanUser")]
        [Authorize]
        public async Task<ActionResult<DtoUser>> BanUser(string email)
        {
            var id = Int32.Parse(User.Claims.First(p => p.Type == "id").Value);
            var presentedToken = HttpContext.Request.Headers.FirstOrDefault(x => x.Key == "Authorization").Value;
            if (await _jwtService.CheckAuthorization(id, presentedToken) is UnauthorizedResult)
            {
                return Unauthorized();
            }

            var result = await staffService.BanUser(id, email);
            HttpContext.Response.Headers.Add("AuthToken", result.Token);
            if (result.Code == 403) return Forbid();
            if (result.Code == 404) return NotFound();
            return Ok();
        }

        [HttpPut("UnbanUser")]
        [Authorize]
        public async Task<ActionResult<DtoUser>> UnbanUser(string email)
        {
            var id = Int32.Parse(User.Claims.First(p => p.Type == "id").Value);
            var presentedToken = HttpContext.Request.Headers.FirstOrDefault(x => x.Key == "Authorization").Value;
            if (await _jwtService.CheckAuthorization(id, presentedToken) is UnauthorizedResult)
            {
                return Unauthorized();
            }
            
            var result = await staffService.UnbanUser(id, email);
            HttpContext.Response.Headers.Add("AuthToken", result.Token);
            if (result.Code == 403) return Forbid();
            if (result.Code == 404) return NotFound();
            return Ok();
        }
    }
}
