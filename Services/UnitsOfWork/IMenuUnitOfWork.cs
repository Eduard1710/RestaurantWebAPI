using RestaurantWebAPI.Services.Repositories;

namespace RestaurantWebAPI.Services.UnitsOfWork
{
    public interface IMenuUnitOfWork : IDisposable
    {
        ICategoryRepository Categories { get; }
        IMenuRepository Menus { get; }
        int Complete();
    }
}
