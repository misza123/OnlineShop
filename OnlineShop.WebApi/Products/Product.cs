using System.Collections.Generic;
using OnlineShop.WebApi.Orders;

namespace OnlineShop.WebApi.Products
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public ICollection<Photo> Photos { get; set; }
        public virtual ICollection<OrderProduct> OrderProduct { get; set; }
    }
}