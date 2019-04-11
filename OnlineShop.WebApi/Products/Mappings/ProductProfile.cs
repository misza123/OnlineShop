using System.Linq;
using AutoMapper;
using OnlineShop.WebApi.Products.Dtos;

namespace OnlineShop.WebApi.Products.Mappings
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductForDetailsDTO>()
                .ForMember(dest => dest.PhotoURL, opt => opt.MapFrom(x => x.Photos.FirstOrDefault(p => p.IsMain).Url));
            CreateMap<Product, ProductForListDTO>()
                .ForMember(dest => dest.PhotoURL, opt => opt.MapFrom(x => x.Photos.FirstOrDefault(p => p.IsMain).Url));
        }
    }
}