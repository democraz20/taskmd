using System.Linq;
using System.Text;

namespace taskmd;

public class taskmd{
    public static void core(string[] args){
        string version = "1.2.2";
        if (args.Length == 0)
        {
            //com [0] [index] [file(optional)]
            //prints usage
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(@$"
            Task.md - version {version}
            Usage : [filename]
            Commands : 
                - init ,       [filename(optional)]
                - add [task],  [filename(optional)]
                - del [index], [filename(optional)]
                - tog [index], [filename(optional)]
                - read,       [filename(optional)]
            Default file name for every command is 'Task.md'
            ");
            Console.ResetColor();   
            return;
        }
        string firstarg = args[0].ToLower();
        switch (firstarg){
            case "add":
                if (args.Length == 3){
                    add.writeAdd(args[1], args[2]);
                }
                else{
                    add.writeAdd(args[1]);
                }
                break;
            case "del":
                if(args.Length == 3){
                    del.remove(args[1], args[2]);
                }
                else{
                    del.remove(args[1]);
                }
                break;
            case "tog":
                //Console.WriteLine("Tog");
                if (args.Length == 3){
                    tog.toggle(int.Parse(args[1]), args[2]);
                }
                else{
                    tog.toggle(int.Parse(args[1]));
                }
                break;
            case "init":
                if (args.Length == 2){
                    init.start(args[1]);
                }
                else{
                    init.start();
                }
                break;
            case "read":
                if (args.Length == 1){
                    read.colors();
                }
                else{
                    read.colors(args[1]);
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
        //remove first lines for the file headers
        for (int i = 0; i < 7; i++)
        {
            lines = lines.Where((source, index) =>index != 0).ToArray();
        }
        return lines;
    }
    public static void rewriteAll(string[] lines, string fileName){ 
        File.WriteAllText(fileName, string.Empty);
        using (StreamWriter writer = new StreamWriter(fileName))  
        {  
            //writer.WriteLine("# Task.md file");
            // 0 1 2 3 4
            // a b c d f
            //          
            //Console.WriteLine("forloop start"); 
            writer.WriteLine(taskmd.header);
            for (int i = 0; i < lines.Length-1; i++)
            {
                writer.WriteLine(lines[i]);
            }
            writer.Write(lines[lines.Length-1]);
        }
    }
    public static string header = @"<!---
This file was created using TASK.md
https://github.com/democraz20/taskmd
-->

# Tasks
";

}