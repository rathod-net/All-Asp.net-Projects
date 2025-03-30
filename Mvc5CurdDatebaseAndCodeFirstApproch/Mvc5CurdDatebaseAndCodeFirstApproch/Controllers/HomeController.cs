using Mvc5CurdDatebaseAndCodeFirstApproch.Models;
using Mvc5CurdDatebaseAndCodeFirstApproch.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace Mvc5CurdDatebaseAndCodeFirstApproch.Controllers
{
    public class HomeController : Controller
    {
        RegisterUserDbContext dbContext = new RegisterUserDbContext();
        // GET: Home

        [HttpGet]
        public ActionResult Index( )
        {
            List<RegisterUser> registerusers = dbContext.registerUsers.ToList();
            return View(registerusers);

        }

        [HttpGet]
        public ActionResult Details(int? Id)
        {
            if(Id!=null)
            {
                RegisterUser user = dbContext.registerUsers.FirstOrDefault(x => x.Id==Id);
                return View(user);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int? Id)
        {
            if(Id!=null)
            {

                RegisterUser users = dbContext.registerUsers.FirstOrDefault(x => x.Id == Id);

                return View(users);
            }
           return RedirectToAction("Index");


        }
        [HttpPost]
        public ActionResult Edit(RegisterUser user)
        {
            if (ModelState.IsValid)
            {
                if(user!=null)
                { 
                //dbContext.registerUsers.Add(user);

                dbContext.Entry(user).State=EntityState.Modified;
                dbContext.SaveChanges();
                return RedirectToAction("Index");
                    }
            }
            return View(user);
        }

        [HttpGet]
    
        public ActionResult Delete(int? Id)
        {
            var user = dbContext.registerUsers.Find(Id);
            return View(user);
            
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteComfirmed(int? Id)
        {
            //User users = new User();
            var user = dbContext.registerUsers.Find(Id);
            if (user != null)
            {
                dbContext.registerUsers.Remove(user);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            
            return View(user);
        }


        [HttpGet]
        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp(RegisterUser user)
        {
            if (ModelState.IsValid)
            {
                if (dbContext.registerUsers.Any(x => x.Username == user.Username))
                {
                    ViewBag.Notification = "This Account has already Existed";
                    return View();
                }
                else
                {
                    dbContext.registerUsers.Add(user);
                    dbContext.SaveChanges();

                    //Session["UserIdSS"] = user.Id.ToString();
                    //Session["UserNameSS"] = user.Username.ToString();
                    return RedirectToAction("Login","Home");
                }
            }
            return View();
        }
        
       
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(RegisterUser user)
        {
            var checklogin = dbContext.registerUsers.Where(x => x.Username.Equals(user.Username)
            && x.Password.Equals(user.Password)).FirstOrDefault();
            if (checklogin != null)
            {

                Session["UserIdSS"] = user.Id.ToString();
                Session["UserNameSS"] = user.Username.ToString();
                return RedirectToAction("Index");
            }
            else
            {
               
                    ViewBag.Notificationlogin = "Wrong Username And Password.";
              
                
            }
            return View();
        }
       

    }
}