using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.WebApi.DataAccess;

namespace OnlineShop.WebApi.Orders
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IUnitOfWorkFactory _uowFactory;
        private readonly IRepository<Order> _orderRepository;

        public OrderController(IUnitOfWorkFactory uowFactory, IRepository<Order> orderRepository)
        {
            _uowFactory = uowFactory;
            _orderRepository = orderRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrdersAsync()
        {
            var userId = 1;
            var orders = await  _orderRepository.GetAllAsync(x=>x.User.Id == userId);
            return Ok(orders);
        }
    }
}