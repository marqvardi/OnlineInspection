using OnlineInspection.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineInspection.Domain.Abstract
{
    public interface IItemOrderRepository
    {
        IEnumerable<ItemOrder> itemOrders { get; }

        void SaveProblem(ItemOrder itemOrder);
        //Product DeleteProduct(int productId);
    }
}
