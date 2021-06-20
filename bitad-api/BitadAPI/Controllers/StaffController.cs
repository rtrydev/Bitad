using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BitadAPI.Dto;
using BitadAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace BitadAPI.Controllers
{
    [Route("[controller]")]
    public class StaffController : Controller
    {
        private IStaffService staffService;

        public StaffController(IStaffService service)
        {
            staffService = service;
        }

        [HttpGet("GetStaff")]
        public async Task<ActionResult<ICollection<DtoStaff>>> GetStaff()
        {
            return Ok(await staffService.GetAll());
        }
    }
}
