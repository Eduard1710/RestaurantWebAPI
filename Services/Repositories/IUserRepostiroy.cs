using RestaurantWebAPI.Entities;

namespace RestaurantWebAPI.Services.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        IEnumerable<User> GetAdminUsers();
    }
}
