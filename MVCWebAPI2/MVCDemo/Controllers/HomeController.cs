﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDemo.Controllers
{
    public class HomeController : Controller
    {
        public string Index()
        {
            return "Hi Hemansh Welcome To MCV Web Page!!!";
        }

        public string Index1(int? id)
        {
            return $"Index1 :{id}";
        }
    }
}