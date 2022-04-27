

namespace taskmd;

public class read{
    public static void colors(string fileName="TASK.md", int? editedLine = null, string? editMode = null){
        string[] lines = taskmd.indexFile(fileName);
        Console.WriteLine("");
        for (int i = 0; i < lines.Length+1; i++)
        {
            if (i == 0){
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Task");
                Console.ResetColor();
            }else{
                string lsplit = lines[i-1];
                string[] splitted = lsplit.Split(" ");
                for (int j = 0; j < splitted.Length; j++)
                {
                    //lsplit = splitted[splitted.Length-1];
                    //Console.WriteLine("test");
                    if (splitted[1] == "[X]"){
                        Console.Write($"{i}. [");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("✓");
                        Console.ResetColor();
                        Console.Write("] ");
                        for (int x = 2; x < splitted.Length; x++)
                        {
                            Console.Write(splitted[x] + " ");
                        }
                        writeDetails(i, editedLine, editMode);
                        break;
                    }
                    else {
                        Console.Write($"{i}. [");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("X");
                        Console.ResetColor();
                        Console.Write("] ");
                        for (int x = 3; x < splitted.Length; x++)
                        {
                            Console.Write(splitted[x] + " ");
                        }
                        writeDetails(i, editedLine, editMode);
                        break;
                    }
                }
            }
        }
    }
    private static void writeDetails(int i, int? editedLine, string? editMode){
        if (editedLine == i){
            switch(editMode){
                case "toggle":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(" <= Toggled Line");
                    Console.ResetColor();
                    break;
                case "delete":
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" <= Deleted Line");
                    Console.ResetColor();
                    break;
                case "add":
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(" <= Added Line");
                    Console.ResetColor();
                    break;
            }
        }else{Console.WriteLine();}
    }
}