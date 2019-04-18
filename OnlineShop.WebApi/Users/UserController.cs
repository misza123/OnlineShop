using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.WebApi.DataAccess;
using OnlineShop.WebApi.Users.Dtos;

namespace OnlineShop.WebApi.Users
{
    [Authorize]
    [Route("api/auth/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWorkFactory _uowFactory;
        private readonly IRepository<User> _userRepository;
        private readonly IMapper _mapper;

        public UserController(IUnitOfWorkFactory uowFactory, IRepository<User> userRepository, IMapper mapper)
        {
            _uowFactory = uowFactory;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserDetails(int id)
        {
            //todo need implement identity and get user using jwt token.
            using (var uow = _uowFactory.Create())
            {
                var user = await _userRepository.GetDetailAsync(x => x.Id == id);
                var result = _mapper.Map<UserDetailsReturnDTO>(user);
                return Ok(user);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUserProfile(int id, UpdateUserDTO updateUserDTO)
        {
            using (var uow = _uowFactory.Create())
            {
                if (id != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                {
                    return Unauthorized();
                }

                var user = await _userRepository.GetDetailAsync(x => x.Id == id);
                _mapper.Map(updateUserDTO, user);
    
                await uow.SaveChangesAsync();
                await uow.CompleteAsync();
                return Ok();
            }
        }
    }
}