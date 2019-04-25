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
        private readonly IRepository<Photo> _photoRepository;

        public PhotoController(IMapper mapper, IUnitOfWorkFactory uowFactory, IPhotoService photoService, IRepository<Photo> photoRepository)
        {
            _mapper = mapper;
            _uowFactory = uowFactory;
            _photoService = photoService;
            _photoRepository = photoRepository;
        }

        [HttpGet("{photoId}", Name = "GetPhoto")]
        public async Task<IActionResult> GetPhotoAsync(int photoId)
        {
            using (var uow = _uowFactory.Create())
            {
                var photo = await _photoRepository.GetDetailAsync(x => x.Id == photoId);
                var result = _mapper.Map<PhotoForDetailsDTO>(photo);

                return Ok(result);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddPhotoForProductAsync(int productId, [FromForm] AddPhotoForProductDTO dto)
        {
            using (var uow = _uowFactory.Create())
            {
                // TODO: needs to check if user is admin
                // var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

                var domainPhoto = _mapper.Map<Photo>(dto);
                domainPhoto.ProductId = productId;
                await _photoService.AddPhotoAsync(dto.File, domainPhoto);

                await uow.CompleteAsync();

                var result = _mapper.Map<PhotoForDetailsDTO>(domainPhoto);
                return CreatedAtRoute("GetPhoto", new {photoId = domainPhoto.Id}, result);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePhotoAsync(int productId, UpdatePhotoDTO dto)
        {
            using (var uow = _uowFactory.Create())
            {
                // TODO: needs to check if user is admin
                await _photoService.UpdatePhotoAsync(productId, dto);
    
                await uow.CompleteAsync();
                return NoContent();
            }
        }
    }
}