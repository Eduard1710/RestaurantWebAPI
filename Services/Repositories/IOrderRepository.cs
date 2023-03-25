using RestaurantWebAPI.Entities;

namespace RestaurantWebAPI.Services.Repositories
{
    public interface IOrderRepository:IRepository<Order>
    {
        public Order GetOrderDetails(Guid OrderId);
    }
}
