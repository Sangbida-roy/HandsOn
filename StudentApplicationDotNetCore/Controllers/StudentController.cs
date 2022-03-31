using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using StudentApplicationDotNetCore.BO;
using StudentApplicationDotNetCore.DAL;

namespace StudentApplicationDotNetCore.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentDAL _studentDAL;
        public StudentController()
        {
            _studentDAL = new StudentDAL();
        }

        public ActionResult GetAllStudents()
        {
            var students = _studentDAL.GetStudents();
            return View("~/Views/Student/Student.cshtml", students);
        }

       
        [HttpPost] //post data from ui to server
        public ActionResult CreateStudent(StudentBO student)
        {
            if (!string.IsNullOrEmpty(student.FN) && !string.IsNullOrEmpty(student.LN) && student.RollNo != null)
            {
                _studentDAL.CreateStudent(student);

                return RedirectToAction("GetAllStudents");
            }
            else
            {
                ViewBag.ValidationError = "Please Fill the required details";
            }
            return View(new StudentBO());

        }

        [HttpGet] //read anything from ui
        public ActionResult CreateStudent()
        {

            return View(new StudentBO());
        }

       
        [HttpGet]
        public ActionResult EditStudent(int id)
        {
            var student = _studentDAL.GetStudentById(id);
            return View(student);

        }
        [HttpPost]
        public ActionResult EditStudent(StudentBO student)
        {
            if (!string.IsNullOrEmpty(student.FN) && !string.IsNullOrEmpty(student.LN) && student.RollNo != null && student.Id > 0)
            {
                _studentDAL.UpdateStudentById(student);
                return RedirectToAction("GetAllStudents");
            }
            else
            {
                ViewBag.ValidationErrors = "Please fill First Name, Last Name & Roll Number.";
            }
            return View(new StudentBO());
        }

        public ActionResult Delete(int id)
        {
            StudentDAL student = new StudentDAL();
            student.DeleteStudentById(id);
            return RedirectToAction("GetAllStudents");
        }

    }
}
