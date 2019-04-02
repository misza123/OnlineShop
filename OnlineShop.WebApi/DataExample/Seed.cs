using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using OnlineShop.WebApi.DataAccess;
using OnlineShop.WebApi.Users;
using OnlineShop.WebApi.Users.Helpers;
using System.Threading.Tasks;
using System;
using OnlineShop.WebApi.Products;

namespace OnlineShop.WebApi.DataExample
{
    public class Seed
    {
        private readonly DataContext _dataAccess;

        public Seed(DataContext dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public async Task SeedDataAsync()
        {
            await SeedUsersDataAsync();
            await SeedProductsDataAsync();
        }

        private async Task SeedUsersDataAsync()
        {
            var data = File.ReadAllText("DataExample/UsersExampleData.json");
            var users = JsonConvert.DeserializeObject<List<User>>(data);
            foreach (var user in users)
            {
                var password = PasswordHelper.CreatePasswordHash("password");
                user.PasswordHash = password.hash;
                user.PasswordSalt = password.salt;

                await _dataAccess.Users.AddAsync(user);
            }

            await _dataAccess.SaveChangesAsync();
        }
        private async Task SeedProductsDataAsync()
        {
            var data = File.ReadAllText("DataExample/ProductsExampleData.json");
            var products = JsonConvert.DeserializeObject<List<Product>>(data);
            foreach (var product in products)
            {
                await _dataAccess.Products.AddAsync(product);
            }

            await _dataAccess.SaveChangesAsync();
        }
    }
}