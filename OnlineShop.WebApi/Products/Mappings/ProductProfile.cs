using AutoMapper;
using OnlineShop.WebApi.Products.Dtos;

namespace OnlineShop.WebApi.Products.Mappings
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductForDetailsDTO>();
            CreateMap<Product, ProductForListDTO>();
        }
    }
}