using MVCDemo.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDemo.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {

            List<Employee> employees = new List<Employee>();
            if (Session["employees"] == null)
            {
                employees = new List<Employee>()
            {
            new Employee(){ Id= 1, Name = "Hemansh",City="Mumbai",MobileNo=15975,DeptName="Admin"},
            new Employee(){ Id= 2, Name = "Sneha",City="Pune",MobileNo=951753,DeptName="HR"},
             new Employee(){ Id= 3, Name = "Bhushan",City="Hydrabad",MobileNo=456789,DeptName="Admin"},
              new Employee(){ Id= 4, Name = "Ashok",City="Washim",MobileNo=456123,DeptName="IT"},
              new Employee(){ Id= 5, Name = "Savita",City="Digras",MobileNo=321123,DeptName="HR"},
              new Employee(){ Id= 6, Name = "Prashant",City="Pune",MobileNo=656987,DeptName="IT"},
            };

                Session["employees"] = employees;
            }
            else
            {

                employees = (List<Employee>)Session["employees"];
            }

            return View(employees);
        }
        [HttpGet]
        public ActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            if (Session["employees"] != null)
            {
                List<Employee> employees = (List<Employee>)Session["employees"];
                employees.Add(employee);
                Session["employees"] = employees;
                return RedirectToAction("Index");
            }

            return View();
        }
        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (Session["employees"] != null)
            {
                List<Employee> employees = (List<Employee>)Session["employees"];
                Employee employee = employees.FirstOrDefault(e => e.Id == id);


                return View(employee);
            }
            return RedirectToAction("index");
        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (Session["employees"] != null)
            {
                List<Employee> employees = (List<Employee>)Session["employees"];
                Employee employee = employees.FirstOrDefault(e => e.Id == id);
                return View(employee);
            }
            return RedirectToAction("index");
        }
        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
            if (Session["employees"] != null)
            {
                List<Employee> employees = (List<Employee>)Session["employees"];
                foreach (Employee emp in employees)
                {
                    if (emp.Id == employee.Id)
                    {
                        emp.Id = employee.Id;
                        emp.Name = employee.Name;
                        emp.City = employee.City;
                        emp.MobileNo = employee.MobileNo;
                        emp.DeptName = employee.DeptName;
                        break;
                    }

                }
                Session["employees"] = employees;
                return RedirectToAction("Index");

            }
            List<Employee> employees1 = (List<Employee>)Session["employees"];
            Employee emp1 = employees1.FirstOrDefault(e => e.Id == employee.Id);
            return View(emp1);

        }
        [HttpGet]
        public ActionResult Delete(int? id)
        {

            if (Session["employees"] != null)
            {
                List<Employee> employees = (List<Employee>)Session["employees"];
                Employee employee = employees.FirstOrDefault(e => e.Id == id);


                return View(employee);
            }
            return RedirectToAction("index");
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int? id)
        {
            if (Session["employees"] != null)
            {
                List<Employee> employees = (List<Employee>)Session["employees"];
                Employee employee = employees.FirstOrDefault(e => e.Id == id);
                employees.Remove(employee);
                Session["employees"] = employees;
                return RedirectToAction("Index");
            }
            List<Employee> employees1 = (List<Employee>)Session["employees"];
            Employee emp1 = employees1.FirstOrDefault(e => e.Id == id);
            return View(emp1);

        }

        [HttpGet]
        public ActionResult Admin()
        {
            // List<Employee> employees2 = new List<Employee>();
            if (Session["employees2"] == null)
            {
                //employees2 = new List<Employee>()
                //{
                //new Employee(){ Id= 1, Name = "Hemansh",City="Mumbai",MobileNo=15975,DeptName="Admin"},
                //new Employee(){ Id= 2, Name = "Sneha",City="Pune",MobileNo=951753,DeptName="HR"},
                //new Employee(){ Id= 3, Name = "Bhushan",City="Hydrabad",MobileNo=456789,DeptName="Admin"},
                //new Employee(){ Id= 4, Name = "Ashok",City="Washim",MobileNo=456123,DeptName="IT"},
                //};
                List<Employee> employees2 = (List<Employee>)Session["employees"];
                // Employee employee = employees2.FirstOrDefault(e => e.Id == id);
                var adminEmployees = employees2.Where(e => e.DeptName == "Admin");

                Session["adminEmployees"] = adminEmployees;
                return View(adminEmployees);
            }

            return RedirectToAction("index");
        }
        [HttpGet]
        public ActionResult HR()
        {
            if (Session["employees2"] == null)
            {
                List<Employee> employees2 = (List<Employee>)Session["employees"];
                var adminEmployees = employees2.Where(e => e.DeptName == "HR");

                Session["adminEmployees"] = adminEmployees;
                return View(adminEmployees);
            }
            return RedirectToAction("index");

        }
        public ActionResult IT()
        {
            if (Session["employees2"] == null)
            {
                List<Employee> employees2 = (List<Employee>)Session["employees"];
                var adminEmployees = employees2.Where(e => e.DeptName == "IT");

                Session["adminEmployees"] = adminEmployees;
                return View(adminEmployees);
            }
            return RedirectToAction("index");

        }
    }
}



