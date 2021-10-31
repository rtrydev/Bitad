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
    public class WorkshopController : AuthorizedController
    {
        private IWorkshopService _workshopService;
        private IJwtService _jwtService;

        public WorkshopController(IWorkshopService workshopService, IJwtService jwtService)
        {
            _workshopService = workshopService;
            _jwtService = jwtService;
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
            var result = await MakeAuthorizedServiceCall(workshopCode, _workshopService.GetParticipantsForWorkshop,
                _jwtService);
            return result;
        }
        
        [HttpPut("SelectWorkshop")]
        [Authorize]
        public async Task<ActionResult<DtoWorkshop>> SelectWorkshop(string workshopCode)
        {
            var result = await MakeAuthorizedServiceCall(workshopCode, _workshopService.SelectWorkshop, _jwtService);
            return result;
        }
    }
}
