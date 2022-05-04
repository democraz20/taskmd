namespace taskmd;

public class read{
    public static void readT(string fileName="TASK.md"){
        string[] lines = taskmd.getLines(fileName); //get the lines
        //split lines for every space
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine(" "+taskmd.taskName(fileName));  //write the file's header or the task's name
        Console.ResetColor();

        for (int i = 0; i < lines.Length; i++){ //for every line
            string[] splittedLine = lines[i].Split(' ');
            Console.Write($" {i+1} ");     //writing the index number , +1 because arrays counts from 0
            if(splittedLine[1] == "[X]"){
                Console.ForegroundColor = ConsoleColor.DarkGray;    //funny colors
                Console.Write("[");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("✓");
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("]");
                Console.ResetColor();
                for (int j = 2; j < splittedLine.Length; j++) //for every word in the line, write the word with a space
                {
                    Console.Write(" "+splittedLine[j]);
                }
                Console.WriteLine(); //end the line print with a newline
            }
            else {
                Console.ForegroundColor = ConsoleColor.DarkGray;    //funny colors
                Console.Write("[");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("X");
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("]");
                Console.ResetColor();
                for (int j = 3; j < splittedLine.Length; j++)
                {
                    Console.Write(" "+splittedLine[j]);
                }
                Console.WriteLine();
            }
        }
    }
}