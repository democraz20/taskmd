

namespace taskmd;

public class write{
    public static void colors(string fileName="Task.md"){
        string[] lines = taskmd.indexFile(fileName);
        for (int i = 0; i < lines.Length; i++)
        {
            if (i == 0){
                Console.WriteLine(lines[0]);
            }else{
                string lsplit = lines[i];
                string[] splitted = lsplit.Split(" ");
                for (int j = 0; j < splitted.Length-1; j++)
                {
                    lsplit = splitted[splitted.Length-1];
                    char[] check = lsplit.ToCharArray();
                    if (check[1] == '✓'){
                        for (int x = 0; x < splitted.Length-2; x++)
                        {
                            Console.Write(splitted[x] + " ");
                        }
                        Console.Write("[");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("✓");
                        Console.ResetColor();
                        Console.WriteLine("]");
                        break;
                    }
                    else {
                        for (int x = 0; x < splitted.Length-2; x++)
                        {
                            Console.Write(splitted[x] + " ");
                        }
                        Console.Write("[");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("X");
                        Console.ResetColor();
                        Console.WriteLine("]");
                        break;
                    }
                }
            }
        }
    }
}