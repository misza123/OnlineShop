using Microsoft.EntityFrameworkCore;
using OnlineShop.WebApi.Orders;
using OnlineShop.WebApi.Products;
using OnlineShop.WebApi.Users;

namespace OnlineShop.WebApi.DataAccess
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }

    }
}