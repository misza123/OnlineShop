using System.Collections.Generic;
using OnlineShop.WebApi.Products;
using OnlineShop.WebApi.Products.Orders;

namespace OnlineShop.WebApi.Users
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public ICollection<Address> Addresses { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
