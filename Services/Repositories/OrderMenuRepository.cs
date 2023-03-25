using Microsoft.EntityFrameworkCore;
using RestaurantWebAPI.Contexts;
using RestaurantWebAPI.Entities;
using RestaurantWebAPI.Services.Repositories;

namespace RestaurantWebAPI.Services.Repositories
{
    public class OrderMenuRepository : Repository<OrderMenu>, IOrderMenuRepository
    {
        private readonly RestaurantContext _context;
        public OrderMenuRepository(RestaurantContext context) : base(context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public OrderMenu GetOrderMenuDetails(Guid OrderMenuId)
        {
            return _context.OrderMenus
                .Where(o => o.ID == OrderMenuId && (o.Deleted == false || o.Deleted == null))
                .FirstOrDefault();
        }
    }
}