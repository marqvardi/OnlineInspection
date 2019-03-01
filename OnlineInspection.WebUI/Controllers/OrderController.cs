using OnlineInspection.Domain.Abstract;
using OnlineInspection.Domain.Entities;
using OnlineInspection.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineInspection.WebUI.Controllers
{
    public class OrderController : Controller
    {
        public int PageSize = 10;
        private readonly IOrderRepository repositoryOrder;
        private readonly ISupplierRepository repositorySupplier;
        private readonly IItemOrderRepository repositoryItemOrder;
        private readonly IProductRepository repositoryProduct;

        public OrderController(IOrderRepository repo, ISupplierRepository RepoSupplier,
             IProductRepository repoProduct, IItemOrderRepository repoItemOrder)
        {
            repositoryOrder = repo;
            repositorySupplier = RepoSupplier;
            repositoryItemOrder = repoItemOrder;
            repositoryProduct = repoProduct;
        }

        public ViewResult Index(int page = 1)
        {
            List<Order> orders = repositoryOrder.Orders.ToList();
            List<Supplier> sup = repositorySupplier.Suppliers.ToList();

            var model = from o in orders
                        join s in sup
                        on o.SupplierId equals s.SupplierId into os
                        from s in os.DefaultIfEmpty()
                        select new OrderListViewModel
                        {
                            order = o,
                            Supplier = s,
                            PagingInfo = new PagingInfo
                            {
                                CurrentPage = page,
                                ItemsPerPage = PageSize,
                                TotalItems = repositoryOrder.Orders.Count()
                            }
                        };
            return View(model);
        }     

        public ViewResult Details(int id)
        {        
            List<ItemOrder> itemOrders = repositoryItemOrder.itemOrders.Where(o => o.OrderId == id).ToList();

            return View(itemOrders);
        }

        public ViewResult ItemOrder(int id, int page = 1)
        {
            var model = from i in repositoryItemOrder.itemOrders
                        join p in repositoryProduct.Products on i.ProductId equals p.ProductId into ip
                        where i.OrderId == id
                        from p in ip.DefaultIfEmpty()
                        select new ItemOrderListViewModel
                        {
                            itemOrder = i,
                            product = p,
                            pagingInfo = new PagingInfo
                            {
                                CurrentPage = page,
                                ItemsPerPage = PageSize,
                                TotalItems = repositoryOrder.Orders.Count()
                            }
                        };
            return View(model);
        }

        //public ViewResult List(int page = 1)
        //{
        //    OrderListViewModel model = new OrderListViewModel
        //    {
        //        Orders = repositoryOrder.Orders

        //        .OrderBy(o => o.SupplierId)
        //        .Skip((page - 1) * PageSize)
        //        .Take(PageSize),

        //        pagingInfo = new PagingInfo
        //        {
        //            CurrentPage = page,
        //            ItemsPerPage = PageSize,
        //            TotalItems = repositoryOrder.Orders.Count()
        //        },
        //        Suppliers = repositorySupplier.Suppliers
        //    };

        //    return View(model);
        //}
    }
}





