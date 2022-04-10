using System.Text;

namespace taskmd;

public class del{
    public static void remove(string index){
        string[] lines = taskmd.indexFile("Task.md");
        //remove item in array
        //int indexToRemove = index;
        //convert string to int
        int indexToRemove = int.Parse(index);
        lines = lines.Where((source, index) =>index != indexToRemove).ToArray();

        //rewrite file
        taskmd.rewriteAll(lines);
    }
}