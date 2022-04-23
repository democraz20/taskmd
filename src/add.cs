using System.Text;
using System.Linq;

namespace taskmd;

public class add{
    public static void writeAdd(string newText, string fileName="TASK.md"){
        newText = "- [ ] " + newText;
        string[] lines = taskmd.indexFile(fileName);
        using (StreamWriter writer = new StreamWriter(fileName))  
        {  
            foreach (string line in lines)  
            {  
                writer.WriteLine(line);  
            }  
            writer.Write(newText);
        }  
        read.colors(fileName, lines.Length-1, "add");
    }
}