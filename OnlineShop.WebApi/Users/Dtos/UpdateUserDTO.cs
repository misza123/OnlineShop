using System.Collections.Generic;

namespace OnlineShop.WebApi.Users.Dtos
{
    public class UpdateUserDTO
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        public ICollection<UpdateAddressDTO> Addresses { get; set; }
    }
}