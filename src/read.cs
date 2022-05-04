namespace taskmd;

public class read{ //editedLine and mode are nullable because the function can be called with and without these two
//might use opional args idk
    public static void readT( string fileName="TASK.md", int? editedLine = null, string? mode = null){
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
            if(editedLine == i+1){ //writing modes
                modes(i, mode);    //writes it after the checks so it appears behind the task's content
            }
        }
    }   
    //mode is nullable because mode in readT is also nullable but when called both of these are required

    private static void modes(int index, string? mode){
        //since this will be called everytime anyways
        //the 2 writeLines might screw up
        //might have this check that if the two args are empty
        //just do a \n
        //else just do the case switch
        switch(mode){
            case "tog":                                                                           
                Console.WriteLine(" <= Toggled Line"); //uses writeline so this actually ends the line
                break;
        }
    }
}