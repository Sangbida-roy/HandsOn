using Entity_Framework.BO;
using Entity_Framework.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Framework
{
    class Program
    {
        static void Main(string[] args)
        {

                var dal = new StudentDAL();
                //dal.UpdateStudent(new StudentBO
                //{
                //    FN = "Animesh",
                //    LN = "Behera",
                //    RollNo = 786,
                //    Marks = 104.12
                //});

                //dal.DeleteStudent(12);
                var studList = new List<BO.StudentBO>();
            /*
             dal.CreateStudentWithSP(new Student
           {
            FN = "Umesh",
            LN = "Roy",
            RollNo = 12,
            Marks = 100

           });

            var a = dal.GetStudentsByRollnum(123);
            var b = dal.UpdateStudent(new Student
           {
            FN = "Sangbida",
            LN = "Roy",
            RollNo = 12,
            Marks = 100

           });
            var c = dal.CreateStudent(new Student
           {
            FN = "Rahul",
            LN = "Jain",
            RollNo = 123,
            Marks = 100

           });

             */
            int size = 0;
                for (; ; )
                {
                    Console.WriteLine("1. Enter inputs");
                    Console.WriteLine("2. Print Data");
                    string input = Console.ReadLine();
                    if (input == "1")
                    {
                        Console.WriteLine("Number of students");

                        var i = Convert.ToInt32(Console.ReadLine());
                        size = i;

                        if (i != 0)
                        {
                            for (int j = 0; j < i; j++)
                            {
                                var st = new BO.StudentBO();
                                Console.WriteLine($"Enter following details for Student {j + 1}");
                                Console.WriteLine("Enter first name");
                                st.FN = Console.ReadLine();

                                Console.WriteLine("Enter last name");
                                st.LN = Console.ReadLine();

                                Console.WriteLine("Enter rollno");
                                st.RollNo = int.Parse(Console.ReadLine());

                                Console.WriteLine("Enter Marks");
                                st.Marks = double.Parse(Console.ReadLine());
                                dal.CreateStudent(st);
                            }

                        }
                        else
                        {
                            Console.WriteLine("invalid input");
                        }
                    }
                    else if (input == "2")
                    {
                        studList = dal.GetStudents();
                        foreach (var st in studList)
                        {
                            Console.WriteLine($"FirstName-{st.FN}");
                            Console.WriteLine($"LastName-{st.LN}");
                            Console.WriteLine($"Rollnum-{st.RollNo}");

                            Console.WriteLine($"Marks-{st.Marks}");
                        }

                    }
                    else if (input == "3")
                {
                    Console.WriteLine("1 - using roll no.");
                    Console.WriteLine("2 - using First name");

                    string para = Console.ReadLine();

                    if (para == "1")

                    {
                        Console.WriteLine("Enter roll no");
                        var RollNo = Convert.ToInt32(Console.ReadLine());
                        var student = studList.Where(x => x.RollNo == RollNo).FirstOrDefault();
                        Console.WriteLine("First Name - {0}", student.FN);
                        Console.WriteLine("Last Name - {0}", student.LN);

                    }
                    else if (para == "2")
                    {
                        //Console.WriteLine("Enter FirstName");
                        //var FN = Console.ReadLine();
                        //var students = stuList.Where(x => x.FN == FN).ToList();
                        //Console.WriteLine(students);

                    }
                    else
                    {
                        Console.WriteLine("invalid case");
                    }
                }
                else
                {
                        Console.WriteLine("Invalid input");
                        break;
                }
                }
            
        }
    }
}
