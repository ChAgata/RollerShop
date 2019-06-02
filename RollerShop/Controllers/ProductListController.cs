using RollerShop.Concrete;
using RollerShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RollerShop.Controllers
{
    public class ProductListController : Controller
    {
        // GET: ProductList
        EFDbContext db = new EFDbContext();
        public ActionResult Index()
        {
             var productList = (from item in db.Products orderby item.Name
                                join cat in db.Categories on item.IdCategory equals cat.IdCategory
                                join mak in db.Makers on item.IdMaker equals mak.IdMaker
                                select new AllObjects {Product=item, Maker=mak, Category = cat }).ToList();
            
            return View(productList);
        }

    public ActionResult DetailProduct(int? id)
        {
            var detailProduct = (from item in db.Products
                                 orderby item.Name
                                 join cat in db.Categories on item.IdCategory equals cat.IdCategory
                                 join mak in db.Makers on item.IdMaker equals mak.IdMaker
                                 where item.IdProduct == id
                                 select new AllObjects { Product = item, Maker = mak, Category = cat }).FirstOrDefault();
            return View(detailProduct);
        }
    public ViewResult List(string category)
        {
            var categoryView = (from item in db.Products
                                orderby item.Name
                                join cat in db.Categories on item.IdCategory equals cat.IdCategory
                                join mak in db.Makers on item.IdMaker equals mak.IdMaker
                                where cat.Name ==category
                                select new AllObjects { Product = item, Maker = mak, Category = cat }).ToList();
            ViewBag.Category = category;
            return View(categoryView);
        }
    }
}