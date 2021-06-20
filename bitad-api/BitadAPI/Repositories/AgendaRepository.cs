using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BitadAPI.Context;
using BitadAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BitadAPI.Repositories
{
    public interface IAgendaRepository
    {
        public Task<ICollection<Agenda>> GetAll();
    }

    public class AgendaRepository : Repository<Agenda>, IAgendaRepository
    {
        public AgendaRepository(RepositoryContext context) : base(context) 
        {
        }

        async Task<ICollection<Agenda>> IAgendaRepository.GetAll()
        {
            return await GetAll().Include(x => x.Speaker).ToListAsync();
        }
    }
}
