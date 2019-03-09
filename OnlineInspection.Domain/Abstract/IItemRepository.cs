using OnlineInspection.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineInspection.Domain.Abstract
{
    public interface IItemRepository
    {
        IEnumerable<Items> items { get; }

        void SaveProblem(Items items);
        //Product DeleteProduct(int productId);
    }
}
