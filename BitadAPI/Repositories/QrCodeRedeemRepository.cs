using System;
using System.Threading.Tasks;
using BitadAPI.Context;
using BitadAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BitadAPI.Repositories
{
    public interface IQrCodeRedeemRepository
    {
        public Task<QrCodeRedeem> RedeemQrCode(QrCode qrCode, User user);
        public Task<QrCodeRedeem> FindRedeem(string qrCodeString, int userId);
    }

    public class QrCodeRedeemRepository : Repository<QrCodeRedeem>, IQrCodeRedeemRepository
    {
        public QrCodeRedeemRepository(RepositoryContext context) : base(context)
        {
        }

        public async Task<QrCodeRedeem> RedeemQrCode(QrCode qrCode, User user)
        {
            var qrCodeRedeem = await AddAsync(new QrCodeRedeem
            {
                QrCode = qrCode,
                RedeemTime = DateTime.Now,
                User = user
            });
            return qrCodeRedeem;
        }

        public async Task<QrCodeRedeem> FindRedeem(string qrCodeString, int userId)
        {
            var qrCodeRedeem = await GetAll().FirstOrDefaultAsync(x => x.User.Id == userId && x.QrCode.Code == qrCodeString);
            return qrCodeRedeem;
        }
    }
}
