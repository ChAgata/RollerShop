using RollerShop.Concrete;
using RollerShop.Entities;
using RollerShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RollerShop.Controllers
{
    public class CartController : Controller
    {
        EFDbContext db = new EFDbContext();
        public ViewResult Index(string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = GetCart(),
                ReturnUrl = returnUrl
            });
        }
        public RedirectToRouteResult AddToCart(int? productId, string returnUrl)
        {
            Product product = (from item in db.Products
                                where item.IdProduct == productId
                                select item).FirstOrDefault();
            if (product!=null)
            {
               GetCart().AddItem(product, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
        public RedirectToRouteResult RemoveFromCart(int productId, string returnUrl)
        {
            Product product = (from item in db.Products
                               where item.IdProduct == productId
                               select item).FirstOrDefault();
            if (product != null)
            {
                GetCart().RemoveLine(product);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
        private Cart GetCart()
        {
            Cart cart = (Cart)Session["Cart"];
            if (cart == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }
    }
}