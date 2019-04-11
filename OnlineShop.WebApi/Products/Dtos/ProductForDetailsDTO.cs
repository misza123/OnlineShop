using System.Collections.Generic;

namespace OnlineShop.WebApi.Products.Dtos
{
    public class ProductForDetailsDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public ICollection<Photo> Photos { get; set; }
    }
}