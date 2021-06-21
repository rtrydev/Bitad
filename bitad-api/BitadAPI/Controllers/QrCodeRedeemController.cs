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
        private IQrCodeRedeemService _qrCodeRedeemService;
        private IJwtService _jwtService;

        public QrCodeRedeemController(IQrCodeRedeemService qrCodeRedeemService, IJwtService jwtService)
        {
            _qrCodeRedeemService = qrCodeRedeemService;
            _jwtService = jwtService;
        }

        [Authorize]
        [HttpPost("RedeemQrCode")]
        public async Task<ActionResult<DtoQrCodeRedeem>> RedeemCode(string code)
        {
            var id = Int32.Parse(User.Claims.First(p => p.Type == "id").Value);
            var presentedToken = HttpContext.Request.Headers.FirstOrDefault(x => x.Key == "Authorization").Value;
            if (await _jwtService.CheckAuthorization(id, presentedToken) is UnauthorizedResult)
            {
                return Unauthorized();
            }
            var result = await _qrCodeRedeemService.RedeemQrCode(code, id);
            if (result is null) return Forbid();
            HttpContext.Response.Headers.Add("AuthToken", result.Token);
            return Ok(result.Body);
        }
    }
}
