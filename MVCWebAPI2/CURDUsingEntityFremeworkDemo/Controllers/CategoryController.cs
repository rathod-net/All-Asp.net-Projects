using CURDUsingEntityFremeworkDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CURDUsingEntityFremeworkDemo.Controllers
{
    public class CategoryController : Controller
    {
        ProductDbContext dbContext = new ProductDbContext();
        // GET: Category
        public ActionResult Index()
        {
           List<Category> categories= dbContext.Categories.ToList();
            
            return View(categories);
        }
    }
}