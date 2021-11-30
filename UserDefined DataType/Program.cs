using System;

namespace UserDefined_DataType
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Number of students");
            string size = Console.ReadLine();
            int i = Convert.ToInt32(size);

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

                    Console.WriteLine("Thank you for providing the details. Following are your details-");
                    Console.WriteLine($"FirstName-{st.FN}");
                    Console.WriteLine($"LastName-{st.LN}");
                    Console.WriteLine($"Rollnum-{st.RollNo}");

                    Console.WriteLine($"Marks-{st.Marks}");
                }
            }
            else
            {
                Console.WriteLine("invalid input");
            }

            


        }
    }
}
