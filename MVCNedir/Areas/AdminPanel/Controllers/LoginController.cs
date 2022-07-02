using MVCNedir.Models;
using MVCNedir.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCNedir.Areas.AdminPanel.Controllers
{
    public class LoginController : Controller
    {
        AdimAdimDBModel db = new AdimAdimDBModel();

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(ManagerViewModel model)
        {
            if (ModelState.IsValid)
            {
                int sayi = db.Managers.Count(s => s.Email == model.Mail && s.Password == model.Password);
                if (sayi > 0)
                {
                    Manager m = db.Managers.First(s => s.Email == model.Mail && s.Password == model.Password);
                    Session["manager"] = m;
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(model);
        }
    }
}