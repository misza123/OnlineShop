using Microsoft.EntityFrameworkCore;
using OnlineShop.WebApi.Users;

namespace OnlineShop.WebApi.DataAccess
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}