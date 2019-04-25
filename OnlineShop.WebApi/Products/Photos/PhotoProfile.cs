using AutoMapper;
using OnlineShop.WebApi.Products.Photos.Dtos;
using OnlineShop.WebApi.Products.Photos.PhotoStores;

namespace OnlineShop.WebApi.Products.Photos
{
    public class PhotoProfile : Profile
    {
        public PhotoProfile()
        {
            CreateMap<Photo, PhotoForDetailsDTO>();

            CreateMap<AddPhotoForProductDTO, Photo>();

            CreateMap<UpdatePhotoDTO, Photo>()
            .ForMember(x => x.Id, opt => opt.Ignore());

            CreateMap<UploadPhotoResult, Photo>();
        }
    }
}