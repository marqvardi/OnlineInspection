using OnlineInspection.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineInspection.Domain.Abstract
{
    public interface IProductRepository
    {
        IEnumerable<Product> Products { get; }

        void SaveProduct(Product product);
        void SaveProductNoImage(Product product);
        Product DeleteProduct(int productId);
       // Product SearchProduct(Product text);
    }
}
