using MVCNedir.Models;
using MVCNedir.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace MVCNedir.Controllers
{
    public class ProductModel
    {
        public string MerchantCode { get; set; }
        public string MerchandPassword { get; set; }
        public string CardNo { get; set; }
        public string ExpM { get; set; }
        public string ExpY { get; set; }
        public string CVV { get; set; }
        public decimal Price { get; set; }
    }
    public class BuyProductController : Controller
    {
        AdimAdimDBModel db = new AdimAdimDBModel();
        // GET: BuyProduct
        [HttpGet]
        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Home");
            }
            Product p = db.Products.Find(id);
            if (p == null)
            {
                return RedirectToAction("Index", "Home");
            }
            ViewBag.Product = p;
            return View();
        }
        [HttpPost]
        public ActionResult Index(BuyProductViewModel model, int id)
        {
            Product p = db.Products.Find(id);
            if (ModelState.IsValid)
            {
               
                try
                {
                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri("https://localhost:44327/API/PayService");
                        ProductModel requestModel = new ProductModel()
                        {
                            MerchantCode = "Af587x952",
                            MerchandPassword = "14fr58ew",
                            CardNo = model.CardNumber,
                            ExpM = model.ReqM,
                            ExpY = model.ReqY,
                            CVV = model.Cvv,
                            Price = Convert.ToDecimal(p.Price)
                        };
                        var posttask = client.PostAsJsonAsync<ProductModel>("PayService", requestModel);
                        posttask.Wait();
                        var result = posttask.Result;
                        if (result.IsSuccessStatusCode)
                        {
                            var strinResp = result.Content.ReadAsStringAsync();
                            if (strinResp.Result == "\"101\"")
                            {
                                return RedirectToAction("PaySuccess", "BuyProduct");
                            }
                            else if (strinResp.Result == "\"501\"")
                            {
                                ViewBag.Result = "Bakiye Yetersiz";
                            }
                        }
                        //var stringContent = new StringContent(JsonConvert.SerializeObject(requestModel),UnicodeEncoding.UTF8, "application/json");
                        //var check = stringContent.ReadAsStringAsync().GetAwaiter().GetResult();
                        //var posttask = client.PostAsync("https://localhost:44327/API/PayService", stringContent);
                        //posttask.Wait();
                        //var result = posttask.Result;

                    }
                }
                catch (Exception ex)
                {

                }
            }
            ViewBag.Product = p;
            return View();
        }
        public ActionResult PaySuccess()
        {
            return View();
        }
    }
}