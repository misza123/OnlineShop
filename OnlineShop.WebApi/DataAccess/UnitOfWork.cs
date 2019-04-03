using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShop.WebApi.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _dataContext;
        private IDictionary<Type, object> repositories = new Dictionary<Type, object>();
        public UnitOfWork(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IRepository<T> Repository<T>() where T : class
        {
            if (repositories.Keys.Contains(typeof(T)))
            {
                return repositories[typeof(T)] as IRepository<T>;
            }
            
            IRepository<T> repo = new GenericRepository<T>(_dataContext);
            repositories.Add(typeof(T), repo);
            return repo;
        }

        public async Task SaveChangesAsync()
        {
            await _dataContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _dataContext.Dispose();
                }
            }
            this.disposed = true;
        }
    }
}