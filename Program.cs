using System;
using System.IO;
using System.Text;

namespace taskmd;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            //com [0] [index] [file](optional)
            //prints usage
            Console.WriteLine("Usage: taskmd <file>");
            return;
        }
        string firstarg = args[0].ToLower();
        for (int i = 0; i < args.Length; i++)
        {
            Console.WriteLine(args[i]);
        }
        switch (firstarg){
            case "add":
                Console.WriteLine("Add");
                //string joinArgs = string.Join(" ", args);
                //Console.WriteLine(joinArgs);
                //string[] joinedArgs = add.GetArgs(joinArgs);
                add.printArgs(args);
                add.write(args[2]);
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
                    using (FileStream fs = File.Create("Task.md"))
                    {
                    }
                    //File.Create("Task.md");
                    Console.WriteLine(" File \"Task.md\" created.");
                    Thread.Sleep(1000);
                    using (StreamWriter writer = new StreamWriter("Task.md")){
                        writer.Write("# Task.md file");
                    }
                }
                else{
                    Console.WriteLine("File \"Task.md\" already exists.");
                }
                break;
        }
    }
    public static string[] indexFile(string fileName){
        string readFile = File.ReadAllText(fileName, Encoding.UTF8);
        string[] lines = readFile.Split(
            new string[] { Environment.NewLine },
            StringSplitOptions.None
        );
        return lines;
    }
}
