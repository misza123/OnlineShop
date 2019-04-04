using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OnlineShop.WebApi.DataAccess
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        private DataContext _dataContext;
        public GenericRepository(DataContext dataContext)
        {  
            _dataContext = dataContext;  
        }
        public async Task AddAsync(T entity)
        {
            await _dataContext.Set<T>().AddAsync(entity);
        }

        public void Delete(T entity)
        {
            _dataContext.Set<T>().Remove(entity);
        }

        public async Task<T> GetDetailAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dataContext.Set<T>().FirstOrDefaultAsync(predicate);
        }

        public async Task<ICollection<T>> GetAllAsync()
        {
            return await _dataContext.Set<T>().ToListAsync();
        }

        public Task<ICollection<T>> GetAllAsync(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}