using IO.Swagger.Api;
using IO.Swagger.Model;
using System;
using System.Collections.Generic;

namespace ConsumerApi
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var apiInstance = new StudentApi("https://localhost:44308/");

            try
            {
                List<StudentBO> result = apiInstance.ApiStudentGetAllStudentsGet();
                Console.WriteLine(result);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception when calling StudentApi.ApiStudentGetAllStudentsGet: " + e.Message);
            }

            try
            {
                var result = apiInstance.ApiStudentGetStudentByIdGet(1);
                Console.WriteLine(result.FirstName);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception when calling StudentApi.ApiStudentGetAllStudentByIdGet: " + e.Message);
            }


        }
    }
}
