using System.Collections.Generic;
using System.Threading.Tasks;
using BitadAPI.Dto;
using BitadAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BitadAPI.Controllers
{
    [Route("[controller]")]
    public class AdminController : AuthorizedController
    {
        private IAdminService _adminService;
        private IJwtService _jwtService;
        
        public AdminController(IAdminService adminService, IJwtService jwtService)
        {
            _adminService = adminService;
            _jwtService = jwtService;
        }
        
        [HttpGet("GetWinners")]
        [Authorize]
        public async Task<ActionResult<ICollection<DtoUser>>> GetWinners(int numberOfWinners)
        {
            var result = await MakeAuthorizedServiceCall(numberOfWinners, false, _adminService.GetWinners, _jwtService);
            return result;
        }

        [HttpGet("GetMainWinner")]
        [Authorize]

        public async Task<ActionResult<ICollection<DtoUser>>> GetMainWinner()
        {
            var result = await MakeAuthorizedServiceCall(1, true, _adminService.GetWinners, _jwtService);
            return result;
        }

        [HttpPost("SendConfirmationMails")]
        [Authorize]
        public async Task<ActionResult> SendConfirmationMails()
        {
            var result = await MakeAuthorizedServiceCall(_adminService.SendConfirmationMails, _jwtService);
            return result;
        }
        
        [HttpPost("SendInformationMails")]
        [Authorize]
        
        public async Task<ActionResult> SendInformationMails(string htmlName, string title)
        {
            var result =
                await MakeAuthorizedServiceCall(htmlName, title, _adminService.SendInformationMails, _jwtService);
            return result;
        }

        [HttpPost("ExcludeInactiveUsersFromWorkshops")]
        [Authorize]
        public async Task<ActionResult> ExcludeInactiveUsersFromWorkshops()
        {
            var result = await MakeAuthorizedServiceCall(_adminService.ExcludeInactiveUsersFromWorkshops, _jwtService);
            return result;
        }

        [HttpPut("BanUser")]
        [Authorize]
        public async Task<ActionResult<DtoUser>> BanUser(string email)
        {
            var result = await MakeAuthorizedServiceCall(email, _adminService.BanUser, _jwtService);
            return result;
        }

        [HttpPut("UnbanUser")]
        [Authorize]
        public async Task<ActionResult<DtoUser>> UnbanUser(string email)
        {
            var result = await MakeAuthorizedServiceCall(email, _adminService.UnbanUser, _jwtService);
            return result;
        }
    }
}