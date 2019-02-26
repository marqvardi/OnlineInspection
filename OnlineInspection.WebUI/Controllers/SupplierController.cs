﻿using OnlineInspection.Domain.Abstract;
using OnlineInspection.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineInspection.WebUI.Controllers
{
    public class SupplierController : Controller
    {
        private readonly ISupplierRepository repository;
        public int PageSize = 10;

        public SupplierController(ISupplierRepository repo)
        {
            repository = repo;
        }

        // GET: Supplier
        public ActionResult Index()
        {
            return View();
        }

        public ViewResult List(int page =1)
        {
            SupplierListViewModel model = new SupplierListViewModel
            {
                Suppliers = repository.Suppliers
                            .OrderBy(p => p.SupplierId)
                            .Skip((page - 1) * PageSize)
                            .Take(PageSize),

                pagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = repository.Suppliers.Count()
                }
            };

            return View(model);
        }
    }
}