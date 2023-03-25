using RestaurantWebAPI.Entities;

namespace RestaurantWebAPI.Services.Repositories
{
    public interface IOrderMenuRepository: IRepository<OrderMenu>
    {
        public OrderMenu GetOrderMenuDetails(Guid OrderMenuId);
    }
}
