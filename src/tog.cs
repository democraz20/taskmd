

namespace taskmd;

public class tog{
    public static void toggle(int index, string fileName="TASK.md"){
        string[] lines = taskmd.indexFile(fileName);
        //char[] arr = lines[index].ToCharArray();
        //arr[arr.Length-2] = '✓';
        string[] arr = lines[index].Split(' ');
        if (arr[1] == "[X]"){
            arr[1] = "[ ]";
        }
        else{
            arr[1] = "[X]";
            arr[2] = "";
            arr = arr.Where((source, index) =>index != 2).ToArray();
        }
        lines[index] = string.Join(" ", arr);
        read.colors(fileName, index, "toggle");
        taskmd.rewriteAll(lines, fileName);
    }
}