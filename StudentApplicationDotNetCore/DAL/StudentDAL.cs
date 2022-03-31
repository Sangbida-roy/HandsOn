using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using StudentApplicationDotNetCore.BO;
using StudentApplicationDotNetCore.DB;


namespace StudentApplicationDotNetCore.DAL
{
    public class StudentDAL
    {
        private readonly TrainingDbContext _db;
        public StudentDAL()
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
            var connectionString = configuration.GetConnectionString("DBConnectionString");
            var dbContextOptions = new DbContextOptionsBuilder<TrainingDbContext>().UseSqlServer(connectionString).Options;
            _db = new TrainingDbContext(dbContextOptions);
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
                        var createBranch = _db.Branch.Add(new Branch { Name = branch });
                        _db.SaveChanges();
                        branchId = createBranch.Entity.Id;
                    }
                }

                _db.Student.Add(new Student
                {
                    FirstName = student.FN,
                    LastName = student.LN,
                    RollNo = (int)student.RollNo,
                    Marks = (decimal)student.Marks,
                    BranchId = branchId,

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
                //var result = _db.CreateStudent(student.FN, student.LN, student.RollNo, (decimal)student.Marks);
                var result = _db.Database.ExecuteSqlInterpolated($"CreateStudent @firstname={student.FN},@lastname={student.LN}, @rollno={student.RollNo}, @marks={student.Marks}");
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
                Marks = (double)x.Marks,
                Branch = x.Branch.Name

            }).FirstOrDefault();

            return student;
        }
        public StudentBO GetStudentById(int id)
        {
            var student = _db.Student.Where(r => r.Id == id).Select(x => new StudentBO
            {
                Id = x.Id,
                FN = x.FirstName,
                LN = x.LastName,
                RollNo = x.RollNo,
                Marks = (double)x.Marks,

                Branch = x.Branch.Name,

            }).FirstOrDefault();
            return student;
        }

        public List<StudentBO> GetStudents()
        {
            var list = _db.Student.Select(x => new StudentBO
            {
                Id = x.Id,
                FN = x.FirstName,
                LN = x.LastName,
                RollNo = x.RollNo,
                Marks = (double)x.Marks,
                BranchId = x.Branch.Id,
                Branch = x.Branch.Name,
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
                st.Marks = (decimal)student.Marks;

                _db.Student.Add(st);
                _db.Entry(st).State = EntityState.Modified;
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

        public bool UpdateStudentById(StudentBO student)
        {
            try
            {
                var st = _db.Student.Where(x => x.Id == student.Id).FirstOrDefault();
                st.FirstName = student.FN;
                st.LastName = student.LN;
                st.Marks = (decimal)student.Marks;
                st.RollNo = (int)student.RollNo;
                _db.Student.Add(st);
                _db.Entry(st).State = EntityState.Modified;
                if (student.BranchId.HasValue)
                {
                    var Branch = _db.Branch.Find(student.BranchId);
                    Branch.Name = student.Branch;
                    _db.Branch.Add(Branch);
                    _db.Entry(Branch).State = EntityState.Modified;

                }
                else
                {
                    if (!string.IsNullOrEmpty(student.Branch))
                    {
                        var newbranch = _db.Branch.Add(new Branch { Name = student.Branch });
                        st.Branch = newbranch.Entity;
                    }
                }
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
