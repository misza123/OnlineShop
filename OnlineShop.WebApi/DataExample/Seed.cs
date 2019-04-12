using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using OnlineShop.WebApi.DataAccess;
using OnlineShop.WebApi.Users;
using OnlineShop.WebApi.Users.Helpers;
using System.Threading.Tasks;
using System;
using OnlineShop.WebApi.Products;
using OnlineShop.WebApi.Orders;

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
            await SeedDataAsync<Product>("DataExample/ProductsExampleData.json");
            await SeedDataAsync<Order>("DataExample/OrdersData.json");
            await SeedDataAsync<OrderProduct>("DataExample/OrdersProductData.json");
        }

        private async Task SeedDataAsync<T>(string jsonDataPath) where T : class
        {
            var data = File.ReadAllText(jsonDataPath);
            var deserializedObjects = JsonConvert.DeserializeObject<List<T>>(data);
            foreach (var deserializedObject in deserializedObjects)
            {
                await _dataAccess.Set<T>().AddAsync(deserializedObject);
            }

            await _dataAccess.SaveChangesAsync();
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
    }
}