using System.Transactions;

namespace OnlineShop.WebApi.DataAccess
{
    public interface IUnitOfWorkFactory
    {
        IUnitOfWork Create();
    }
}