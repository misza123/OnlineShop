using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.WebApi.DataAccess;
using OnlineShop.WebApi.Orders.Dtos;

namespace OnlineShop.WebApi.Orders
{
    [Authorize]
    [Route("api/auth/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IUnitOfWorkFactory _uowFactory;
        private readonly IRepository<Order> _orderRepository;
        private readonly IMapper _mapper;

        public OrderController(IUnitOfWorkFactory uowFactory, IRepository<Order> orderRepository, IMapper mapper)
        {
            _uowFactory = uowFactory;
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetOrdersAsync(int userId)
        {
            using (var uow = _uowFactory.Create())
            {
                var orders = await _orderRepository.GetAllAsync(x => x.User.Id == userId);
                var result = _mapper.Map<ICollection<OrderDTO>>(orders);
                await uow.CompleteAsync();

                return Ok(orders);
            }
        }

        //todo: drop me - its only for tests
        // need to implement identity to retrive id and getting only orders of specific user
        [HttpGet]
        public async Task<IActionResult> GetOrdersAsync()
        {
            using (var uow = _uowFactory.Create())
            {
                var orders = await _orderRepository.GetAllAsync();
                var result = _mapper.Map<ICollection<OrderDTO>>(orders);
                await uow.CompleteAsync();

                return Ok(orders);
            }
        }
    }
}