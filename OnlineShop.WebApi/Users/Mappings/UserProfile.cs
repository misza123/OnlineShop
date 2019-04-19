using System;
using System.Linq;
using AutoMapper;
using OnlineShop.WebApi.Users.Dtos;

namespace OnlineShop.WebApi.Users.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDetailsReturnDTO>();

            CreateMap<UpdateUserDTO, User>()
            .ForMember(dest => dest.Addresses, opt => opt.Ignore())
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.Username, opt => opt.Ignore())
            .ForMember(dest => dest.PasswordHash, opt => opt.Ignore())
            .ForMember(dest => dest.PasswordSalt, opt => opt.Ignore())
            .ForMember(dest => dest.Orders, opt => opt.Ignore())
            .AfterMap((dto, dest) => AddOrUpdateAddresses(dto, dest));
        }

        private void AddOrUpdateAddresses(UpdateUserDTO dto, User user)
        {
            foreach (var address in dto.Addresses)
            {
                Mapper.Map(address, user.Addresses.Single(x => x.Id == address.Id));
            }
        }
    }
}