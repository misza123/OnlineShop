using System.Collections.Generic;

namespace OnlineShop.WebApi.Users.Dtos
{
    public class UserDetailsReturnDTO
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public ICollection<AddressReturnDTO> Addresses { get; set; }
    }
}