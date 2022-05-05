namespace taskmd;

public class read{ //editedLine and mode are nullable because the function can be called with and without these two
//might use opional args idk //haha using enums now
    public static void readT( string fileName="TASK.md", int? editedLine = null, editmode modeedit = editmode.empty){
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
            }
            if(editedLine == i+1){ //writing modes
                modes(i, modeedit);    //writes it after the checks so it appears behind the task's content
            }else{Console.WriteLine();} //if not edited, just read the line
        }
    }   
    //mode is nullable because mode in readT is also nullable but when called both of these are required


    //using enums yey
    private static void modes(int index, editmode mode){ 
        //since this will be called everytime anyways
        //the 2 writeLines might screw up
        //might have this check that if the two args are empty
        //just do a \n
        //else just do the case switch
        Console.ForegroundColor = ConsoleColor.DarkGray;
        switch(mode){
            case editmode.empty:
                Console.WriteLine();
                break;
            case editmode.toggle:                                                                           
                Console.WriteLine(" <= Toggled Line"); //uses writeline so this actually ends the line
                break;
            case editmode.del:
                Console.WriteLine(" <= Deleted Line");
                break;
            case editmode.add:
                Console.WriteLine(" <= Added Line");
                break;
        }
        Console.ResetColor();
    }
}