using Microsoft.EntityFrameworkCore;

namespace OnlineShop.WebApi.DataAccess
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    }
}