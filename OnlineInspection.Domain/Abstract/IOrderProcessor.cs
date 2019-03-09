using OnlineInspection.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineInspection.Domain.Abstract
{
    public interface IOrderProcessor
    {
        void ProcessOrder(Cart cart, Supplier supplier);
    }
}
