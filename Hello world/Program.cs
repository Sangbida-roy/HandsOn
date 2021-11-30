using System;

namespace Hello_world
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Calculate calc = new Calculate();
            Console.WriteLine("Enter Values");
            calc.x = int.Parse(Console.ReadLine());
            calc.y = int.Parse(Console.ReadLine());

            int reuslt1 = calc.sum();
            Console.WriteLine(reuslt1);
            int result2 = calc.difference();
            Console.WriteLine(result2);
        } //comments
        //store values
    }
}
