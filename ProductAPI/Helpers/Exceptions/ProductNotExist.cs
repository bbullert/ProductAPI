using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductAPI.Helpers.Exceptions
{
    public class ProductNotExist : Exception
    {
        public ProductNotExist()
        {

        }

        public ProductNotExist(string message) : base(message)
        {

        }

        public ProductNotExist(Guid id) : base($"The product with an id: \"{id}\" doesn't exist.")
        {

        }
    }
}
