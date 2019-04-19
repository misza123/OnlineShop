using AutoMapper;

namespace OnlineShop.WebApi.Products.Photos
{
    public class PhotoProfile : Profile
    {
        public PhotoProfile()
        {
            CreateMap<Photo, PhotoForDetailsDTO>();
        }
    }
}