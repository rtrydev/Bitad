using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BitadAPI.Dto;
using BitadAPI.Models;
using BitadAPI.Repositories;

namespace BitadAPI.Services
{
    public interface IQrCodeRedeemService
    {
        public Task<TokenRefreshResponse<DtoQrCodeRedeem>> RedeemQrCode(string qrCodeString, int userId);
    }

    public class QrCodeRedeemService : IQrCodeRedeemService
    {
        private IQrCodeRedeemRepository _qrCodeRedeemRepository;
        private IQrCodeRepository _qrCodeRepository;
        private IUserRepository _userRepository;
        private IJwtService _jwtService;

        public QrCodeRedeemService(IQrCodeRepository qrCodeRepository, IQrCodeRedeemRepository qrCodeRedeemRepository, IUserRepository userRepository, IJwtService jwtService)
        {
            _qrCodeRedeemRepository = qrCodeRedeemRepository;
            _qrCodeRepository = qrCodeRepository;
            _userRepository = userRepository;
            _jwtService = jwtService;
        }

        public async Task<TokenRefreshResponse<DtoQrCodeRedeem>> RedeemQrCode(string qrCodeString, int userId)
        {
            var qrCode = await _qrCodeRepository.GetQrCode(qrCodeString);

            if (qrCode is null) return null;

            if (await _qrCodeRedeemRepository.FindRedeem(qrCodeString, userId) is not null)
                return null;

            var user = await _userRepository.GetById(userId);
            var result = await _qrCodeRedeemRepository.RedeemQrCode(qrCode, user);
            await _userRepository.AddPoints(userId, qrCode.Points);

            var redeem = new DtoQrCodeRedeem
            {
                Points = qrCode.Points,
                QrCode = qrCodeString
            };
            return new TokenRefreshResponse<DtoQrCodeRedeem>
            {
                Body = redeem,
                Token = await _jwtService.GetNewToken(userId)
            };
        }
    }
}
