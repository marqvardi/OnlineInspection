using System.Collections.Generic;
using System.Linq;

namespace OnlineInspection.Domain.Entities
{
    public class Cart
    {
        private List<CartLine> lineCollection = new List<CartLine>();

        public void AddItem(Product product, int quantity)
        {
            if (quantity == 0)
            {
                RemoveLine(product);
                return;
            }

            CartLine line = lineCollection.Where(p => p.Product.ProductId == product.ProductId)
                .FirstOrDefault();
            if (line == null)
            {
                lineCollection.Add(new CartLine { Product = product, Quantity = quantity });
            }
            else
            {
                line.Quantity = quantity;
            }
        }

        private void RemoveLine(Product product)
        {
            var productToRemove = lineCollection.Where(p => p.Product.ProductId == product.ProductId)
                .FirstOrDefault();

            lineCollection.Remove(productToRemove);
        }

        public decimal ComputeTotalValue()
        {
            return lineCollection.Sum(p => p.Product.Price * p.Quantity);
        }

        public IEnumerable<CartLine> Lines
        {
            get { return lineCollection; }
        }

        public void Clear()
        {
            lineCollection.Clear();
        }

    }
}
