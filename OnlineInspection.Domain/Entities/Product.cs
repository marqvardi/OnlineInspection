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

        [Display(Name = "Product code")]
        [Required(ErrorMessage = "A code is required.")]
        public string ProductCode { get; set; }

        [Required(ErrorMessage = "A description is required.")]
        public string Description { get; set; }

        //[Required(ErrorMessage = "An image is required.")]
        public string Image { get; set; } = "None";

        public bool Active { get; set; }
        public double CartonWidth { get; set; } = 0;

        public double CartonHeight { get; set; } = 0;
        public double CartonDeep { get; set; } = 0;
        public double NetKgs { get; set; } = 0;
        public double Grosskgs { get; set; } = 0;
        // [Range(0.01, double.MaxValue, ErrorMessage = "Enter a positive number.")]
        public decimal Price { get; set; } = 0;
        public int QtyPerCarton { get; set; } =0;

        public int SupplierId { get; set; }
    }
}
