using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineShop.WebApi.DataAccess;

namespace OnlineShop.WebApi.Products
{
    public class ProductRepository : IRepository<Product>
    {
        private readonly DataContext _dataContext;

        public ProductRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task AddAsync(Product product)
        {
            await _dataContext.Products.AddAsync(product);
        }

        public void Delete(Product entity)
        {
            _dataContext.Products.Remove(entity);
        }

        public async Task<ICollection<Product>> GetAllAsync()
        {
            return await _dataContext.Products.Include(x => x.Photos).ToListAsync();
        }

        public async Task<ICollection<Product>> GetAllAsync(Expression<Func<Product, bool>> predicate)
        {
            return await _dataContext.Products.Include(x => x.Photos).Where(predicate).ToListAsync();
        }

        public async Task<Product> GetDetailAsync(Expression<Func<Product, bool>> predicate)
        {
            return await _dataContext.Products.Include(x => x.Photos).FirstOrDefaultAsync(predicate);
        }
    }
}