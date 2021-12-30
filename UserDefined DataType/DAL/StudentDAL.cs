using ADO.NetConnection.BO;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NetConnection.DAL
{
    public class StudentDAL
    {
        private readonly string _connectionstring;
        public StudentDAL()
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
            _connectionstring = configuration.GetConnectionString("DBConnectionString");


        }
        public List<Student> GetStudents()
        {

            var studlist = new List<Student>();
            using (SqlConnection sqlConnection = new SqlConnection(_connectionstring))
            {
                sqlConnection.Open();
                string str = "select * from Student";
                using (SqlCommand command = new SqlCommand(str, sqlConnection))
                {
                    var rdr = command.ExecuteReader();
                    while (rdr.Read())
                    {
                        var student = new Student();

                        student.ID = rdr["ID"] as int?;
                        student.FN = rdr["FirstName"] as string;
                        student.LN = rdr["LastName"] as string;
                        student.RollNo = rdr["RollNo"] as int?;
                        student.Marks = rdr["Marks"] as double?;
                        student.DateOfBirth = rdr["DateOfBirth"] as string;
                        studlist.Add(student);
                    }
                    rdr.Close();
                    sqlConnection.Close();
                }
            }
            return studlist;
        }
        public Student GetStudentsByRollnum(int rollno)
        {
            var student = new Student();

            using (SqlConnection sqlConnection = new SqlConnection(_connectionstring))
            {
                sqlConnection.Open();
                string str = "select * from Student where RollNo = @rollno";
                using (SqlCommand command = new SqlCommand(str, sqlConnection))
                {
                    command.Parameters.AddWithValue("@rollno", rollno);
                    var rdr = command.ExecuteReader();
                    while (rdr.Read())
                    {

                        student.FN = rdr["FirstName"] as string;
                        student.LN = rdr["LastName"] as string;
                        student.RollNo = rdr["RollNo"] as int?;
                        student.Marks = rdr["Marks"] as double?;
                    }
                    rdr.Close();
                    sqlConnection.Close();
                }
            }
            return student;
        }
            public bool CreateStudent (Student student)
            {
                    bool isSuccess = true;
                    try
                    {
                        using (SqlConnection sqlConnection = new SqlConnection(_connectionstring))
                        {
                                sqlConnection.Open();
                                string str = "INSERT INTO Student(FIRSTNAME, LASTNAME, ROLLNO, MARKS) VALUES (@firstname,@lastname,@rollno,@marks);" +
                                "SET @id=SCOPE_IDENTITY();";
                            int? id = 0;
                            var sqlParamId = new SqlParameter { Direction = System.Data.ParameterDirection.Output, ParameterName = "@id", DbType = System.Data.DbType.Int32 };
                            using (SqlCommand command = new SqlCommand(str, sqlConnection))
                            {
                                command.Parameters.AddWithValue("@firstname", student.FN);
                                command.Parameters.AddWithValue("@lastname", student.LN);
                                command.Parameters.AddWithValue("@rollno", student.RollNo);
                                command.Parameters.AddWithValue("@marks", student.Marks);
                                command.Parameters.Add(sqlParamId);
                                var result = command.ExecuteNonQuery();
                                id = sqlParamId.Value as int?;
                                sqlConnection.Close();

                            }


                        }

                    }
                    catch(Exception e)
                    {
                        isSuccess = false;
                        Console.WriteLine("An error occured. " + e.Message);
                        throw;
                    }
                    return isSuccess;

            }

                public bool CreateStudentWithSP(Student student)
                {
                    bool isSuccess = true;
                    try
                    {
                        using (SqlConnection sqlConnection = new SqlConnection(_connectionstring))
                        {
                            sqlConnection.Open();
                            string str = "CreateStudent";
                            using (SqlCommand command = new SqlCommand(str, sqlConnection))
                            {
                                command.CommandType = System.Data.CommandType.StoredProcedure;

                                command.Parameters.AddWithValue("@firstname", student.FN);
                                command.Parameters.AddWithValue("@lastname", student.LN);
                                command.Parameters.AddWithValue("@rollno", student.RollNo);
                                command.Parameters.AddWithValue("@marks", student.Marks);
                               
                                var result = command.ExecuteScalar();
                                sqlConnection.Close();

                            }

                        }

                    }
                    catch(Exception e)
                    {
                        isSuccess = false;
                        Console.WriteLine("An error occured. " + e.Message);
                        throw;

                    }
                    return isSuccess;
                }

                public bool UpdateStudent(Student student)
                {
                    bool isSuccess = true;
                    try
                    {
                        using (SqlConnection sqlConnection = new SqlConnection(_connectionstring))
                        {
                            sqlConnection.Open();
                            string str = "UPDATE STUDENT" +
                                " SET FIRSTNAME = @firstname," +
                                     "LASTNAME=@lastname," +
                                     "MARKS=@marks" +
                                     " WHERE ROLLNO= @rollno;";
                            using (SqlCommand command = new SqlCommand(str, sqlConnection))
                            {
                                command.Parameters.AddWithValue("@firstname", student.FN);
                                command.Parameters.AddWithValue("@lastname", student.LN);
                                command.Parameters.AddWithValue("@rollno", student.RollNo);
                                command.Parameters.AddWithValue("@marks", student.Marks);
                                 var result = command.ExecuteNonQuery();
                                sqlConnection.Close();
                            }

                        }

                    }
                    catch (Exception e)
                    {
                        isSuccess = false;
                        Console.WriteLine("An error occured. " + e.Message);
                        throw;

                    }
                    return isSuccess;

                }
                public bool DeleteStudent(int rollNumber)
                {
                    bool isSuccess = true;
                    try
                    {

                        using (SqlConnection sqlConnection = new SqlConnection(_connectionstring))
                        {
                            sqlConnection.Open();
                            string str = "DELETE Student"+Environment.NewLine+
                                     "WHERE ROLLNO= @rollno;";
                            using (SqlCommand command = new SqlCommand(str, sqlConnection))
                            {
                                
                                command.Parameters.AddWithValue("@rollno", rollNumber);
                                var result = command.ExecuteNonQuery();
                                sqlConnection.Close();
                            }

                        }

                    }
                    catch (Exception e)
                    {
                        isSuccess = false;
                        Console.WriteLine("An error occured. " + e.Message);
                        throw;

                    }
                    return isSuccess;
                }

            
    }
}
