using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.WebApi.DataAccess;
using OnlineShop.WebApi.Products.Dtos;

namespace OnlineShop.WebApi.Products
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IUnitOfWorkFactory _uowFactory;
        private readonly IRepository<Product> _productRepository;
        private readonly IMapper _mapper;

        public ProductController(IUnitOfWorkFactory uowFactory, IRepository<Product> productRepository, IMapper mapper)
        {
            _uowFactory = uowFactory;
            _productRepository = productRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetProductsAsync()
        {
            using (var uow = _uowFactory.Create())
            {
                var products = await _productRepository.GetAllAsync();
                var results = _mapper.Map<ICollection<ProductForListDTO>>(products);

                await uow.CompleteAsync();
                return Ok(results);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductDetail(int id)
        {
            using (var uow = _uowFactory.Create())
            {
                var product = await _productRepository.GetDetailAsync(x=>x.Id == id);
                var result = _mapper.Map<ProductForListDTO>(product);

                await uow.CompleteAsync();
                return Ok(result);
            }
        }
    }
}