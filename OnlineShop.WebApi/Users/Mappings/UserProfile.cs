using AutoMapper;
using OnlineShop.WebApi.Users.Dtos;

namespace OnlineShop.WebApi.Users.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDetailsReturnDTO>();
        }
    }
}