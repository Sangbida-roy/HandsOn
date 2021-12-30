using Entity_Framework_Dotnet.BO;
using Entity_Framework_Dotnet.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
namespace Entity_Framework_Dotnet
{
    class Program
    {
        static void Main(string[] args)
        {
            var dal = new StudentDAL();
            var studList = new List<BO.StudentBO>();
            //dal.DeleteStudent(123);
            /*dal.CreateStudentWithSP(new StudentBO
            {
                FN = "Umesh",
                LN = "Roy",
                RollNo = 12,
                Marks = 100

            });*/

            var a = dal.GetStudentByRollNumber(123);
            var b = dal.UpdateStudent(new StudentBO
            {
                FN = "Sangbida",
                LN = "Roy",
                RollNo = 12,
                Marks = 100

            });
            b = dal.CreateStudent(new StudentBO
            {
                FN = "Rahul",
                LN = "Jain",
                RollNo = 123,
                Marks = 100

            });
            
            int size = 0;
            for (; ; )
            {
                Console.WriteLine("1-Enter details");
                Console.WriteLine("2-Print details");
                Console.WriteLine("3-Print specific student details");

                string input = Console.ReadLine();
                if (input == "1")
                {
                    Console.WriteLine("Number of students");
                    int i = Convert.ToInt32(Console.ReadLine());
                    size = i;


                    if (i != 0)
                    {
                        int j = 0;
                        do
                        //while(j<i)
                        //for (int j = 0; j < i; j++)
                        {
                            var st = new BO.StudentBO();
                            Console.WriteLine("Enter following details");
                            Console.WriteLine("Enter first name");
                            st.FN = Console.ReadLine();

                            Console.WriteLine("Enter last name");
                            st.LN = Console.ReadLine();

                            Console.WriteLine("Enter rollno");
                            st.RollNo = int.Parse(Console.ReadLine());

                            Console.WriteLine("Enter Marks");
                            st.Marks = double.Parse(Console.ReadLine());

                            //studList.Add(st);
                            dal.CreateStudent(st);
                            j++;
                        }
                        while (j < i);
                    }
                    else
                    {
                        Console.WriteLine("invalid input");

                    }
                }
                else if (input == "2")
                {
                    //for (int i = 0; i < size; i++)
                    studList = dal.GetStudents();
                    foreach (var st in studList)
                    {
                        Console.WriteLine("Thank you for providing the details. Following are your details-");
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
                    Console.WriteLine("Invalid Input");
                }
            }
        }
    }
}
