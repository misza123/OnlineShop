namespace OnlineShop.WebApi.Users.Helpers
{
    public static class PasswordHelper
    {
        public static (byte[] salt, byte[] hash) CreatePasswordHash(string password)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                return (salt: hmac.Key, hash: hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password)));
            }
        }
    }
}