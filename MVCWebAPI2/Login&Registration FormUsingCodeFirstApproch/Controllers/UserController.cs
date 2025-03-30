using Login_Registration_FormUsingCodeFirstApproch.Models;
using Login_Registration_FormUsingCodeFirstApproch.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Login_Registration_FormUsingCodeFirstApproch.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        UserDbContext dbContext;
        public UserController()
        {
            dbContext = new UserDbContext();
        }
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ListOFUser()
        {
            List<User> users = dbContext.users.ToList();
            return View(users);
        }

        [HttpGet]
        public ActionResult CreateUser()
        {

            return View();
        }
        [HttpPost]
        public ActionResult CreateUser(User user)
        {
            if (ModelState.IsValid)
            {
                dbContext.users.Add(user);
                dbContext.SaveChanges();
                return RedirectToAction("ListOFUser");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Datails(int? Id)
        {
            if (Id != null) 
            {
                User users = dbContext.users.FirstOrDefault(x => x.Id == Id);

                return View(users);
            }

            return RedirectToAction("ListOFUser");
        }
        [HttpGet]
        public ActionResult Edit(int? Id)
        {

           User users = dbContext.users.FirstOrDefault(u => u.Id == Id);

            return View(users);
        }
        [HttpPost]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                dbContext.users.Add(user);
                dbContext.SaveChanges();
                return RedirectToAction("ListOFUser");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Delete(int? Id)
        {
            //User users = new User();
            var user = dbContext.users.Find(Id);
            if(user != null) { 
            dbContext.users.Remove(user);
            dbContext.SaveChanges();
            }
            return RedirectToAction("ListOFUser");
        }
    }
}