using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BO;
using DAL.Data;
namespace DAL
{
    public class StudentDAL
    {
        private readonly TrainingEntities _db;
        public StudentDAL()
        {
            _db = new TrainingEntities();
        }

        public StudentInfoResponse CreateStudent(StudentInfoRequest request)
        {
            StudentInfoResponse student = new StudentInfoResponse();
            try
            {
                _db.Student.Add(new Student
                {
                    FirstName = request.Body.FName,
                    LastName = request.Body.LName,
                    RollNo = (int)request.Body.RollNo,
                    Marks = (decimal)request.Body.Marks

                });
                _db.SaveChanges();
                student.Header = new HeaderInfo
                {
                    CallStatus = "Success",
                    TransactionID = request?.Header?.TransactionID
                };
            }
            catch (Exception ex)
            {
                student.Header = new HeaderInfo
                {
                    CallStatus = "Error",
                    TransactionID = request?.Header?.TransactionID
                };
            }
            return student;
        }
            public StudentInfoResponse UpdateStudent(StudentInfoRequest request)
            {
                StudentInfoResponse student = new StudentInfoResponse();
                try
                {
                    var st = _db.Student.Where(x => x.RollNo == request.Body.RollNo).FirstOrDefault();
                    st.FirstName = request.Body.FName;
                    st.LastName = request.Body.LName;
                    st.RollNo = (int)request.Body.RollNo;
                    st.Marks = (decimal)request.Body.Marks;

                    _db.Student.Add(st);
                    _db.Entry(st).State = System.Data.Entity.EntityState.Modified; //Whenever we edit the entry
                    _db.SaveChanges();
                    student.Header = new HeaderInfo
                    {
                        CallStatus = "Success",
                        TransactionID = request?.Header?.TransactionID,
                    };

                }
                catch (Exception ex)
                {
                    student.Header = new HeaderInfo
                    {
                        CallStatus = "Error",
                        TransactionID = request?.Header?.TransactionID,
                    };
                }
                return student;
            }

            public StudentInfoResponse DeleteStudent(StudentInfoRequest request)
            {
                StudentInfoResponse student = new StudentInfoResponse();
                try
                {
                    var students = _db.Student.Where(x => x.RollNo == request.Body.RollNo);
                    _db.Student.RemoveRange(students);
                    _db.SaveChanges();
                student.Header = new HeaderInfo
                {
                    CallStatus = "Success",
                    TransactionID = request?.Header?.TransactionID
                };
            }
                catch (Exception ex)
                {
                    student.Header = new HeaderInfo
                    {
                        CallStatus = "Error",
                        TransactionID = request?.Header?.TransactionID,
                    };
                }
                return student;
            }
    }
}   