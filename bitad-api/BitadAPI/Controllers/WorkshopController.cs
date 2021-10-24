using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BitadAPI.Dto;
using BitadAPI.Models;
using BitadAPI.Repositories;
using BitadAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BitadAPI.Controllers
{
    [Route("[controller]")]
    public class WorkshopController : Controller
    {
        private IWorkshopService _workshopService;
        private IJwtService _jwtService;
        private IUserService _userService;

        public WorkshopController(IWorkshopService workshopService, IJwtService jwtService, IUserService userService)
        {
            _workshopService = workshopService;
            _jwtService = jwtService;
            _userService = userService;
        }

        [HttpGet("GetWorkshops")]
        public async Task<ActionResult<ICollection<DtoWorkshop>>> GetWorkshops()
        {
            return Ok(await _workshopService.GetAll());
        }

        [HttpGet("GetWorkshopParticipants")]
        [Authorize]
        public async Task<ActionResult<ICollection<DtoWorkshopParticipant>>> GetWorkshopParticipants(
            string workshopCode)
        {
            var id = Int32.Parse(User.Claims.First(p => p.Type == "id").Value);
            var presentedToken = HttpContext.Request.Headers.FirstOrDefault(x => x.Key == "Authorization").Value;
            if(await _jwtService.CheckAuthorization(id, presentedToken) is UnauthorizedResult)
            {
                return Unauthorized();
            }
            var userRole = (await _userService.GetUserById(id)).Body.Role;
            if (userRole != UserRole.Super && userRole != UserRole.Admin)
            {
                return Forbid();
            }

            var result = await _workshopService.GetParticipantsForWorkshop(id, workshopCode);
            HttpContext.Response.Headers.Add("AuthToken", result.Token);
            if (result.Body is null) return NotFound();
            return Ok(result.Body);
        }
    }
}
