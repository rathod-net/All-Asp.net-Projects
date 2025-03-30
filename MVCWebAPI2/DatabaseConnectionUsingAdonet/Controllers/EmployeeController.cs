using DatabaseConnectionUsingAdonet.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlTypes;


namespace DatabaseConnectionUsingAdonet.Controllers
{

    public class EmployeeController : Controller
    {
        // GET: Employee
        [HttpGet]
        public ActionResult Index()
        {
            List<Employee> employees= new List<Employee>();

            string connectionString =
                "server=113.193.63.106,55010;database=B24ADONETDB;user id=b24;password=b24";

            // now using SqlConnection Class bind the connection string in the object of that class
            SqlConnection connection=new SqlConnection(connectionString);
            connection.Open();
            // now you want to write a query of sql

            string query = "Select * From Employee";
           
            // now We use to prepare and execute query
            SqlCommand cmd = new SqlCommand(query, connection);
            // now open connection with server
            // connection is open and available
            SqlDataReader reader = cmd.ExecuteReader(); // command executed
            

            //now use SqlCommand class method for executeing the query and that 
            // method are ExecuteReader(),	ExecuteNonQuery(),	
            // ExecuteScalar()-it return single value it will any datatype 
            // ExecuteReader()- it return SqlDataReader object of SqlCommand Class or it returns table,
            // ExecuteNonQuery()- it return int value


            // now all data store in reader object it will that data into our view 
            // and give all validation if data is null 
            if (reader != null)
            {
                if (reader.HasRows)
                {
                    while(reader.Read())
                    {
                        Employee emp=new Employee()
                        {
                                Eid = (int)reader["Eid"],
                                EName = reader["EName"].ToString(),
                                Mid = (int)reader["Mid"]
                        };
                        employees.Add(emp);
                    }
                    connection.Close();
                }
            }

            connection.Close();
            return View(employees);
        }

        private Employee GetEmployeeById(int? id)

        {
            Employee employee = new Employee();

            string conectionString =
                "server=113.193.63.106,55010;database=B24ADONETDB;user id=b24;password=b24";
           
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(conectionString);

                string query = $"select * from Category where Id = {id}";
                SqlCommand cmd = new SqlCommand(query, connection);

                connection.Open(); // connection is open and available
                SqlDataReader reader = cmd.ExecuteReader(); // command executed

                if (reader != null)
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Employee emp = new Employee()
                            {
                                Eid = (int)reader["Eid"],
                                EName = reader["EName"].ToString(),
                                Mid = (int)reader["Mid"]
                            };
                            break;
                        }
                        
                    }
                }
                return employee;
            }
            catch
            {
                return employee;
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }

        [HttpGet]
        public ActionResult Details(int? id)
        {
            Employee employee=GetEmployeeById(id);
            return View();  
        }

    }
}