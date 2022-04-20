

namespace taskmd;

public class read{
    public static void colors(string fileName="TASK.md", int? editedLine = null, string? editMode = null){
        string[] lines = taskmd.indexFile(fileName);
        Console.WriteLine("");
        for (int i = 3; i < lines.Length; i++)
        {
            if (i < 4){
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(lines[i]);
                Console.ResetColor();
            }else{
                string lsplit = lines[i];
                string[] splitted = lsplit.Split(" ");
                for (int j = 0; j < splitted.Length-1; j++)
                {
                    lsplit = splitted[splitted.Length-1];
                    if (splitted[1] == "[X]"){
                        Console.Write($"{i-3}. [");
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
                        Console.Write($"{i-3}. [");
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