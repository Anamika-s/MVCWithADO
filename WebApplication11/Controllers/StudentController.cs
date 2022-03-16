using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication11.Models;

namespace WebApplication11.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            ViewBag.msg = "Hello";
            ViewData["Date"] = DateTime.Now.ToString();
            return View();
           
        }
        public ActionResult StudentDetails()
        {
            Student student = new Student()
            { Id = 1, Name = "Ajay", Batch = "B001" };
            ViewBag.student = student;
            return View();
        }


        public ActionResult StudentDetails1()
        {
            Student student = new Student()
            { Id = 1, Name = "Ajay", Batch = "B001" };
            
            return View(student);
        }

        public ActionResult StudentList()
        {
            List<Student> studentlist = null;
            studentlist = new List<Student>
             {
                 new Student(){ Id = 1, Name = "Ajay", Batch = "B001" },
                 new Student(){ Id = 2, Name = "Ajay", Batch = "B001" },
new Student(){ Id = 1, Name = "Ajay", Batch = "B001" }
             };
            ViewBag.student = studentlist;
            return View();
        }

        public ActionResult StudentList1()
        {
            List<Student> studentlist = null;
            studentlist = new List<Student>
             {
                 new Student(){ Id = 1, Name = "Ajay", Batch = "B001" },
                 new Student(){ Id = 2, Name = "Ajay", Batch = "B001" },
new Student(){ Id = 1, Name = "Ajay", Batch = "B001" }
             };
            
            return View(studentlist);
        }

    }
}