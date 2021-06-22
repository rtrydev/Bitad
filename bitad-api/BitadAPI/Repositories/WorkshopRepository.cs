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
        public Task<Workshop> AddParticipant(int id, User user);
        public Task<Workshop> GetById(int id);
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

        public async Task<Workshop> AddParticipant(int id, User user)
        {
            var workshop = await GetAll().FirstOrDefaultAsync(x => x.Id == id);
            workshop.Participants.Add(user);
            var result = await UpdateAsync(workshop);
            return result;
        }

        async Task<ICollection<Workshop>> IWorkshopRepository.GetAll()
        {
            return await GetAll().Include(x => x.Participants).Include(x => x.Speaker).ToListAsync();
        }

        public async Task<Workshop> GetById(int id)
        {
            return await GetAll().FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
