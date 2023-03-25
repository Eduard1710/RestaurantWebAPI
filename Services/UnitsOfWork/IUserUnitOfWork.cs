using RestaurantWebAPI.Services.Repositories;

namespace RestaurantWebAPI.Services.UnitsOfWork
{
    public interface IUserUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        int Complete();
    }
}
