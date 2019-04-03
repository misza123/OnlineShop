using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OnlineShop.WebApi.DataAccess
{
    public interface IRepository<T> where T : class
    {
        Task<ICollection<T>> GetAllAsync();
        Task AddAsync(T entity);
        void Delete(T entity);
        Task<T> GetDetailAsync(Expression<Func<T, bool>> predicate);
    }
}