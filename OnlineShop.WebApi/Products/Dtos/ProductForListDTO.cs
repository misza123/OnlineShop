namespace OnlineShop.WebApi.Products.Dtos
{
    public class ProductForListDTO
    {   
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string PhotoURL { get; set; }
    }
}