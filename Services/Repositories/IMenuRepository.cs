using RestaurantWebAPI.Entities;

namespace RestaurantWebAPI.Services.Repositories
{
    public interface IMenuRepository:IRepository<Menu>
    {
        public Menu GetMenuDetails(Guid MenuId);
    }
}
