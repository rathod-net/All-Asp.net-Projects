﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUDUsingWebApi_Client_MVC5_.Models
{
    public class Category
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public int Rating { get; set; }
    }
}