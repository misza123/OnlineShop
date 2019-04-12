using AutoMapper;
using OnlineShop.WebApi.Orders.Dtos;

namespace OnlineShop.WebApi.Orders.Mappings
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderDTO>();
        }
    }
}