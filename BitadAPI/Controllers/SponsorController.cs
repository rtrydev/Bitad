using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BitadAPI.Dto;
using BitadAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace BitadAPI.Controllers
{
    [Route("[controller]")]
    public class SponsorController : Controller
    {
        private ISponsorService sponsorSerivce;

        public SponsorController(ISponsorService service)
        {
            sponsorSerivce = service;
        }

        [HttpGet("GetSponsors")]
        public async Task<ActionResult<ICollection<DtoSponsor>>> GetSponsors()
        {
            var sponsors = await sponsorSerivce.GetAll();
            return Ok(sponsors);
        }
    }
}
