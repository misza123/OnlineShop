using System.IO;
using System.Threading.Tasks;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.Extensions.Options;
using OnlineShop.WebApi.Settings;

namespace OnlineShop.WebApi.Products.Photos
{
    public class CloudinaryStoreService : IPhotoStoreService
    {
        private readonly Cloudinary _cloudinary;

        public CloudinaryStoreService(IOptions<CloudinarySettings> cloudinaryConfig)
        {
            var cloudinaryAccount = new Account(
                cloudinaryConfig.Value.CloudName,
                cloudinaryConfig.Value.ApiKey,
                cloudinaryConfig.Value.ApiSecret
            );
            _cloudinary = new Cloudinary(cloudinaryAccount);
        }

        public void AddPhotoToStoreAsync(string fileName, Stream stream)
        {
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(fileName, stream)
            };
            
            _cloudinary.Upload(uploadParams);
        }
    }
}