namespace OnlineShop.WebApi.Users.Dtos
{
    public class UpdateAddressDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
        public string BuildingNumber { get; set; }
        public string FlatNumber { get; set; }
        public bool IsMain { get; set; }
    }
}