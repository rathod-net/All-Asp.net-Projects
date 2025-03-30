using DatabaseConnectionUsingAdonet.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;

namespace DatabaseConnectionUsingAdonet.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        [HttpGet]
        public ActionResult Index(string search)
        {
            List<Category> categories =
                new List<Category>();
            // ado.net to read all categories from category table
            string connectionString =
                "server=113.193.63.106,55010;database=B24ADONETDB;user id=b24;password=b24";

            //SqlConnection connection = new SqlConnection();
            //connection.ConnectionString = connectionString;

            SqlConnection connection = null;

            try
            {
                connection = new SqlConnection(connectionString);

                string query = "uspGetCategories";

                //if (string.IsNullOrEmpty(search))
                //{
                //    query = "select * from Category";
                //}
                //else
                //{
                //    query = $"select * from Category where Name like '%{search}%'";
                //}

                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Search", search);

                connection.Open(); // connection is open and available
                SqlDataReader reader = cmd.ExecuteReader(); // command executed

                if (reader != null)
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Category category = new Category()
                            {
                                Id = (int)reader["Id"],
                                Name = reader["Name"].ToString(),
                                Rating = (int)reader["Rating"]
                            };

                            categories.Add(category);
                        }
                    }
                }
            }
            catch
            {
                return View(categories);
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }

            return View(categories);
        }

        [HttpGet]
        public ActionResult Details(int? id)
        {
            Category category = GetCategoryById(id);

            return View(category);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Category category)
        {
            string connectionString =
                "server=113.193.63.106,55010;database=B24ADONETDB;user id=b24;password=b24";

            SqlConnection connection = null;

            try
            {
                connection = new SqlConnection(connectionString);

                string query = $"insert into Category values('{category.Name}', {category.Rating})";
                SqlCommand cmd = new SqlCommand(query, connection);

                connection.Open(); // connection is open and available

                int numberOfRowsAffected = cmd.ExecuteNonQuery();

                if (numberOfRowsAffected > 0)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Message = "Create failed";
                    return View(category);
                }
            }
            catch
            {
                return View(category);
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }

            return View(category);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            Category category = GetCategoryById(id);

            return View(category);
        }

        [HttpPost]
        public ActionResult Edit(Category category)
        {
            string connectionString =
                "server=113.193.63.106,55010;database=B24ADONETDB;user id=b24;password=b24";

            SqlConnection connection = null;

            try
            {
                connection = new SqlConnection(connectionString);

                string query = $"update Category set Name = '{category.Name}', Rating = {category.Rating} where Id = {category.Id}";
                SqlCommand cmd = new SqlCommand(query, connection);

                connection.Open(); // connection is open and available

                int numberOfRowsAffected = cmd.ExecuteNonQuery();

                if (numberOfRowsAffected > 0)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Message = "Update failed";
                    return View(category);
                }
            }
            catch
            {
                return View(category);
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }

            return View(category);
        }

        private Category GetCategoryById(int? id)
        {
            Category category = new Category();

            string connectionString =
                "server=113.193.63.106,55010;database=B24ADONETDB;user id=b24;password=b24";

            SqlConnection connection = null;

            try
            {
                connection = new SqlConnection(connectionString);

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
                            category = new Category()
                            {
                                Id = (int)reader["Id"],
                                Name = reader["Name"].ToString(),
                                Rating = (int)reader["Rating"]
                            };
                            break;
                        }
                    }
                }

                return category;
            }
            catch
            {
                return category;
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
        public ActionResult Delete(int? id)
        {
            Category category = GetCategoryById(id);
            return View(category);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int? Id)
        {
            Category category = GetCategoryById(Id);

            string connectionString =
                 "server=113.193.63.106,55010;database=B24ADONETDB;user id=b24;password=b24";

            SqlConnection connection = null;

            try
            {
                connection = new SqlConnection(connectionString);

                string query = $"delete from Category where Id = {Id}";
                SqlCommand cmd = new SqlCommand(query, connection);

                connection.Open(); // connection is open and available

                int numberOfRowsAffected = cmd.ExecuteNonQuery();

                if (numberOfRowsAffected > 0)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Message = "Update failed";
                    return View(category);
                }
            }
            catch
            {
                return View(category);
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }
    }
}