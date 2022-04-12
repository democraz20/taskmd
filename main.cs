using System.Linq;
using System.Text;

namespace taskmd;

public class taskmd{
    public static void core(string[] args){
        if (args.Length == 0)
        {
            //com [0] [index] [file(optional)]
            //prints usage
            Console.WriteLine("Usage: taskmd <file>");
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
    public static void rewriteAll(string[] lines, string fileName){ 
        File.WriteAllText(fileName, string.Empty);
        using (StreamWriter writer = new StreamWriter(fileName))  
        {  
            //writer.WriteLine("# Task.md file");
            // 0 1 2 3 4
            // a b c d f
            //          
            //Console.WriteLine("forloop start"); 
            for (int i = 0; i < lines.Length-1; i++)
            {
                writer.WriteLine(lines[i]);
            }
            writer.Write(lines[lines.Length-1]);
        }
    }
}