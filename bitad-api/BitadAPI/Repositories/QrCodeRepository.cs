using System;
using System.Threading.Tasks;
using BitadAPI.Context;
using BitadAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BitadAPI.Repositories
{
    public interface IQrCodeRepository
    {
        public Task<QrCode> GetQrCode(string code);
    }

    public class QrCodeRepository : Repository<QrCode>, IQrCodeRepository
    {
        public QrCodeRepository(RepositoryContext context) : base(context)
        {
        }

        async Task<QrCode> IQrCodeRepository.GetQrCode(string code)
        {
            var qrCode = await GetAll().FirstOrDefaultAsync(x => x.Code == code);
            return qrCode;
        }
    }
}
