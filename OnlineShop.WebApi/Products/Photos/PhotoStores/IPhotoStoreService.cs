using System.IO;
using System.Threading.Tasks;

namespace OnlineShop.WebApi.Products.Photos
{
    public interface IPhotoStoreService
    {
        void AddPhotoToStoreAsync(string fileName, Stream stream);
    }
}