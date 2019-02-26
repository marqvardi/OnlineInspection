using OnlineInspection.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineInspection.WebUI.Models
{
    public class ProductListViewModel
    {
        public PagingInfo pagingInfo { get; set; }

        public IEnumerable<Product> Products { get; set; }

    }
}