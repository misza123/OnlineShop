using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineShop.WebApi.DataAccess;
using OnlineShop.WebApi.Orders;

namespace OnlineShop.WebApid.Orders
{
    public class OrderRepository : IRepository<Order>
    {
        private DataContext _dataContext;

        public OrderRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task AddAsync(Order entity)
        {
            await _dataContext.Orders.AddAsync(entity);
        }

        public void Delete(Order entity)
        {
            _dataContext.Orders.Remove(entity);
        }

        public async Task<ICollection<Order>> GetAllAsync()
        {
            return await _dataContext.Orders.ToListAsync();
        }

        public Task<ICollection<Order>> GetAllAsync(Expression<Func<Order, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<Order> GetAsync(int id)
        {
            return await _dataContext.Orders.SingleOrDefaultAsync(x => x.Id == id);
        }

        public Task<Order> GetDetailAsync(Expression<Func<Order, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}