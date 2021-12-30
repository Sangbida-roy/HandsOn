using Entity_Framework.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Framework.DAL
{
    public class StudentDAL : IStudentDAL
    {
        private readonly EntitiesConnectionString _db;
        public StudentDAL()
        {
            _db = new EntitiesConnectionString();
        }
        public bool CreateStudent(StudentBO student)
        {
            var success = true;
            try
            {
                var branch = student.Branch;
                int? branchId = null;
                if (!string.IsNullOrEmpty(branch))
                {
                    branchId = _db.Branch.Where(x => x.Name == branch).FirstOrDefault()?.Id;
                    if (branchId == null)
                    {
                        var createdBranch = _db.Branch.Add(new Branch { Name = branch });
                        _db.SaveChanges();
                        branchId = createdBranch.Id;
                    }
                }
                _db.Student.Add(new Student
                {

                    FirstName = student.FN,
                    LastName = student.LN,
                    RollNo = (int)student.RollNo,
                    Marks = (decimal)(double?)student.Marks,
                    BranchId = branchId
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

        public bool CreateStudentWithSP(StudentBO student)
        {
            try
            {
                var result = _db.CreateStudent(student.FN, student.LN, student.RollNo, (decimal?)student.Marks);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
                return false;
            }
            return true;
        }

        public bool DeleteStudent(int rollNumber)
        {
            try
            {
                var students = _db.Student.Where(x => x.RollNo == rollNumber);
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

        public StudentBO GetStudentByRollNumber(int rollNo)
        {
            var student = _db.Student.Where(r => r.RollNo == rollNo).Select(x => new StudentBO
            {
                FN = x.FirstName,
                LN = x.LastName,
                RollNo = x.RollNo,
                Marks = (double?)x.Marks,
                Branch = x.Branch.Name
            }).FirstOrDefault();

            return student;
        }

        public List<StudentBO> GetStudents()
        {
            var list = _db.Student.Select(x => new StudentBO
            {
                FN = x.FirstName,
                LN = x.LastName,
                RollNo = x.RollNo,
                Marks = (double?)x.Marks,
                Branch = x.Branch.Name
            }).ToList();

            return list;
        }

        public bool UpdateStudent(StudentBO student)
        {
            try
            {
                var st = _db.Student.Where(x => x.RollNo == student.RollNo).FirstOrDefault();
                st.FirstName = student.FN;
                st.LastName = student.LN;
                st.Marks = (decimal)(double?)student.Marks;
                _db.Student.Add(st);
                _db.Entry(st).State = System.Data.Entity.EntityState.Modified;
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
