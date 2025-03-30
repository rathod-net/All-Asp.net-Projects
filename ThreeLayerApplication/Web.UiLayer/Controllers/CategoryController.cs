using CategoryBAL;
using CategoryModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.UiLayer.Controllers
{
    public class CategoryController : Controller
    {
        ICategoryBL _categoryBL;
        public CategoryController(ICategoryBL categoryBL)
        {
            _categoryBL = categoryBL;
        }
        // GET: Category
        public ActionResult Index()
        {
            var categories = _categoryBL.GetAll();
            
            return View(categories);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View(); 
        }
        [HttpPost]
        public ActionResult Create(CategoryViewModel category)
        {
             _categoryBL.Create(category);
            return RedirectToAction("Index");
        }
    }
}