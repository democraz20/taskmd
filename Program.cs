using System;
using System.IO;

namespace taskmd
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                //prints usage
                Console.WriteLine("Usage: taskmd <file>");
                return;
            }
            string firstarg = args[0].ToLower();
            switch (firstarg){
                case "add":
                    Console.WriteLine("Add");
                    break;
                case "del":
                    Console.WriteLine("Del");
                    break;
                case "tog":
                    Console.WriteLine("Tog");
                    break;
                case "init":
                    Console.WriteLine("Init");
                    if (!File.Exists("task.md")){
                        Console.WriteLine("File \"Task.md\" not found \n Creating new one in current directory.");
                        File.Create("Task.md");
                        Console.WriteLine(" File \"Task.md\" created.");
                    }
                    else{
                        Console.WriteLine("File \"Task.md\" already exists.");
                    }
                    break;
            }
        }
    }
}