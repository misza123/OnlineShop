using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using OnlineShop.WebApi.Products.Photos.Dtos;

namespace OnlineShop.WebApi.Products.Photos
{
    public interface IPhotoService
    {
        Task AddPhotoAsync(IFormFile photoFile, Photo photo);

        Task UpdatePhotoAsync(int productId, UpdatePhotoDTO dto);
    }
}