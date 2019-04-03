using System;
using System.Threading.Tasks;

namespace OnlineShop.WebApi.DataAccess
{
    public interface IUnitOfWork : IDisposable
    {
         Task SaveChangesAsync();
         IRepository<T> Repository<T>() where T : class;
    }
}