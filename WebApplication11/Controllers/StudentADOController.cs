using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
// Step 1
using System.Data.SqlClient;
using WebApplication11.Models;

namespace WebApplication11.Controllers
{
    public class StudentADOController : Controller
    {
        // GET: StudentADO
        // CRUD operations
        // 
        SqlConnection connection;
        SqlCommand command;
        string GetConnectionString()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            return connectionString;
        }
        SqlConnection GetConnection()
        {
            connection = new SqlConnection(GetConnectionString()); 
            return connection;
             
        }
        public ActionResult Index()
        {
            connection = GetConnection();
            command = new SqlCommand("Select * from student");
            command.Connection = connection;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<Student> list = new List<Student>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {

                    Student student = new Student()
                    {
                        Id = (int)reader[0],
                        Name = reader[1].ToString(),
                        Batch = reader[2].ToString()
                    };
                    list.Add(student);
                }
            }
            else
            {
                ViewBag.msg = "No Records";
                return View();
            }
            connection.Close();

            return View(list);
        }


        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Student student)
        {
            using (connection = GetConnection())
            {


                using (command = new SqlCommand("Insert into Student values(@id, @name, @batch)"))
                {

                    command.Connection = connection;
                    command.Parameters.AddWithValue("@id", student.Id);
                    command.Parameters.AddWithValue("@name", student.Name);
                    command.Parameters.AddWithValue("@batch", student.Batch);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            return RedirectToAction("Index");
        }


        Student GetStudentDetailsById(int id)
        {
            Student student = null;
            connection = GetConnection();
            command = new SqlCommand("Select * from student where id=@id");
            command.Connection = connection;
            command.Parameters.AddWithValue("@id", id);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if(reader.HasRows)
            {
                reader.Read();
              student  = new Student()
                {
                    Id = id,
                    Name = reader[1].ToString(),
                    Batch = reader[2].ToString()
                };
                return student;
            }
          
            else
                return null;
        }

        public ActionResult Edit(int id)
        {
            Student student = GetStudentDetailsById(id);
            return View(student);
        }
        [HttpPost]
        public ActionResult Edit(Student student)
        {
            connection = GetConnection();
            command = new SqlCommand("update Student set batch=@batch where id=@id");

            command.Connection = connection;
            command.Parameters.AddWithValue("@id", student.Id); 
            command.Parameters.AddWithValue("@batch", student.Batch);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            Student student = GetStudentDetailsById(id);
            return View(student);
        }
        [HttpPost]
        public ActionResult Delete(Student student)
        {
            connection = GetConnection();
            command = new SqlCommand("delete Student where id=@id");

            command.Connection = connection;
            command.Parameters.AddWithValue("@id", student.Id);
              
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
            command.Dispose();
            connection.Dispose();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            Student student = GetStudentDetailsById(id);
            return View(student);


        }

    }
}