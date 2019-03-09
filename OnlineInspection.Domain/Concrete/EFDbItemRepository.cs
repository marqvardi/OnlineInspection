using OnlineInspection.Domain.Abstract;
using OnlineInspection.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineInspection.Domain.Concrete
{
    public class EFDbItemRepository : IItemRepository
    {
        private readonly EFDbContext context = new EFDbContext();

        public IEnumerable<Items> items
        {
            get { return context.Items; }
        }

        public void SaveProblem(Items items)
        {
            throw new NotImplementedException();
        }
    }
}
