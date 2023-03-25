using RestaurantWebAPI.Services.Repositories;

namespace RestaurantWebAPI.Services.UnitsOfWork
{
    public interface IOrderUnitOfWork : IDisposable
    {
        IOrderRepository Orders { get; }
        int Complete();
    }
}
