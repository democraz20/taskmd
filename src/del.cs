using System.Text;

namespace taskmd;

public class del{
    public static void remove(string index, string fileName="TASK.md"){
        string[] lines = taskmd.indexFile(fileName);
        //remove item in array
        //int indexToRemove = index;
        //convert string to in
        int indexToRemove = int.Parse(index);
        lines = lines.Where((source, index) =>index != indexToRemove).ToArray();
        //rewrite file
        read.colors(fileName, indexToRemove+4, "delete");
        taskmd.rewriteAll(lines, fileName);
    }
}