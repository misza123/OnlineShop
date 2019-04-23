using System.IO;
using System.Threading.Tasks;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.Extensions.Options;
using OnlineShop.WebApi.Products.Photos.PhotoStores;
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
        public UploadPhotoResult AddPhotoToStore(string fileName, Stream stream)
        {
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(fileName, stream),
                Transformation = new Transformation().Width(500).Height(500).Crop("fill")
            };

            _cloudinary.Upload(uploadParams);

            var uploadResult = new UploadPhotoResult();

            return uploadResult;
        }
    }
}