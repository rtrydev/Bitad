using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BitadAPI.Dto;
using BitadAPI.Repositories;
using BitadAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace BitadAPI.Controllers
{
    [Route("[controller]")]
    public class WorkshopController : Controller
    {
        private IWorkshopService workshopService;

        public WorkshopController(IWorkshopService service)
        {
            workshopService = service;
        }

        [HttpGet("GetWorkshops")]
        public async Task<ActionResult<ICollection<DtoWorkshop>>> GetWorkshops()
        {
            return Ok(await workshopService.GetAll());
        }
    }
}
