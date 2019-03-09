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
    public class ProductController : Controller
    {
        public int PageSize = 10;
        private readonly IProductRepository repositoryProduct;
        private readonly ISupplierRepository repositorySupplier;
        private readonly IOrderRepository repositoryOrder;
        private readonly IItemOrderRepository repositryItemOrder;

        public ProductController()
        {

        }

        public ProductController(IProductRepository repo, ISupplierRepository repoSup, IOrderRepository repoOrder,
            IItemOrderRepository repoItem)
        {
            repositoryProduct = repo;
            repositorySupplier = repoSup;
            repositoryOrder = repoOrder;
            repositryItemOrder = repoItem;
        }

        public ViewResult ProductList(int page = 1)
        {
            ProductListViewModel model = new ProductListViewModel
            {
                Products = repositoryProduct.Products
                .Where(p => p.Active == true)
                .OrderBy(p => p.ProductId)               
                .Skip((page - 1) * PageSize)
                .Take(PageSize),

                pagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = repositoryProduct.Products.Count()
                }
            };

            return View(model);
        }

        public ViewResult DiscontinuedList(int page = 1)
        {
            ProductListViewModel model = new ProductListViewModel
            {
                Products = repositoryProduct.Products
                .Where(p => p.Active == false)
                .OrderBy(p => p.ProductId)
                .Skip((page - 1) * PageSize)
                .Take(PageSize),

                pagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = repositoryProduct.Products.Count()
                }
            };

            return View(model);
        }
    }
}