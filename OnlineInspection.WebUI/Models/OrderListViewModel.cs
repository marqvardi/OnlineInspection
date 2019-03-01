using OnlineInspection.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineInspection.WebUI.Models
{
    public class OrderListViewModel
    {
        public Order order { get; set; }
        public Supplier Supplier { get; set; }

        public PagingInfo PagingInfo { get; set; }
        
        public IEnumerable<Order> Orders { get; set; }
        public IEnumerable<Supplier> Suppliers { get; set; }        
        //public IEnumerable<OrderList> orderLists { get; set; }

        //public IEnumerable<ItemOrder> itemOrders { get; set; }

    }
}