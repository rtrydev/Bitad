using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BitadAPI.Context;
using BitadAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace BitadAPI.Repositories
{
    public interface IUserRepository
    {
        public Task<ICollection<User>> GetAll();
        public Task<User> GetById(int id);
        public Task<User> GetByPredicate(Expression<Func<User, bool>> predicate);
        public Task<User> AddPoints(int id, int points);
        public Task<ICollection<User>> GetTopUsers(int amount);
        public Task<User> CreateUser(User user);
        public Task<User> UpdateUser(User user);
    }

    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(RepositoryContext context) : base(context)
        {
        }

        async Task<ICollection<User>> IUserRepository.GetAll()
        {
            return await GetAll().ToListAsync();
        }

        public async Task<User> GetById(int id)
        {
            return await GetAll().Include(x => x.Workshop).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<User> GetByPredicate(Expression<Func<User, bool>> predicate)
        {
            return await GetAll().Include(x => x.Workshop).FirstOrDefaultAsync(predicate);
        }

        public async Task<User> AddPoints(int id, int points)
        {
            var user = await GetById(id);
            user.CurrentScore += points;
            var result = await UpdateAsync(user);
            return result;
        }

        public async Task<ICollection<User>> GetTopUsers(int amount)
        {
            return await GetAll().OrderByDescending(x => x.CurrentScore).Take(amount).ToListAsync();
        }

        public async Task<User> CreateUser(User user)
        {
            return await AddAsync(user);
        }

        public async Task<User> UpdateUser(User user)
        {
            return await UpdateAsync(user);
        }
    }
}
