using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace OnlineShop.WebApi.Products.Photos
{
    public interface IPhotoService
    {
        Task AddPhotoAsync(IFormFile photoFile, Photo photo);
    }
}