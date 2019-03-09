using OnlineInspection.Domain.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineInspection.WebUI.Models
{
    public class OrderListViewModel 
    {
        public Order Order { get; set; }
        public Supplier Supplier { get; set; }
        public Product Product { get; set; }
        public ItemOrder ItemOrder { get; set; }
        public Items items { get; set; }

        public PagingInfo pagingInfo { get; set; }
        
        public IEnumerable<Order> Orders { get; set; }
        public IEnumerable<Supplier> Suppliers { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<Items> Items { get; set; }

        public List<Product> products { get; set; }
        public List<Supplier> suppliers { get; set; }
       
    }
}