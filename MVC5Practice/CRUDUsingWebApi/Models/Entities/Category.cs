using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUDUsingWebApi.Models.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string  Name { get; set; }   
        public int Rating { get; set; }
    }
}