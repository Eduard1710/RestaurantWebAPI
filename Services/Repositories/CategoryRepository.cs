using RestaurantWebAPI.Contexts;
using RestaurantWebAPI.Entities;

namespace RestaurantWebAPI.Services.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly RestaurantContext _context;
        public CategoryRepository(RestaurantContext context) : base(context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public Category GetCategoryDetails(Guid categoryId)
        {
            return _context.Categories
                .Where(b => b.ID == categoryId && (b.Deleted == false || b.Deleted == null))
                .FirstOrDefault();
        }
    }
}
