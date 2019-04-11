namespace OnlineShop.WebApi.Products.Dtos
{
    public class PhotoForDetailsDTO
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public bool IsMain { get; set; }
    }
}