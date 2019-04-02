using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineShop.WebApi.DataAccess;
using OnlineShop.WebApi.Users.Helpers;

namespace OnlineShop.WebApi.Users
{
    public class AuthService : IAuthService
    {
        private readonly DataContext _context;

        public AuthService(DataContext context)
        {
            _context = context;
        }

        public async Task<User> LoginAsync(string username, string password)
        {
            var user = await _context.Users.SingleOrDefaultAsync(x => x.Username.Equals(username, StringComparison.InvariantCultureIgnoreCase));

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

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<bool> UserExistsAsync(string username)
        {
            if (await _context.Users.AnyAsync(x => x.Username.Equals(username, StringComparison.InvariantCultureIgnoreCase)))
            {
                return true;
            }
            return false;
        }
    }
}