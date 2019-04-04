using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Transactions;

namespace OnlineShop.WebApi.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _dataContext;
        private readonly TransactionScope _transactionScope;

        public UnitOfWork(DataContext dataContext, IsolationLevel isolationLevel)
        {
            _dataContext = dataContext;
            //  todo make it works
            // _transactionScope = new TransactionScope(
            //     TransactionScopeOption.Required,
            //     new TransactionOptions
            //     {
            //         IsolationLevel = isolationLevel,
            //         Timeout = TransactionManager.DefaultTimeout
            //     }, 
            //     TransactionScopeAsyncFlowOption.Enabled
            // );
        }

        public async Task SaveChangesAsync()
        {
            await _dataContext.SaveChangesAsync();
            // _transactionScope.Complete();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _dataContext.Dispose();
                    // _transactionScope.Dispose();
                }
            }
            this.disposed = true;
        }
    }
}