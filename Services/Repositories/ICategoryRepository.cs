using RestaurantWebAPI.Entities;

namespace RestaurantWebAPI.Services.Repositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Category GetCategoryDetails(Guid categoryId); 
    }
}
