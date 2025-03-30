using CRUDUsingEnitityFrameworkDatabaseFirst.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUDUsingEnitityFrameworkDatabaseFirst.Controllers
{
    public class CategoryController : Controller
    {
        ProductDbContext db =new ProductDbContext();
        // GET: Category

        // Get Categories
        [HttpGet]
        public ActionResult Index()
        {
            List<Category> categories = db.Categories.ToList();

            return View(categories);
        }

        public JsonResult GetProductsBySubCategory(int subCategoryId)
        {
            var products = db.Products.Where(p => p.SubCategoryId == subCategoryId)
                                      .Select(p => new { p.ProductName, p.Price })
                                      .ToList();
            return Json(products, JsonRequestBehavior.AllowGet);
        }
        // Get Subcategories for a Category

    }
}
