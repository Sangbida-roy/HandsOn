using System;
using System.Collections.Generic;


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
                string input = Console.ReadLine();
                if (input == "1")
                {
                    Console.WriteLine("Number of students");
                    int i = Convert.ToInt32(Console.ReadLine());
                    size = i;

                    if (i != 0)
                    {

                        for (int j = 0; j < i; j++)
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
                        }
                    }
                    else
                    {
                        Console.WriteLine("invalid input");
                    }
                }
                else if (input == "2")
                {
                    for (int i = 0; i < size; i++)
                    {
                        Student st = stuList[i];
                        Console.WriteLine("Thank you for providing the details. Following are your details-");
                        Console.WriteLine($"FirstName-{st.FN}");
                        Console.WriteLine($"LastName-{st.LN}");
                        Console.WriteLine($"Rollnum-{st.RollNo}");

                        Console.WriteLine($"Marks-{st.Marks}");
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

