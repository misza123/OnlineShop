using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OnlineShop.WebApi.DataAccess
{
    public interface IRepository<T> where T : class
    {
        Task AddAsync(T entity);
        void Delete(T entity);
        Task<T> GetDetailAsync(Expression<Func<T, bool>> predicate);
        Task<ICollection<T>> GetAllAsync();
        Task<ICollection<T>> GetAllAsync(Expression<Func<T, bool>> predicate);
    }
}