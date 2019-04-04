using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using OnlineShop.WebApi.DataAccess;
using OnlineShop.WebApi.Users.Dtos;

namespace OnlineShop.WebApi.Users
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IConfiguration _config;
        private readonly IUnitOfWorkFactory _uowFactory;

        public AuthController(IAuthService authService, IConfiguration config, IUnitOfWorkFactory uowFactory)
        {
            _authService = authService;
            _config = config;
            _uowFactory = uowFactory;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserForRegisterDTO userForRegisterDTO)
        {
            if (await _authService.UserExistsAsync(userForRegisterDTO.Username))
            {
                return BadRequest("Username already exists.");
            }

            var user = new User() { Username = userForRegisterDTO.Username };
            await _authService.RegisterAsync(user, userForRegisterDTO.Password);

            return StatusCode(201);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserForLoginDTO userForLoginDTO)
        {
            using (var uow = _uowFactory.Create())
            {
                var user = await _authService.LoginAsync(userForLoginDTO.Username, userForLoginDTO.Password);

                if (user == null)
                {
                    return Unauthorized();
                }

                var claims = new[]{
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.Username)
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));

                var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(claims),
                    Expires = DateTime.Now.AddDays(1),
                    SigningCredentials = credentials
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var token = tokenHandler.CreateToken(tokenDescriptor);

                await uow.SaveChangesAsync();

                return Ok(new { token = tokenHandler.WriteToken(token) });
            }

        }
    }
}