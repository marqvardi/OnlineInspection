using OnlineInspection.Domain.Abstract;
using OnlineInspection.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineInspection.WebUI.Controllers
{
    public class AdminController : Controller
    {
        private readonly IProductRepository repository;
        private readonly ISupplierRepository repositorySupplier;

        public AdminController(IProductRepository repo, ISupplierRepository repo1)
        {
            repository = repo;
            repositorySupplier = repo1;
        }

        public ViewResult EditProduct(int ProductId)
        {
            Product product = new Product();
            product = repository.Products.FirstOrDefault(p => p.ProductId == ProductId);

            return View(product);
        }

        [HttpPost]
        public ActionResult EditProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                repository.SaveProduct(product);
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
                repository.SaveProduct(product);
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
            Product deleteProduct = repository.DeleteProduct(productId);
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