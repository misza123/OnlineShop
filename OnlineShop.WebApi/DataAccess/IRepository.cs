using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShop.WebApi.DataAccess
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetAsync(int id);
        Task<ICollection<T>> GetAllAsync();
        Task AddAsync(T entity);
        void Delete(T entity);
    }
}