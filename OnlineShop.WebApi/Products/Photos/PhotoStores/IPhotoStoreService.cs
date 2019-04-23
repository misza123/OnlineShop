using System.IO;
using System.Threading.Tasks;
using OnlineShop.WebApi.Products.Photos.PhotoStores;

namespace OnlineShop.WebApi.Products.Photos
{
    public interface IPhotoStoreService
    {
        UploadPhotoResult AddPhotoToStore(string fileName, Stream stream);
    }
}