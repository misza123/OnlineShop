using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineShop.WebApi.DataAccess;

namespace OnlineShop.WebApi.Products.Orders
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

        public async Task<Order> GetAsync(int id)
        {
            return await _dataContext.Orders.SingleOrDefaultAsync(x => x.Id == id);
        }
    }
}