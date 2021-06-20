using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BitadAPI.Context;
using BitadAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BitadAPI.Repositories
{
    public interface IStaffRepository
    {
        public Task<ICollection<Staff>> GetAll();
    }

    public class StaffRepository : Repository<Staff>, IStaffRepository
    {
        public StaffRepository(RepositoryContext context) : base(context)
        {
        }

        async Task<ICollection<Staff>> IStaffRepository.GetAll()
        {
            return await GetAll().ToListAsync();
        }
    }
}
