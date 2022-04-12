

namespace taskmd;

public class tog{
    public static void toggle(int index, string fileName="Task.md"){
        string[] lines = taskmd.indexFile(fileName);
        //char[] arr = lines[index].ToCharArray();
        //arr[arr.Length-2] = '✓';
        string[] arr = lines[index].Split(' ');
        if (arr[arr.Length-1] == "[✓]"){
            arr[arr.Length-1] = "[X]";
        }
        else{
            arr[arr.Length-1] = "[✓]";
        }
        lines[index] = string.Join(" ", arr);
        
        taskmd.rewriteAll(lines, fileName);
    }
}