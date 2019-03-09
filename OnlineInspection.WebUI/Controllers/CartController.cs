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
    public class CartController : Controller
    {
        private IProductRepository repositoryProduct;
        private IOrderProcessor repositoryOrderProcessor;

        public CartController(IProductRepository repo, IOrderProcessor repo1 )
        {
            repositoryProduct = repo;
            repositoryOrderProcessor = repo1;
        }

        // GET: Cart
        public ActionResult Index(Cart cart, string returnUrl)
        {
            return View(
                new CartIndexViewModel { Cart = cart, ReturnUrl = returnUrl });
        }

        public PartialViewResult Summary()
        {
            if (Session["Cart"] == null)
            {
                Session["Cart"] = new Cart();
            }
 
            return PartialView(Session["Cart"]);
        }

        ////Old version without email being sent
        //public ViewResult Checkout()
        //{
        //    return View(new ShippingDetails());
        //}
        
       //public ViewResult Checkout()
       // {
       //     return View(new ShippingDetails());
       // }


        [HttpPost]
        public ViewResult Checkout(Cart cart, Supplier supplier)
        {
            if (cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your cart is empty");
            }
            if (ModelState.IsValid)
            {
                repositoryOrderProcessor.ProcessOrder(cart, supplier);
                cart.Clear();
                return View("Completed");
            }
            else
            {
                return View(supplier);
            }
         }

        //[Route("Cart/AddtoCart")]
        public ActionResult AddToCart(int productId, int? qty = 0)
        {
            Product product = repositoryProduct.Products.FirstOrDefault(p => p.ProductId == productId);
            Cart cart = Session["Cart"] as Cart;
            cart.AddItem(product, qty.Value);

            return Json(new AddToCartResult
            {
                Items = cart.Lines.Count(),
                Total = cart.ComputeTotalValue().ToString("C2")
            });
        }


        //Deppois que adicionou na Global.asax, nao precisou mais disso abaixo.
        //private Cart GetCart()
        //{
        //    Cart cart = (Cart)Session["Cart"];
        //    if (cart == null)
        //    {
        //        cart = new Cart();
        //        Session["Cart"] = cart;
        //    }
        //    return cart;
        //}
    }
}