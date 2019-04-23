using AutoMapper;
using CloudinaryDotNet.Actions;

namespace OnlineShop.WebApi.Products.Photos.PhotoStores
{
    public class UploadPhotoResultProfile : Profile
    {
        public UploadPhotoResultProfile()
        {
            CreateMap<UploadResult, UploadPhotoResult>();
        }
    }
}