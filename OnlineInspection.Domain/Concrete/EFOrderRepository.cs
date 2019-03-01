using OnlineInspection.Domain.Abstract;
using OnlineInspection.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineInspection.Domain.Concrete
{
    public class EFOrderRepository : IOrderRepository
    {
        private readonly EFDbContext context = new EFDbContext();

        public IEnumerable<Order> Orders
        {
            get { return context.Orders; }
        }
    }
}
