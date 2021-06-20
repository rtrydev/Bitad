using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BitadAPI.Context;
using BitadAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BitadAPI.Repositories
{
    public interface ISponsorRepository
    {
        public Task<ICollection<Sponsor>> GetAll();
    }

    public class SponsorRepository : Repository<Sponsor>, ISponsorRepository
    {
        public SponsorRepository(RepositoryContext context) : base(context)
        {
        }

        async Task<ICollection<Sponsor>> ISponsorRepository.GetAll()
        {
            return await GetAll().ToListAsync();
        }
    }
}
