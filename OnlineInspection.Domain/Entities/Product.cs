using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineInspection.Domain.Entities
{
    public class Product
    {
        public int ProductId { get; set; }

        [Display(Name ="Product code")]
        [Required(ErrorMessage = "A code is required.")]
        public string ProductCode { get; set; }

        [Required(ErrorMessage = "A description is required.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "An image is required.")]
        public string Image { get; set; }       
    }
}
