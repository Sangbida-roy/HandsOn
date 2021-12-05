using System;
using System.Collections.Generic;
using System.Linq;

namespace UserDefined_DataType
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> stuList = new List<Student>();
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
                    //while (i != 0 && i < size)
                    {
                        int j = 0;
                        do
                        //while(j<i)
                        //for (int j = 0; j < i; j++)
                        {
                            Student st = new Student();
                            Console.WriteLine("Enter following details");
                            Console.WriteLine("Enter first name");
                            st.FN = Console.ReadLine();

                            Console.WriteLine("Enter last name");
                            st.LN = Console.ReadLine();

                            Console.WriteLine("Enter rollno");
                            st.RollNo = int.Parse(Console.ReadLine());

                            Console.WriteLine("Enter Marks");
                            st.Marks = double.Parse(Console.ReadLine());

                            stuList.Add(st);
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
                    foreach (Student item in stuList)
                    {
                        Console.WriteLine("Thank you for providing the details. Following are your details-");
                        Console.WriteLine($"FirstName-{item.FN}");
                        Console.WriteLine($"LastName-{item.LN}");
                        Console.WriteLine($"Rollnum-{item.RollNo}");

                        Console.WriteLine($"Marks-{item.Marks}");
                    }
                }
                else if (input == "3")
                {
                    //Console.WriteLine("Enter roll no");
                    //var RollNo = Convert.ToInt32(Console.ReadLine());
                    //var student = stuList.Where(x => x.RollNo == RollNo).FirstOrDefault();
                    Console.WriteLine("Enter FirstName");
                    var FN = Console.ReadLine();
                    var students = stuList.Where(x => x.FN == FN).ToList();
                    Console.WriteLine(students);


                }
                else
                {
                    Console.WriteLine("Invalid Input");
                }
            }
        }
    }
}

