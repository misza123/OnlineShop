using System;
using System.IO;
using System.Threading.Tasks;
using AutoMapper;
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
        private readonly IMapper _mapper;

        public CloudinaryStoreService(IOptions<CloudinarySettings> cloudinaryConfig, IMapper mapper)
        {
            var cloudinaryAccount = new Account(
                cloudinaryConfig.Value.CloudName,
                cloudinaryConfig.Value.ApiKey,
                cloudinaryConfig.Value.ApiSecret
            );
            _cloudinary = new Cloudinary(cloudinaryAccount);

            _mapper = mapper;
        }

        public UploadPhotoResult AddPhotoToStore(string fileName, Stream stream)
        {
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(fileName, stream),
                Transformation = new Transformation().Width(500).Height(500).Crop("fill")
            };

            var result = _cloudinary.Upload(uploadParams);
            if (result.Error != null)
            {
                throw new InvalidOperationException(result.Error.Message);
            }
            
            var uploadResult = _mapper.Map<UploadPhotoResult>(result);

            return uploadResult;
        }
    }
}