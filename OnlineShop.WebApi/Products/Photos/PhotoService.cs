using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using OnlineShop.WebApi.DataAccess;

namespace OnlineShop.WebApi.Products.Photos
{
    public class PhotoService : IPhotoService
    {
        private readonly IRepository<Photo> _photoRepository;
        private readonly IPhotoStoreService _photoStoreService;

        public PhotoService(IRepository<Photo> photoRepository, IPhotoStoreService photoStoreService)
        {
            _photoRepository = photoRepository;
            _photoStoreService = photoStoreService;
        }

        public async Task AddPhotoAsync(IFormFile photoFile, Photo photo)
        {
            using (var stream = photoFile.OpenReadStream())
            {
                _photoStoreService.AddPhotoToStoreAsync(photoFile.Name, stream);
            }

            await _photoRepository.AddAsync(photo);
        }
    }
}