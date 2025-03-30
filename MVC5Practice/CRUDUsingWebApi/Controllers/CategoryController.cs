using CRUDUsingWebApi.Models.DBContext;
using CRUDUsingWebApi.Models.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace CRUDUsingWebApi.Controllers
{
  //  [RoutePrefix("api/category")]
    public class CategoryController : ApiController
    {
        CategoryDbContext db;
        public CategoryController()
        {
            db = new CategoryDbContext();
        }
        //[Route("")]
        //public IEnumerable<string> GetName()
        //{
        //    return new List<string>() { "Hemansh", "Sneha" };
        //}
        //[Route("{id:int}")]
        //public string GetName(int id,int sid)
        //{
        //    return $"{id},{sid}:Sonu";
        //}

        //[Route("GetName2/{sid:int}")]
        //public string GetName2(int sid)
        //{
        //    return $"{sid}:Anu";
        //}


        [HttpGet]
        [ResponseType(typeof(IEnumerable<Category>))]
      
        public IHttpActionResult GetAllCategories()
        {
            var category = db.Categories.ToList();
            return Ok(category);
            
        }
        [HttpGet]
        // [Route("GetCategoryById/{id:int}")]
        [ResponseType(typeof(Category))]
        public IHttpActionResult GetCategoryById([FromUri]int id)
        {
            if(id>0)
            {
                var category = db.Categories.Find(id);
                if(category!=null)
                {
                    return Ok(category);
                }
                else
                {
                    return NotFound();
                }
            }
            return BadRequest("Category Id Should Greater Than zero");
        }

        [HttpPost]
        public IHttpActionResult CreateCategory([FromBody] Category category)
        {
            if(category!=null)
            {
                db.Categories.Add(category);
                db.SaveChanges();
                return Created("DefualtApi", category);
            }
            return BadRequest("No Category Given");
        }

        [HttpPut]
        public IHttpActionResult UpdateCategory([FromUri] int id, [FromBody]Category category)
        {
            if(id>0)
            {
               
                if(id == category.Id)
                {
                    var cat = db.Categories.Find(id);
                    if(cat!=null)
                    { 
                    cat.Name = category.Name;
                    cat.Rating = category.Rating;
                        db.SaveChanges();
                   // db.Entry(cat).State = EntityState.Modified;
                        return Ok(cat);
                    }
                    else
                    {
                        return NotFound();
                    }

                }
                else
                {
                    return BadRequest("Category Id Not Equal to given Id");
                }
            }
            return BadRequest("Category Id should Greater than 0");
        }

        [HttpDelete]
       
        public IHttpActionResult DeleteCategory([FromUri] int id)
        {
            if(id>0)
            {
                var cat = db.Categories.Find(id);
                if(cat!=null)
                {
                    db.Categories.Remove(cat);
                    db.SaveChanges();
                    return Ok(cat);
                }
                else
                {
                    return NotFound();
                }
                
            }
            return BadRequest("Category Id Not Greater than 0");
        }

       
    }
}
