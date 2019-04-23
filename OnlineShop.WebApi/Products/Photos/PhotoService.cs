using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using OnlineShop.WebApi.DataAccess;
using OnlineShop.WebApi.Products.Photos.PhotoStores;

namespace OnlineShop.WebApi.Products.Photos
{
    public class PhotoService : IPhotoService
    {
        private readonly IRepository<Photo> _photoRepository;
        private readonly IPhotoStoreService _photoStoreService;
        private readonly IMapper _mapper;

        public PhotoService(IRepository<Photo> photoRepository, IPhotoStoreService photoStoreService, IMapper mapper)
        {
            _photoRepository = photoRepository;
            _photoStoreService = photoStoreService;
            _mapper = mapper;
        }

        public async Task AddPhotoAsync(IFormFile photoFile, Photo photo)
        {
            if (photoFile.Length > 0)
            {
                UploadPhotoResult uploadResult;
                using (var stream = photoFile.OpenReadStream())
                {
                    uploadResult = _photoStoreService.AddPhotoToStore(photoFile.Name, stream);
                }

                _mapper.Map(uploadResult, photo);

                var hasProductMainPhoto = (await _photoRepository.AnyAsync(x=> x.ProductId == photo.ProductId && x.IsMain == true ));
                if(!hasProductMainPhoto)
                {
                    photo.IsMain = true;
                }
                
                await _photoRepository.AddAsync(photo);
            }
        }
    }
}