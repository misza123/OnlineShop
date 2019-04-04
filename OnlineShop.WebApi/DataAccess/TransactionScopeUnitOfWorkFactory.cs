using System.Transactions;

namespace OnlineShop.WebApi.DataAccess
{
    public class TransactionScopeUnitOfWorkFactory : IUnitOfWorkFactory
    {
        private readonly IsolationLevel _isolationLevel = IsolationLevel.ReadCommitted;
        private readonly DataContext _dataContext;
        
        public TransactionScopeUnitOfWorkFactory( DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IUnitOfWork Create()
        {
            return new UnitOfWork(_dataContext, _isolationLevel);
        }
    }
}