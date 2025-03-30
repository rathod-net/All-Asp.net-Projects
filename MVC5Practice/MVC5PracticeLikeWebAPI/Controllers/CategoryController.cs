using MVC5PracticeLikeWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace MVC5PracticeLikeWebAPI.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        CategoryDbEntities categoryDbEntities = new CategoryDbEntities();
        [HttpGet]
        public ActionResult Index()
        {
            if (categoryDbEntities != null)
            {
                var categories = categoryDbEntities.Categories.ToList();
                return View(categories);
            } 
                return View();
        }
        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id > 0)
            {
                var category = categoryDbEntities.Categories.Find(id);
                if (category != null)
                {
                    return View(category);
                }
                return View();
            }
            return RedirectToAction("Index");
            
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Category category)
        {
            if (category != null)
            {
                categoryDbEntities.Categories.Add(category);
                categoryDbEntities.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id > 0)
            {
                var category = categoryDbEntities.Categories.Find(id);
                if (category != null)
                {
                    category.Name = category.Name;
                    category.Rating = category.Rating;
                    return View(category);
                }
            }
            return View();
        }
        [HttpPost]
        public ActionResult Edit(Category category)
        {
            if (category != null)
            {
                categoryDbEntities.Entry(category).State = EntityState.Modified;
                categoryDbEntities.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();

        }
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id > 0)
            {
                var category = categoryDbEntities.Categories.Find(id);
                if (category != null)
                {
                    return View(category);
                }
               
            }
            return View();
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int? id)
        {

            if (id > 0)
            {
                var category = categoryDbEntities.Categories.Find(id);
                if (category != null)
                {
                    categoryDbEntities.Categories.Remove(category);
                    categoryDbEntities.SaveChanges();
                }
               
            }
            
            return RedirectToAction("Index");
        }
    }
}