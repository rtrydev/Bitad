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
    }

    public class WorkshopRepository : Repository<Workshop>, IWorkshopRepository
    {
        public WorkshopRepository(RepositoryContext context) : base(context)
        {

        }

        async Task<ICollection<Workshop>> IWorkshopRepository.GetAll()
        {
            return await GetAll().Include(x => x.Speaker).ToListAsync();
        }
    }
}
