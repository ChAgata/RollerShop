using RollerShop.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RollerShop.Controllers
{
    public class NavController : Controller
    {
        // GET: Nav
        public PartialViewResult Menu()
        {
            EFDbContext db = new EFDbContext();
            var categories = (from item in db.Categories
                              orderby item.Name
                              select item).ToList();
            return PartialView(categories);
        }
    }
}