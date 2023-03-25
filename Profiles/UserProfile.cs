using AutoMapper;
using RestaurantWebAPI.Entities;

namespace RestaurantWebAPI.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, ExternalModels.UserDTO>();
            CreateMap<ExternalModels.UserDTO, User>();
        }
    }
}
