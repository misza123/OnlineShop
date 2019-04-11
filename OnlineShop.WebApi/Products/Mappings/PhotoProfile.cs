using AutoMapper;
using OnlineShop.WebApi.Products.Dtos;

namespace OnlineShop.WebApi.Products.Mappings
{
    public class PhotoProfile : Profile
    {
        public PhotoProfile()
        {
            CreateMap<Photo, PhotoForDetailsDTO>();
        }
    }
}