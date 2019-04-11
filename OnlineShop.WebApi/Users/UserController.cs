using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.WebApi.DataAccess;

namespace OnlineShop.WebApi.Users
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWorkFactory _uowFactory;
        private readonly IRepository<User> _userRepository;

        public UserController(IUnitOfWorkFactory uowFactory, IRepository<User> userRepository)
        {
            _uowFactory = uowFactory;
            _userRepository = userRepository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserDetails(int id)
        {
            using (var uow = _uowFactory.Create())
            {
                var user = await _userRepository.GetDetailAsync(x => x.Id == id);

                return Ok(user);
            }
        }
    }
}