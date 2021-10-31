using System.Collections.Generic;
using System.Threading.Tasks;
using BitadAPI.Dto;
using BitadAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BitadAPI.Controllers
{
    [Route("[controller]")]
    public class StaffController : BitadController
    {
        private IStaffService _staffService;
        private IJwtService _jwtService;

        public StaffController(IStaffService staffService, IJwtService jwtService)
        {
            _staffService = staffService;
            _jwtService = jwtService;
        }

        [HttpGet("GetStaff")]
        public async Task<ActionResult<ICollection<DtoStaff>>> GetStaff()
        {
            return Ok(await _staffService.GetAll());
        }

        [HttpGet("GetStaffAdmin")]
        [Authorize]
        public async Task<ActionResult<ICollection<DtoStaff>>> GetStaffAdmin()
        {
            var result = await MakeAuthorizedServiceCall(_staffService.GetAllAdmin, _jwtService);
            return result;
        }

        [HttpPost("SendConfirmationMails")]
        [Authorize]
        public async Task<ActionResult> SendConfirmationMails()
        {
            var result = await MakeAuthorizedServiceCall(_staffService.SendConfirmationMails, _jwtService);
            return result;
        }

        [HttpPost("ExcludeInactiveUsersFromWorkshops")]
        [Authorize]
        public async Task<ActionResult> ExcludeInactiveUsersFromWorkshops()
        {
            var result = await MakeAuthorizedServiceCall(_staffService.ExcludeInactiveUsersFromWorkshops, _jwtService);
            return result;
        }

        [HttpPut("BanUser")]
        [Authorize]
        public async Task<ActionResult<DtoUser>> BanUser(string email)
        {
            var result = await MakeAuthorizedServiceCall(email, _staffService.BanUser, _jwtService);
            return result;
        }

        [HttpPut("UnbanUser")]
        [Authorize]
        public async Task<ActionResult<DtoUser>> UnbanUser(string email)
        {
            var result = await MakeAuthorizedServiceCall(email, _staffService.UnbanUser, _jwtService);
            return result;
        }
        
    }
}
