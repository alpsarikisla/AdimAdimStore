using MVCNedir.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCNedir.Controllers
{
    public class HomeController : Controller
    {
        AdimAdimDBModel db = new AdimAdimDBModel();
        // GET: Home
        public ActionResult Index()
        {
            List<Product> products = db.Products.Where(x=> x.SellStatus==true).ToList();
            return View(products);
        }
    }
}