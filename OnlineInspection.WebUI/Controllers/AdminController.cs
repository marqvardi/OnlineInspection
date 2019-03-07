using OnlineInspection.Domain.Abstract;
using OnlineInspection.Domain.Entities;
using OnlineInspection.WebUI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
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
            //if (ModelState.IsValid)
            //{
            var file = Request.Files["imagem"];

            if (file.FileName == "")
            {
                repositoryProduct.SaveProductNoImage(product);
                TempData["Message"] = string.Format("{0} has been saved.",
                    product.ProductCode);
                return RedirectToAction("List", "Product");

            }
            var originalExtension = Path.GetExtension(file.FileName);
            var tempFileName = Path.ChangeExtension(Path.GetFileName(Path.GetTempFileName()), originalExtension);

            product.Image = tempFileName;
            file.SaveAs(Server.MapPath($"~/IMG/{tempFileName}"));

            repositoryProduct.SaveProduct(product);
            TempData["Message"] = string.Format("{0} has been saved.",
                product.ProductCode);
            return RedirectToAction("List", "Product");
            //}
            //else
            //{
            //    //Something wrong with values
            //    return View(product);
            //}
        }

        public ViewResult CreateProduct()
        {
            return View(new Product());
        }

        [HttpPost]
        public ActionResult CreateProduct(Product product)
        {
            var file = Request.Files["imagem"];
            var originalExtension = Path.GetExtension(file.FileName);
            var tempFileName = Path.ChangeExtension(Path.GetFileName(Path.GetTempFileName()), originalExtension);

            product.Image = tempFileName;
            file.SaveAs(Server.MapPath($"~/IMG/{tempFileName}"));

            // if (ModelState.IsValid)
            //{
            repositoryProduct.SaveProduct(product);
            TempData["Message"] = string.Format("{0} has been created.",
                product.ProductCode);
            return RedirectToAction("List", "Product");
            //// }
            // else
            // {
            //     //Something wrong with values
            //     return View(product);
            // }
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

        //Not in use
        //public ViewResult OrderDetails(int id)
        //{
        //    IEnumerable<ItemOrder> itemOrders = repositoryItemOrder.itemOrders.Where(o => o.OrderId == id).ToList();

        //    IEnumerable<ItemOrder> itemOrders1 = itemOrders
        //        .GroupBy(p => p.ProductId)
        //        .Select(group => group.First());

        //    return View(itemOrders1);
        //}


        public ViewResult ItemOrder(int id, int page = 1)
        {
            IEnumerable<ItemOrder> itemOrders = repositoryItemOrder.itemOrders.Where(o => o.OrderId == id).ToList();

            IEnumerable<ItemOrder> itemOrders1 = itemOrders
                .GroupBy(p => p.ProductId)
                .Select(group => group.First());


            var model = from i in itemOrders1
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

        public ViewResult ProblemItemList(int id, int productId, int page = 1)
        {
            var model = from i in repositoryItemOrder.itemOrders
                        join p in repositoryProduct.Products on i.ProductId equals p.ProductId into ip
                        join o in repositoryOrder.Orders on i.OrderId equals o.OrderId
                        where (i.OrderId == id && i.ProductId == productId)
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


        public ActionResult AddNewInspectionDetail()
        {
            return View();
        }

        public ActionResult CreateOrder()
        {
            //Order order = new Order();
            //Supplier supplier = new Supplier();

            //supplier.Contact = "Maria";
            //supplier.Email = "wdwadwa@fass.com";
            //supplier.CompanyName = "Empresa nome aqui";
            //order.ChinaInvoice = "China invoice numero aqui";
            //order.SMReference = "PRocesso 2.000";

            //OrderListViewModel o = new OrderListViewModel
            //{
            //    order = order,
            //    Supplier = supplier,                 
            //};
                        
            return View(new OrderListViewModel());
        }

        //[HttpPost]
        //public ActionResult AddNewInspectionDetail(ItemOrder item)
        //{
        //    if (ModelState.IsValid)
        //    {

        //    }
        //}

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