using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineInspection.Domain.Entities
{
    public class Inspection
    {
        public int InspectionId  { get; set; }
        public int ProductsId { get; set; }
        public string PictureProblem { get; set; }
        public string DescriptionProblem { get; set; }

        IEnumerable<Inspection> Inspections { get; set; }

    }
}
