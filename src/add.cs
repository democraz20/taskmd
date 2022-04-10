using System.Text;
using System.Linq;

namespace taskmd;

public class add{
    public static void writeAdd(string newText){
        newText = newText+" [x]";
        string[] lines = taskmd.indexFile("Task.md");
        using (StreamWriter writer = new StreamWriter("Task.md"))  
        {  
            foreach (string line in lines)  
            {  
                writer.WriteLine(line);  
            }  
            writer.Write(newText);
        }  
    }
    public static void printArgs (string[] input){
        if (input.Length == 0){
            Console.WriteLine("no args passed in");
        }
        else{
            for (int i = 0; i < input.Length; i++)
            {   
                Console.WriteLine($"index {i} all args {input[i]}");
            }
        }
    }
}