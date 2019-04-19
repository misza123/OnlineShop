namespace OnlineShop.WebApi.Products
{
    public class Photo
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public bool IsMain { get; set; }
        public Product Product { get; set; }
        public int ProductId { get; set; }
        public string PublicId { get; set; }
    }
}