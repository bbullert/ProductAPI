using ProductAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductAPI.Data.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(ApiDbContext appDbContext) : base(appDbContext)
        {

        }

        private ApiDbContext? Context => context as ApiDbContext;
    }
}
