using MVCNedir.Filters;
using MVCNedir.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCNedir.Areas.AdminPanel.Controllers
{
    [AdminPanelAuthenticationFilter]
    public class ProductController : Controller
    {
        AdimAdimDBModel db = new AdimAdimDBModel();
        // GET: AdminPanel/Product
        public ActionResult Index()
        {
            return View(db.Products.ToList());
        }
        public ActionResult IndexActiveProduct()
        {
            return View(db.Products.Where(x => x.SellStatus == true).ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Category_ID = new SelectList(db.Categories, "ID", "Isim");
            ViewBag.Brand_ID = new SelectList(db.Brands, "ID", "Isim");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product model, HttpPostedFileBase resim)
        {
            if (ModelState.IsValid)
            {
                if (resim != null)
                {
                    FileInfo fi = new FileInfo(resim.FileName);
                    if (fi.Extension == ".jpg" || fi.Extension == ".png" || fi.Extension == ".jpeg")
                    {
                        string isim = Guid.NewGuid().ToString() + fi.Extension;
                        model.ImagePath = isim;
                        resim.SaveAs(Server.MapPath("~/ProductImages/" + isim));
                    }
                    else
                    {
                        model.ImagePath = "noneproduct.jpg";
                    }
                }
                else
                {
                    model.ImagePath = "noneproduct.jpg";
                }
                model.CreationTime = DateTime.Now;
                db.Products.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Category_ID = new SelectList(db.Categories, "ID", "Isim");
            ViewBag.Brand_ID = new SelectList(db.Brands, "ID", "Isim");
            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            Product p = db.Products.Find(id);
            ViewBag.Category_ID = new SelectList(db.Categories, "ID", "Isim", p.Category_ID);
            ViewBag.Brand_ID = new SelectList(db.Brands, "ID", "Isim", p.Brand_ID);
            return View(p);
        }
        [HttpPost]
        public ActionResult Edit(Product p, HttpPostedFileBase resim)
        {
            if (ModelState.IsValid)
            {
                db.Entry(p).State = System.Data.Entity.EntityState.Modified;

                if (ModelState.IsValid)
                {
                    if (resim != null)
                    {
                        FileInfo fi = new FileInfo(resim.FileName);
                        if (fi.Extension == ".jpg" || fi.Extension == ".png" || fi.Extension == ".jpeg")
                        {
                            string isim = Guid.NewGuid().ToString() + fi.Extension;
                            p.ImagePath = isim;
                            resim.SaveAs(Server.MapPath("~/ProductImages/" + isim));
                        }
                        else
                        {
                            p.ImagePath = "noneproduct.jpg";
                        }
                    }
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            ViewBag.Category_ID = new SelectList(db.Categories, "ID", "Isim", p.Category_ID);
            ViewBag.Brand_ID = new SelectList(db.Brands, "ID", "Isim", p.Brand_ID);
            return View(p);
        }
        public ActionResult Delete(int id)
        {
            Product p = db.Products.Find(id);
            p.SellStatus = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}