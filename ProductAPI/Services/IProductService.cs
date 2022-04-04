using ProductAPI.Models;

namespace ProductAPI.Services
{
    public interface IProductService
    {
        Task<Guid> CreateProduct(Product product);
        Task<IEnumerable<Product>> GetAllProducts();
        Task<Product?> GetProductById(Guid id);
        Task RemoveProduct(Guid id);
        Task SetExampleDataAsync();
        Task UpdateProduct(Guid id, Product updated);
    }
}