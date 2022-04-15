

namespace taskmd;

public class tog{
    public static void toggle(int index, string fileName="Task.md"){
        string[] lines = taskmd.indexFile(fileName);
        //char[] arr = lines[index].ToCharArray();
        //arr[arr.Length-2] = '✓';
        string[] arr = lines[index].Split(' ');
        if (arr[arr.Length-1] == "[✓]<br/>"){
            arr[arr.Length-1] = "[X]<br/>";
        }
        else{
            arr[arr.Length-1] = "[✓]<br/>";
        }
        lines[index] = string.Join(" ", arr);
        write.colors(fileName, index, "toggle");
        taskmd.rewriteAll(lines, fileName);
    }
}