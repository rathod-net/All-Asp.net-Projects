using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUDUsingWebApi_Client_MVC5_.Controllers
{
    public class CategoryJSController : Controller
    {
        // GET: CategoryJS
        public ActionResult Index()
        {
            return View();
        }

        // GET: CategoryJS/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CategoryJS/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryJS/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryJS/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CategoryJS/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryJS/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CategoryJS/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
