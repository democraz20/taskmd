

namespace taskmd;

public class write{
    public static void colors(string fileName="Task.md", int? editedLine = null, string? editMode = null){
        string[] lines = taskmd.indexFile(fileName);
        Console.WriteLine("");
        for (int i = 0; i < lines.Length; i++)
        {
            if (i == 0){
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(lines[0]);
                Console.ResetColor();
            }else{
                string lsplit = lines[i];
                string[] splitted = lsplit.Split(" ");
                for (int j = 0; j < splitted.Length-1; j++)
                {
                    lsplit = splitted[splitted.Length-1];
                    char[] check = lsplit.ToCharArray();
                    if (check[1] == '✓'){
                        for (int x = 0; x < splitted.Length-1; x++)
                        {
                            Console.Write(splitted[x] + " ");
                        }
                        Console.Write("[");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("✓");
                        Console.ResetColor();
                        Console.Write("]");
                        writeDetails(i, editedLine, editMode);
                        break;
                    }
                    else {
                        for (int x = 0; x < splitted.Length-1; x++)
                        {
                            Console.Write(splitted[x] + " ");
                        }
                        Console.Write("[");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("X");
                        Console.ResetColor();
                        Console.Write("]");
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