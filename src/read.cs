

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
                        Console.Write($"{i}. ");

                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write("[");
                        Console.ResetColor();

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("✓");
                        Console.ResetColor();

                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write("] ");
                        Console.ResetColor();

                        for (int x = 2; x < splitted.Length; x++)
                        {
                            Console.Write(splitted[x] + " ");
                        }
                        writeDetails(i, editedLine, editMode);
                        break;
                    }
                    else {
                        Console.Write($"{i}. ");

                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write("[");
                        Console.ResetColor();

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("X");
                        Console.ResetColor();

                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write("] ");
                        Console.ResetColor();
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
        Console.ForegroundColor = ConsoleColor.DarkGray;
        if (editedLine == i){
            switch(editMode){
                case "toggle":
                    Console.WriteLine(" <= Toggled Line");
                    break;
                case "delete":
                    Console.WriteLine(" <= Deleted Line");
                    break;
                case "add":
                    Console.WriteLine(" <= Added Line");
                    break;
            }
        }else{Console.WriteLine();}
        Console.ResetColor();
    }
}