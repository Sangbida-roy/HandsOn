using System;

namespace Hello_world
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Calculate calc = new Calculate();
            calc.x = 20;
            calc.y = 40;

                int reuslt1 = calc.sum();
            Console.WriteLine(reuslt1);
            int result2 = calc.difference();
            Console.WriteLine(result2);
        } //comments

    }
}
