using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCNedir.Areas.AdminPanel.Controllers
{
    public class HomeController : Controller
    {
        // GET: AdminPanel/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}