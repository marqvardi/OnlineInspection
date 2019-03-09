using OnlineInspection.Domain.Abstract;
using OnlineInspection.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineInspection.Domain.Concrete
{
    public class EFProductRepository : IProductRepository
    {
        private readonly EFDbContext context = new EFDbContext();
        
        public IEnumerable<Product> Products
        {
            get { return context.Products; }
        }

        public Product DeleteProduct(int productId)
        {
            Product DbEntry = context.Products.Find(productId);
            if (DbEntry != null)
            {
                context.Products.Remove(DbEntry);
                context.SaveChanges();
            }
            return DbEntry;
        }

        public void SaveProductNoImage(Product product)
        {
            if (product.ProductId == 0)
            {
                context.Products.Add(product);
            }
            else
            {
                Product Dbentry = context.Products.Find(product.ProductId);
                if (Dbentry != null)
                {
                    Dbentry.ProductCode = product.ProductCode;
                    Dbentry.Description = product.Description;
                    Dbentry.Active = product.Active;
                    Dbentry.CartonDeep = product.CartonDeep;
                    Dbentry.CartonHeight = product.CartonHeight;
                    Dbentry.CartonWidth = product.CartonWidth;
                    Dbentry.Grosskgs = product.Grosskgs;
                    Dbentry.NetKgs = product.NetKgs;
                    Dbentry.Price = product.Price;
                    Dbentry.QtyPerCarton = product.QtyPerCarton;
                }
            }
            context.SaveChanges();
        }

        public void SaveProduct(Product product)
        {
            if (product.ProductId == 0)
            {
                context.Products.Add(product);                
            }
            else
            {
                Product Dbentry = context.Products.Find(product.ProductId);
                if (Dbentry != null)
                {
                    Dbentry.ProductCode = product.ProductCode;
                    Dbentry.Description = product.Description;
                    Dbentry.Image = product.Image;
                    Dbentry.Active = product.Active;
                    Dbentry.CartonDeep = product.CartonDeep;
                    Dbentry.CartonHeight = product.CartonHeight;
                    Dbentry.CartonWidth = product.CartonWidth;
                    Dbentry.Grosskgs = product.Grosskgs;
                    Dbentry.NetKgs = product.NetKgs;
                    Dbentry.Price = product.Price;
                }
            }
            context.SaveChanges();
        }

        //public Product SearchProduct(Product product)
        //{
        //    Product Dbentry = context.Products.Contains(product);
        //    if (Dbentry != null)
        //    {
        //        Dbentry.ProductCode = text.ProductCode;
        //        Dbentry.Description = text.Description;
        //        Dbentry.Image = text.Image;
        //    }

        //    return Dbentry;
        //}
    }
}
