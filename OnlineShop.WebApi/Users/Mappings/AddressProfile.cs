using AutoMapper;
using OnlineShop.WebApi.Users.Dtos;

namespace OnlineShop.WebApi.Users.Mappings
{
    public class AddressProfile : Profile
    {
        public AddressProfile()
        {
            CreateMap<Address, AddressReturnDTO>();

            CreateMap<UpdateAddressDTO, Address>();
        }
    }
}