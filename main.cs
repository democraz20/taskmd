using System.Linq;
using System.Text;

namespace taskmd;

public class taskmd{
    public static void core(string[] args){
        if (args.Length == 0)
        {
            //com [0] [index] [file](optional)
            //prints usage
            Console.WriteLine("Usage: taskmd <file>");
            return;
        }
        string firstarg = args[0].ToLower();
        switch (firstarg){
            case "add":
                Console.WriteLine("Add");
                //string joinArgs = string.Join(" ", args);
                //Console.WriteLine(joinArgs);
                //string[] joinedArgs = add.GetArgs(joinArgs);
                add.printArgs(args);
                add.writeAdd(args[1]);
                break;
            case "del":
                Console.WriteLine("Del");
                del.remove(args[1]);
                break;
            case "tog":
                Console.WriteLine("Tog");
                int index = int.Parse(args[1]);
                tog.toggle(index);
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


    //public uses might need do cleanup later
    public static string[] indexFile(string fileName){
        string readFile = File.ReadAllText(fileName, Encoding.UTF8);
        string[] lines = readFile.Split(
            new string[] { Environment.NewLine },
            StringSplitOptions.None
        );
        return lines;
    }
    public static void rewriteAll(string[] lines){
        File.WriteAllText("Task.md", string.Empty);
        using (StreamWriter writer = new StreamWriter("Task.md"))  
        {  
            //writer.WriteLine("# Task.md file");
            // 0 1 2 3 4
            // a b c d f
            //          
            for (int i = 0; i < lines.Length-1; i++)
            {
                writer.WriteLine(lines[i]);
            }
            writer.Write(lines[lines.Length-1]);
        }
    }
}