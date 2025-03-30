using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FiltersDemo.Controllers
{
   // [Authorize]
    public class HomeController : Controller
    {
        // GET: Home
       
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }
     
        public ActionResult Index1()
        {
            return View();
        }
        [RequireHttps]
       
        public ActionResult Index2()
        {
            return View();
        }
        [HttpGet]
        [ChildActionOnly]
        public PartialViewResult GetPatialContain()
        {
            return PartialView("_PratialView");
        }

    }
}