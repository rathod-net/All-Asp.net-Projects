using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using CRUDUsingWebApi.Models.Entities;

namespace CRUDUsingWebApi.Models.DBContext
{
    public class CategoryDbContext : DbContext
    {
        public CategoryDbContext(): base("name=WebApiCategoryDb")
        {

        }
        public DbSet<Category> Categories { get; set; }
    }
}