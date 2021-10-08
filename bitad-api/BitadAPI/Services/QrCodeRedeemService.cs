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

            var currentTime = DateTime.Now;
            var newToken = await _jwtService.GetNewToken(userId);
            var nullResponse = TokenRefreshResponse<DtoQrCodeRedeem>.NullResponse(newToken);

            if (qrCode is null)
                return nullResponse;

            if (qrCode.ActivationTime > currentTime)
                return nullResponse;

            if (qrCode.DeactivationTime < currentTime)
                return nullResponse;

            if (await _qrCodeRedeemRepository.FindRedeem(qrCodeString, userId) is not null)
                return nullResponse;

            var user = await _userRepository.GetById(userId);

            if (user.AttendanceCheckDate is null)
                return nullResponse;
            
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
                Token = newToken
            };
        }
    }
}
