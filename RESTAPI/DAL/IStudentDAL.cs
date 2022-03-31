using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RESTAPI.BO;

namespace RESTAPI.DAL
{
    public interface IStudentDAL
    {
        IEnumerable<StudentBO> GetStudents();
        StudentBO GetStudent(int id);
        bool CreateStudent(StudentBO student);
        bool EditStudent(StudentBO student);
        bool DeleteStudentById(int id);
    }
}
