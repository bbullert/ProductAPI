using ProductAPI.Data;
using ProductAPI.Helpers.Exceptions;
using ProductAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductAPI.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task SetExampleDataAsync()
        {
            if (await unitOfWork.Products.CountAsync() == 0)
            {
                var options = new System.Text.Json.JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                var file = System.IO.File.ReadAllText("exampleData.json");
                var models = System.Text.Json.JsonSerializer.Deserialize<List<Product>>(file, options);

                if (models != null)
                {
                    await unitOfWork.Products.AddRangeAsync(models);
                    await unitOfWork.CommitAsync();
                }
            }
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await unitOfWork.Products.GetAllAsync();
        }

        public async Task<Product?> GetProductById(Guid id)
        {
            return await unitOfWork.Products.GetByIdAsync(id);
        }

        public async Task<Guid> CreateProduct(Product product)
        {
            await unitOfWork.Products.AddAsync(product);
            await unitOfWork.CommitAsync();

            return product.Id;
        }

        public async Task UpdateProduct(Guid id, Product updated)
        {
            var actual = await unitOfWork.Products.GetByIdAsync(id);

            if (actual == null)
            {
                throw new NotImplementedException();
            }

            actual.Description = updated.Description;
            actual.Quantity = updated.Quantity;
            await unitOfWork.CommitAsync();
        }

        public async Task RemoveProduct(Guid id)
        {
            var product = await unitOfWork.Products.GetByIdAsync(id);

            if (product == null)
            {
                throw new NotImplementedException();
            }

            unitOfWork.Products.Remove(product);
            await unitOfWork.CommitAsync();
        }
    }
}
