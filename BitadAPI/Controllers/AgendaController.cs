using System.Collections.Generic;
using System.Threading.Tasks;
using BitadAPI.Dto;
using BitadAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace BitadAPI.Controllers
{
    [Route("[controller]")]
    public class AgendaController : Controller
    {
        private IAgendaService agendaService;

        public AgendaController(IAgendaService service)
        {
            agendaService = service;
        }

        [HttpGet("GetAgendas")]
        public async Task<ActionResult<ICollection<DtoAgenda>>> GetAgendas()
        {
            return Ok(await agendaService.GetAll());
        }
    }
}
