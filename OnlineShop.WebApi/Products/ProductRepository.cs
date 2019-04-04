using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineShop.WebApi.DataAccess;

namespace OnlineShop.WebApi.Products
{
    public class ProductRepository : IRepository<Product>
    {
        private DataContext _dataContext;

        public ProductRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task AddAsync(Product entity)
        {
            await _dataContext.Products.AddAsync(entity);
        }

        public void Delete(Product entity)
        {
            _dataContext.Products.Remove(entity);
        }

        public async Task<ICollection<Product>> GetAllAsync()
        {
            return await _dataContext.Products.ToListAsync();
        }

        public Task<ICollection<Product>> GetAllAsync(Expression<Func<Product, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<Product> GetAsync(int id)
        {
            return await _dataContext.Products.SingleOrDefaultAsync(x => x.Id == id);
        }

        public Task<Product> GetDetailAsync(Expression<Func<Product, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}