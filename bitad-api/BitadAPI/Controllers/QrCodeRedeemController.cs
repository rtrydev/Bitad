using System;
using System.Linq;
using System.Threading.Tasks;
using BitadAPI.Dto;
using BitadAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BitadAPI.Controllers
{
    [Route("[controller]")]
    public class QrCodeRedeemController : Controller
    {
        private IQrCodeRedeemService qrCodeRedeemService;

        public QrCodeRedeemController(IQrCodeRedeemService service)
        {
            qrCodeRedeemService = service;
        }

        [Authorize]
        [HttpPost("RedeemQrCode")]
        public async Task<ActionResult<DtoQrCodeRedeem>> RedeemCode(string code)
        {
            var id = Int32.Parse(User.Claims.First(p => p.Type == "id").Value);
            var result = await qrCodeRedeemService.RedeemQrCode(code, id);
            if (result is null) return Forbid();
            return Ok(result);
        }
    }
}
