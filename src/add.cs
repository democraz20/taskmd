using System.Text;
using System.Linq;

namespace taskmd;

public class add{
    public static void writeAdd(string newText, string fileName="Task.md"){
        newText = newText+" [X]";
        string[] lines = taskmd.indexFile(fileName);
        using (StreamWriter writer = new StreamWriter(fileName))  
        {  
            foreach (string line in lines)  
            {  
                writer.WriteLine(line);  
            }  
            writer.Write(newText);
        }  
    }
}