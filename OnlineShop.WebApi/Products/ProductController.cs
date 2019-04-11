using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.WebApi.DataAccess;

namespace OnlineShop.WebApi.Products
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IUnitOfWorkFactory _uowFactory;
        private readonly IRepository<Product> _productRepository;

        public ProductController(IUnitOfWorkFactory uowFactory, IRepository<Product> productRepository)
        {
            _uowFactory = uowFactory;
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetProductsAsync()
        {
            using (var uow = _uowFactory.Create())
            {
                var products = await _productRepository.GetAllAsync();
                await uow.CompleteAsync();
                return Ok(products);
            }
        }
    }
}