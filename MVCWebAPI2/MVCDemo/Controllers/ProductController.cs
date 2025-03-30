using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCDemo.Models;

namespace MVCDemo.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            Product product = new Product() { Id = 1, Name = "Samsung", Price = 10500 };
            return View(product);
           
        }
        public ActionResult Index1()
        {
            return View();
        }
    }
}