using Microsoft.EntityFrameworkCore;
using RestaurantWebAPI.Contexts;
using RestaurantWebAPI.Entities;

namespace RestaurantWebAPI.Services.Repositories
{
    public class MenuRepository : Repository<Menu>, IMenuRepository
    {
        private readonly RestaurantContext _context;
        public MenuRepository(RestaurantContext context) : base(context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Menu GetMenuDetails(Guid MenuId)
        {
            return _context.Menus
                .Where(m => m.ID == MenuId && (m.Deleted == false || m.Deleted == null))
                .Include(m => m.Category)
                .FirstOrDefault();
        }
    }
}
