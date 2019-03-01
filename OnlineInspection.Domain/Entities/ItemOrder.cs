using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineInspection.Domain.Entities
{
    [Table("ItemOrder")]
    public class ItemOrder
    {
        public int ProductId { get; set; }
        public int OrderId { get; set; }
        [Key]
        public string DescriptionProblem { get; set; }
        public string PictureProblem { get; set; }

        //public List<Product> Products { get; set; }
    }
}
