using OnlineInspection.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineInspection.WebUI.Models
{
    public class ItemOrderListViewModel
    {
        public ItemOrder itemOrder { get; set; }
        public Product product { get; set; }
        public Items items { get; set; }

        public PagingInfo pagingInfo { get; set; }

        public IEnumerable<Items> Items { get; set; }
        public IEnumerable<ItemOrder> ItemOrders { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}