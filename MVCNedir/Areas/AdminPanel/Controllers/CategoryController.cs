using MVCNedir.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCNedir.Areas.AdminPanel.Controllers
{
    public class CategoryController : Controller
    {
        AdimAdimDBModel db = new AdimAdimDBModel();
        
        public ActionResult Index()
        {
            List<Category> categories = db.Categories.ToList();
            return View(categories);
        }

        [HttpGet]//Sayfa açılırken bu metot çalışır
        public ActionResult Ekle()
        {
            return View();
        }

        //Sayfada herhangi bir işlem yapıldığında Örn Butona Basıldığında bu metot çalışır
        [HttpPost]
        public ActionResult Ekle(Category c)
        {
            if (ModelState.IsValid)
            {
                db.Categories.Add(c);
                db.SaveChanges();
            }
            else
            {
                return View(c);
            }

            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Duzenle(int? id)
        {
            if (id== null)
            {
                return RedirectToAction("Index");
            }
            Category c = db.Categories.Find(id);
            if (c== null)
            {
                return RedirectToAction("Index");
            }
            return View(c);
        }
        [HttpPost]
        public ActionResult Duzenle(Category c)
        {
            if (ModelState.IsValid)
            {
                db.Entry(c).State = System.Data.Entity.EntityState.Modified;
                //Category old = db.Categories.Find(c.ID);
                //old.Isim = c.Isim;
                //old.Aciklama = c.Aciklama;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(c);
        }
        public ActionResult Sil(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            Category c = db.Categories.Find(id);
            if (c == null)
            {
                return RedirectToAction("Index");
            }
            db.Categories.Remove(c);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}