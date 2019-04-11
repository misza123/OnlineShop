using System;
using System.Threading.Tasks;

namespace OnlineShop.WebApi.DataAccess
{
    public interface IUnitOfWork : IDisposable
    {
        Task CompleteAsync();
        Task SaveChangesAsync();
    }
}