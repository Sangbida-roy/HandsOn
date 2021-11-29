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

                int reuslt = calc.sum();
            Console.WriteLine(reuslt);
        } //comments

    }
}
