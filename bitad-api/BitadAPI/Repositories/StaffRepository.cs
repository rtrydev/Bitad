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
        public Task<ICollection<Staff>> GetAllPublic();
    }

    public class StaffRepository : Repository<Staff>, IStaffRepository
    {
        public StaffRepository(RepositoryContext context) : base(context)
        {
        }

        async Task<ICollection<Staff>> IStaffRepository.GetAll()
        {
            return await GetAll().OrderBy(x => x.Id).ToListAsync();
        }

        public async Task<ICollection<Staff>> GetAllPublic()
        {
            return await GetAll().Where(x => x.IsPublic).OrderBy(x => x.Id).ToListAsync();
        }
    }
}
