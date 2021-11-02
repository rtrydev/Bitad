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
    public class QrCodeRedeemController : AuthorizedController
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
            var result = await MakeAuthorizedServiceCall(code, _qrCodeRedeemService.RedeemQrCode, _jwtService);
            return result;
        }
    }
}
