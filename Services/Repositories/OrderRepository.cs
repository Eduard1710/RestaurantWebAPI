using Microsoft.EntityFrameworkCore;
using RestaurantWebAPI.Contexts;
using RestaurantWebAPI.Entities;

namespace RestaurantWebAPI.Services.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        private readonly RestaurantContext _context;
        public OrderRepository(RestaurantContext context) : base(context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Order GetOrderDetails(Guid OrderId)
        {
            return _context.Orders
                .Where(o => o.ID == OrderId && (o.Deleted == false || o.Deleted == null))
                .Include(o => o.User)
                .Include(o=>o.OrderMenu)
                .FirstOrDefault();
        }
    }
}
