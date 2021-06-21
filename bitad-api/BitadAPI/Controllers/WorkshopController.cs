using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BitadAPI.Dto;
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

        public WorkshopController(IWorkshopService workshopService)
        {
            _workshopService = workshopService;
        }

        [HttpGet("GetWorkshops")]
        public async Task<ActionResult<ICollection<DtoWorkshop>>> GetWorkshops()
        {
            return Ok(await _workshopService.GetAll());
        }

        
    }
}
