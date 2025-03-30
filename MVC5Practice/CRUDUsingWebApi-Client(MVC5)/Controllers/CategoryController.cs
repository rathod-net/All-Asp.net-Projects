using CRUDUsingWebApi_Client_MVC5_.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Text;
using System.Web.Mvc;

namespace CRUDUsingWebApi_Client_MVC5_.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        HttpClient client;
        public CategoryController()
        {
            client = new HttpClient();
            string apiUrl = ConfigurationManager.AppSettings["apiUrl"];
            client.BaseAddress = new Uri(apiUrl);
        }
      
        public ActionResult Index()
        {
            List<Category> categoties = new List<Category>();

            // api baseUrl => https://localhost:44374/

          //  HttpClient client = new HttpClient();
          //  client.BaseAddress = new Uri("https://localhost:44374/api/");

           HttpResponseMessage response= client.GetAsync("category").Result;
            if (response.IsSuccessStatusCode)
            {
                string jsonResult= response.Content.ReadAsStringAsync().Result;
                ViewBag.Response = jsonResult;
                categoties = JsonConvert.DeserializeObject<List<Category>>(jsonResult);
            }

            client.Dispose();
            return View(categoties);
        }
     
        public ActionResult Details(int? id)
        {
           
             Category category = new Category();
             category=GetById(id);
             return View(category);
          
        }
        [NonAction]
        public Category GetById(int? id)
        {
            Category category = new Category();
          //  HttpClient client = new HttpClient();
         //   client.BaseAddress = new Uri("https://localhost:44374/api/");
            HttpResponseMessage response = client.GetAsync($"category/{id}").Result;
            if (response.IsSuccessStatusCode)
            {
                string jsonResult = response.Content.ReadAsStringAsync().Result;
                ViewBag.Response = jsonResult;
                category = JsonConvert.DeserializeObject<Category>(jsonResult);
                client.Dispose(); 
            }
            return category;
        }

            [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Category category)
        {
         //   HttpClient client = new HttpClient();

         //   client.BaseAddress=new Uri("https://localhost:44374/api/");

            string request=JsonConvert.SerializeObject(category);

            StringContent requestBody =new 
                StringContent(request,Encoding.UTF8,"application/json");

            HttpResponseMessage response = 
                client.PostAsync("category", requestBody).Result;

            if(response.IsSuccessStatusCode)
            {
                client.Dispose();
                return RedirectToAction("Index");
            }
            ViewBag.Massage = "Create api Failed";
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
                Category category = new Category();
                category = GetById(id);
                return View(category);
        }
        [HttpPost]
        public ActionResult Edit(Category category)
        {
          //  HttpClient client =new HttpClient();
        //    client.BaseAddress = new Uri("https://localhost:44374/api/");
            string request = JsonConvert.SerializeObject(category);

            StringContent requestBody = new
                StringContent(request, Encoding.UTF8, "application/json");

            HttpResponseMessage response =
                client.PutAsync($"category/{category.Id}", requestBody).Result;

            if (response.IsSuccessStatusCode)
            {
                client.Dispose();
                return RedirectToAction("Index");
            }
            ViewBag.Massage = "Create api Failed";
            return View();
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
              Category category = GetById(id);
              return View(category);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int? id)
        {
            Category category = new Category();
         //   HttpClient client = new HttpClient();
         //   client.BaseAddress = new Uri("https://localhost:44374/api/");

            HttpResponseMessage response =
                client.DeleteAsync($"category/{id}").Result;

            if (response.IsSuccessStatusCode)
            {
                client.Dispose();
                return RedirectToAction("Index");
            }
            client.Dispose();
            ViewBag.Massage = "Create api Failed";
            return View();
        }
    }
}
