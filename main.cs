using System.Linq;
using System.Text;

namespace taskmd;

class Program
{
    static void Main(string[] args)
    {
        taskmd.M(args);
    }
}
public class taskmd
{
    public static void M(string[] args)
    {
        if(args.Length == 0){ //usage
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(" Usage: [required] (optional)");
            Console.WriteLine(" Commands: init (file header) (file name)");
            Console.WriteLine("         : add  [task] (file name)");
            Console.WriteLine("         : del  [task index] (file name)");
            Console.WriteLine("         : tog [task index] (file name)");
            Console.WriteLine("         : read");
            Console.ResetColor();
        }
        else{
            switch(args[0]){
                case "init":
                    if (args.Length == 3){
                        init.start(args[1], args[2]);
                    }else if (args.Length == 2){
                        init.start(args[1]);}
                    else{init.start();}
                    break;
                case "read": //its ugly i know
                    if (args.Length == 1){read.readT();}
                    else{read.readT(args[1]);}
                    break;
                case "add":
                    if (args.Length == 1){Console.WriteLine(" Missing arguements");}
                    else{add.addT(args[1]);}
                    break;
                case "tog":
                    if (args.Length == 3){tog.toggle(int.Parse(args[1]), args[2]);}
                    else if (args.Length == 2){tog.toggle(int.Parse(args[1]));}
                    else {Console.WriteLine(" Missing arguements");}
                    break;
                case "del":
                    if (args.Length == 1){Console.WriteLine(" Missing arguements");}
                    else{delete.delT(int.Parse(args[1]));}
                    break;
            }
        }
    }

    //default for fileName is TASK.md for almost everything
    public static string[] getLines(string fileName="TASK.md"){     //get all lines in a file, public uses
        string readFile = File.ReadAllText(fileName, Encoding.UTF8);
        string[] lines = readFile.Split( //split by newline
            new string[] { Environment.NewLine }, //blah blah
            StringSplitOptions.None
        );
        //remove first 7 lines of which are not the tasks
        for (int i = 0; i < 7; i++)
        {
            lines = lines.Where((source, index) =>index != 0).ToArray(); //remove the first one always (since every time one gets removed the line below becomes index 0 again)
        }
        return lines; //return
    }
    public static string taskName(string fileName="TASK.md"){    //get the task's name, public uses
        string readFile = File.ReadAllText(fileName, Encoding.UTF8);
        string[] lines = readFile.Split( //split by newline
            new string[] { Environment.NewLine }, 
            StringSplitOptions.None
        );
        return lines[5];    //return index 5 because the task's name is at line 6
    }
    public static void reWrite(string[] lines, string fileName="TASK.md"){ //rewrite the file, public uses
        string taskName = taskmd.taskName();
        File.WriteAllText(fileName, string.Empty);  //Empty the file
        using (StreamWriter writer = new StreamWriter(fileName))  
        {  
            writer.WriteLine(taskmd.header);   //write the header
            writer.WriteLine(taskName);   //write the task's name
            if(lines.Length == 0){ Console.WriteLine("No tasks to display");
            }else{
                writer.WriteLine();
                for (int i = 0; i < lines.Length-1; i++) //for every line in array lines
                {
                    writer.WriteLine(lines[i]);  //write the lines
                }
                writer.Write(lines[lines.Length-1]); 
            } //end it with a Write(); instead of a WriteLine();
        }
    }

    //public header 
    public const string header = @"<!--- 
This file was created using TASK.md
https://github.com/democraz20/taskmd
-->
";
}


//enum for editmode
//empty is for wen nothing
public enum editmode{
    add,
    del, 
    tog,
    empty
}