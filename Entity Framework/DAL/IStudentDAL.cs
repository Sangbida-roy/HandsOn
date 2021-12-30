using Entity_Framework.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Framework.DAL
{
        public interface IStudentDAL
        {
            bool CreateStudent(StudentBO student);
            bool CreateStudentWithSP(StudentBO student);
            bool DeleteStudent(int rollNumber);
            StudentBO GetStudentByRollNumber(int rollNo);
            List<StudentBO> GetStudents();
            bool UpdateStudent(StudentBO student);
        }
    
}
