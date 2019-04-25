namespace OnlineShop.WebApi.Products.Photos.Dtos
{
    public class UpdatePhotoDTO
    {
        public int Id { get; set; }
        public bool IsMain { get; set; }
        public string Description { get; set; }
    }
}