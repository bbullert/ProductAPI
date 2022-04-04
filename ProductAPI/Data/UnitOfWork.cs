using ProductAPI.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductAPI.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApiDbContext context;
        private IProductRepository productRepository;

        public UnitOfWork(ApiDbContext context)
        {
            this.context = context;
            productRepository = new ProductRepository(context);
        }

        public IProductRepository Products => productRepository;

        public async Task CommitAsync()
        {
            await context.SaveChangesAsync();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
