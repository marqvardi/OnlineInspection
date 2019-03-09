using OnlineInspection.Domain.Abstract;
using OnlineInspection.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineInspection.Domain.Concrete
{
    public class EmailOrderProcessor : IOrderProcessor
    {
        public void ProcessOrder(Cart cart, Supplier supplier)
        {
            throw new NotImplementedException();
        }
    }
}
