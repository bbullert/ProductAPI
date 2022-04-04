using ProductAPI.Data.Repositories;

namespace ProductAPI.Data
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository Products { get; }
        Task CommitAsync();
    }
}