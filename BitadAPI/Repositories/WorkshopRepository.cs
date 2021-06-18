using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BitadAPI.Context;
using BitadAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BitadAPI.Repositories
{
    public interface IWorkshopRepository
    {
        public Task<ICollection<Workshop>> GetAll();
        public Task<Workshop> GetByCode(string code);
    }

    public class WorkshopRepository : Repository<Workshop>, IWorkshopRepository
    {
        public WorkshopRepository(RepositoryContext context) : base(context)
        {
        }

        public async Task<Workshop> GetByCode(string code)
        {
            return await GetAll().Include(x => x.Speaker).FirstOrDefaultAsync(x => x.Code == code);
        }

        async Task<ICollection<Workshop>> IWorkshopRepository.GetAll()
        {
            return await GetAll().Include(x => x.Speaker).ToListAsync();
        }
    }
}
