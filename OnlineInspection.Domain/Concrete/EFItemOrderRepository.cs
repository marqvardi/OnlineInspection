using OnlineInspection.Domain.Abstract;
using OnlineInspection.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineInspection.Domain.Concrete
{
    public class EFItemOrderRepository : IItemOrderRepository
    {
        private readonly EFDbContext context = new EFDbContext();

        public IEnumerable<ItemOrder> itemOrders
        {
            get { return context.itemOrders; }
        }
    }
}
