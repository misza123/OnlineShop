using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using OnlineShop.WebApi.DataAccess;
using OnlineShop.WebApi.Products.Photos.Dtos;
using OnlineShop.WebApi.Settings;

namespace OnlineShop.WebApi.Products.Photos
{
    [Authorize]
    [Route("api/auth/product/{productId}/[controller]")]
    [ApiController]
    public class PhotoController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWorkFactory _uowFactory;
        private readonly IPhotoService _photoService;

        public PhotoController(IMapper mapper, IUnitOfWorkFactory uowFactory, IPhotoService photoService)
        {
            _mapper = mapper;
            _uowFactory = uowFactory;
            _photoService = photoService;
        }

        [HttpPost]
        public async Task<IActionResult> AddPhotoForProductAsync(int productId, AddPhotoForProductDTO dto)
        {
            using (var uow = _uowFactory.Create())
            {
                // TODO: needs to check if user is admin
                // var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

                var domainPhoto = _mapper.Map<Photo>(dto);
                await _photoService.AddPhotoAsync(dto.File, domainPhoto);
                await uow.CompleteAsync();
                return Ok();
            }
        }
    }
}