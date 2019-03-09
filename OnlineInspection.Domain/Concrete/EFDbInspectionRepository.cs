using OnlineInspection.Domain.Abstract;
using OnlineInspection.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineInspection.Domain.Concrete
{
    public class EFDbInspectionRepository : IInspectionRepository
    {
        private readonly EFDbContext context = new EFDbContext();

        public IEnumerable<Inspection> Inspections
        {
            get { return context.Inspections; }
        }

        public void SaveProblem(Inspection inspection)
        {
            throw new NotImplementedException();
        }
    }
}
