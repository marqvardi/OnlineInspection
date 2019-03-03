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
    public class AdminController : Controller
    {
        public int PageSize = 10;
        private readonly IOrderRepository repositoryOrder;
        private readonly ISupplierRepository repositorySupplier;
        private readonly IItemOrderRepository repositoryItemOrder;
        private readonly IProductRepository repositoryProduct;

        public AdminController(IOrderRepository repo, ISupplierRepository RepoSupplier,
             IProductRepository repoProduct, IItemOrderRepository repoItemOrder)
        {
            repositoryOrder = repo;
            repositorySupplier = RepoSupplier;
            repositoryItemOrder = repoItemOrder;
            repositoryProduct = repoProduct;
        }

        public ViewResult EditProduct(int ProductId)
        {
            Product product = new Product();
            product = repositoryProduct.Products.FirstOrDefault(p => p.ProductId == ProductId);

            return View(product);
        }

        [HttpPost]
        public ActionResult EditProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                repositoryProduct.SaveProduct(product);
                TempData["Message"] = string.Format("{0} has been saved.",
                    product.ProductCode);
                return RedirectToAction("List", "Product");
            }
            else
            {
                //Something wrong with values
                return View(product);
            }
        }

        public ViewResult CreateProduct()
        {
            return View(new Product());
        }

        [HttpPost]
        public ActionResult CreateProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                repositoryProduct.SaveProduct(product);
                TempData["Message"] = string.Format("{0} has been created.",
                    product.ProductCode);
                return RedirectToAction("List", "Product");
            }
            else
            {
                //Something wrong with values
                return View(product);
            }
        }

        [HttpPost]
        public ActionResult DeleteProduct(int productId)
        {
            Product deleteProduct = repositoryProduct.DeleteProduct(productId);
            if (deleteProduct != null)
            {
                TempData["Message"] = string.Format("{0} was deleted.", deleteProduct.ProductCode);
            }
            return RedirectToAction("List", "Product");
        }

        public ViewResult EditSupplier(int supplierId)
        {
            Supplier supplier = new Supplier();
            supplier = repositorySupplier.Suppliers.FirstOrDefault(s => s.SupplierId == supplierId);

            return View(supplier);
        }

        [HttpPost]
        public ActionResult EditSupplier(Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                repositorySupplier.SaveSupplier(supplier);
                TempData["Message"] = string.Format("The company {0} has been saved.",
                    supplier.CompanyName);
                return RedirectToAction("List", "Supplier");
            }
            else
            {
                //Something wrong with values
                return View(supplier);
            }
        }

        public ViewResult CreateSupplier()
        {
            return View(new Supplier());
        }

        [HttpPost]
        public ActionResult CreateSupplier(Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                repositorySupplier.SaveSupplier(supplier);
                TempData["Message"] = string.Format("A new company named {0} has been created.",
                    supplier.CompanyName);
                return RedirectToAction("List", "Supplier");
            }
            else
            {
                //Something wrong with values
                return View(supplier);
            }
        }

        [HttpPost]
        public ActionResult DeleteSupplier(int supplierId)
        {
            Supplier deleteSupplier = repositorySupplier.DeleteSupplier(supplierId);
            if (deleteSupplier != null)
            {
                TempData["Message"] = string.Format("{0} was deleted.", deleteSupplier.CompanyName);
            }
            return RedirectToAction("List", "Supplier");
        }        

        public ViewResult OrderList(int page = 1)
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

        public ViewResult OrderDetails(int id)
        {
            List<ItemOrder> itemOrders = repositoryItemOrder.itemOrders.Where(o => o.OrderId == id).ToList();

            return View(itemOrders);
        }

        public ViewResult ItemOrder(int id, int page = 1)
        {
            var model = from i in repositoryItemOrder.itemOrders
                        join p in repositoryProduct.Products on i.ProductId equals p.ProductId into ip
                        where i.OrderId == id                        
                        orderby i.ProductId 
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

        public ViewResult TabelaTeste(int id, int page = 1)
        {
            var model = from p in repositoryProduct.Products
                        join i in repositoryItemOrder.itemOrders on p.ProductId equals i.ProductId 
                        where i.ProductId == id 
                        orderby i.ProductId                       
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


        //[HttpPost]
        //public ActionResult Search(string text)
        //{
        //    Product searchProduct = new Product
        //    {
        //        Description = text,
        //        ProductCode = text
        //    };            

        //    Product found = repository.SearchProduct(searchProduct);

        //    if (found != null)
        //    {

        //    }

        //    return RedirectToAction("List", "Product");

        //}
    }
}