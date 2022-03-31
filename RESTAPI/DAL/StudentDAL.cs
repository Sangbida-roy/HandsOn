using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RESTAPI.DB;
using RESTAPI.BO;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace RESTAPI.DAL
{
    public class StudentDAL : IStudentDAL
    {
        private readonly TrainingDbContext _db;
        private readonly ILogger<StudentDAL> _logger;

        public StudentDAL(TrainingDbContext db, ILogger<StudentDAL> logger)
        {
            _db = db;
            _logger = logger;
        }

        public IEnumerable<StudentBO> GetStudents()
        {
            return _db.Student.Select(x => new StudentBO
            {
                ID = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                BranchId = x.BranchId,
                BranchName = x.Branch.Name

            }).ToList();
        }
        public StudentBO GetStudent(int id)
        {
            return _db.Student.Select(x => new StudentBO
            {
                ID = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                BranchId = x.BranchId,
                BranchName = x.Branch.Name

            }).FirstOrDefault();
        }

        //create student
        public bool CreateStudent(StudentBO student)
        {
            var success = true;
            try
            {
                _db.Student.Add(new Student
                {
                    FirstName = student.FirstName,
                    LastName = student.LastName,
                    RollNo = (int)student.RollNo,
                    Marks = (decimal)student.Marks,


                });
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                success = false;
                throw;
            }
            return success;
        }


        //edit student 
        public bool EditStudent(StudentBO student)
        {
            try
            {
                var st = _db.Student.Where(x => x.Id == student.ID).FirstOrDefault();
                st.FirstName = student.FirstName;
                st.LastName = student.LastName;
                st.RollNo = (int)student.RollNo;
                st.Marks = (decimal)student.Marks;
                _db.Student.Add(st);
                _db.Entry(st).State = EntityState.Modified; //Whenever we edit the entry
                _db.SaveChanges();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
                return false;
            }
            return true;
        }

        //delete student by id
        public bool DeleteStudentById(int id)
        {
            try
            {
                var students = _db.Student.Where(x => x.Id == id);
                _db.Student.RemoveRange(students);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
                return false;
            }
            return true;
        }
    }
}
