using AutoMapper;
using RestaurantWebAPI.Entities;

namespace RestaurantWebAPI.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, ExternalModels.OrderDTO>();
            CreateMap<ExternalModels.OrderDTO, Order>();

            CreateMap<OrderMenu, ExternalModels.OrderMenuDTO>();
            CreateMap<ExternalModels.OrderMenuDTO, OrderMenu>();
        }
    }
}
