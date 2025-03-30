using CURDUsingEntityFrameworkDatabaseFirstApproch.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CURDUsingEntityFrameworkDatabaseFirstApproch.Controllers
{
    public class CategoryController : Controller
    {
        ProductDbContext db = new ProductDbContext();
       
        // GET: Category
        public ActionResult Index()
        {
            List<Category> categories = db.Categories.ToList();
         
            
                
            return View(categories);
        }

        [HttpGet]
        public ActionResult GetProductsBySubCategory(int? productId)
        {
                var products = db.Categories.SelectMany(c => c.SubCategories).
                    SelectMany(sc => sc.Products).
                    FirstOrDefault(p => p.ProductId == productId);
            //var products = db.products.where(p => p.productid == productid)
            //                          .select(p => new { p.productid, p.productname, p.price, p.subcategoryid });

            return View(products);
        }

    }
}