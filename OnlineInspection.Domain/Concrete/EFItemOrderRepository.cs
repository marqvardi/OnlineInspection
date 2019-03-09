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
            get { return context.ItemOrders; }
        }

        public void SaveProblem(ItemOrder itemOrder)
        {
            if (itemOrder.ProductId == 0)
            {
                context.ItemOrders.Add(itemOrder);
            }
            else
            {
                //ItemOrder Dbentry = context.itemOrders.Find(itemOrder.ProductId);
                // if (Dbentry != null)
                // {
                ItemOrder Dbentry = new ItemOrder();
                Dbentry.ProductId = itemOrder.ProductId;
                Dbentry.OrderId = itemOrder.OrderId;                   
               // }
            }
            context.SaveChanges();
        }
    }
}
