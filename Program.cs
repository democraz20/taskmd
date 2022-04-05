using System;

namespace taskmd
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (var arg in args)
            {
              Console.WriteLine(arg);
            }
            Console.Title = "TaskMD";
            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
    }
}