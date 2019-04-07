using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineShop.WebApi.DataAccess;

namespace OnlineShop.WebApi.Users
{
    public class UserRepository : IRepository<User>
    {
        private DataContext _dataContext;

        public UserRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task AddAsync(User entity)
        {
            await _dataContext.Users.AddAsync(entity);
        }

        public void Delete(User entity)
        {
            _dataContext.Users.Remove(entity);
        }

        public async Task<ICollection<User>> GetAllAsync()
        {
            return await _dataContext.Users.ToListAsync();
        }

        public async Task<ICollection<User>> GetAllAsync(Expression<Func<User, bool>> predicate)
        {
            return await _dataContext.Users.Where(predicate).ToListAsync();
        }

        public async Task<User> GetDetailAsync(Expression<Func<User, bool>> predicate)
        {
            return await _dataContext.Users.Where(predicate).SingleOrDefaultAsync();
        }
    }
}