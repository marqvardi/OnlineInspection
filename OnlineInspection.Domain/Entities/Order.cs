using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineInspection.Domain.Entities
{
    [Table("Orders")]
    public class Order
    {
        public int OrderId { get; set; }
        public int SupplierId { get; set; }
        public string SMReference { get; set; }
        public string ChinaInvoice { get; set; }     

        List<ItemOrder> itemOrders { get; set; }
    }
}
