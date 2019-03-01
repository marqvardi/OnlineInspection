using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineInspection.Domain.Entities
{
    [Table("Suppliers")]
    public class Supplier
    {
        public int SupplierId { get; set; }

        [Display(Name ="Company name")]
        [Required(ErrorMessage ="A company name is required.")]
        public string CompanyName { get; set; }

        [Required(ErrorMessage ="A contact name is required.")]
        public string Contact { get; set; }

        [Required(ErrorMessage ="An email is required.")]
        [DataType(DataType.EmailAddress)]        
        public string Email { get; set; }

        public List<Order> Orders { get; set; }
    }
}
