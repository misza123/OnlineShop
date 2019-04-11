using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineShop.WebApi.DataAccess;
using OnlineShop.WebApi.Users.Helpers;

namespace OnlineShop.WebApi.Users
{
    public class AuthService : IAuthService
    {
        private readonly IRepository<User> _userRepository;

        public AuthService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> LoginAsync(string username, string password)
        {
            var user = await _userRepository.GetDetailAsync(x => x.Username.Equals(username, StringComparison.InvariantCultureIgnoreCase));

            if (user == null)
            {
                return null;
            }

            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            {
                return null;
            }

            return user;
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

                for (int i = 0; i < passwordHash.Length; i++)
                {
                    if (passwordHash[i] != computedHash[i])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public async Task<User> RegisterAsync(User user, string password)
        {
            var hashedPassword = PasswordHelper.CreatePasswordHash(password);

            user.PasswordHash = hashedPassword.hash;
            user.PasswordSalt = hashedPassword.salt;

            await _userRepository.AddAsync(user);

            return user;
        }

        public async Task<bool> UserExistsAsync(string username)
        {
            var users = await _userRepository.GetAllAsync(x => x.Username.Equals(username, StringComparison.InvariantCultureIgnoreCase));
            if (users.Any())
            {
                return true;
            }
            return false;
        }
    }
}