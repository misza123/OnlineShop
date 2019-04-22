using Microsoft.AspNetCore.Http;

namespace OnlineShop.WebApi.Products.Photos.Dtos
{
    public class AddPhotoForProductDTO
    {
        public string Url { get; set; } 
        public IFormFile File { get; set; }
        public string Description { get; set; }
    }
}