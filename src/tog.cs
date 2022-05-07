using System.Linq;

namespace taskmd;

public class tog{
    public static void toggle(int index, string fileName="TASK.md"){
        string[] lines = taskmd.getLines(fileName);
        //char[] arr = lines[index].ToCharArray();
        string[] arr = lines[index-1].Split(' ');
        if (arr[1] == "[X]"){
            arr[1] = "[ ]";
        }
        else{
            arr[1] = "[X]";
            arr[2] = "";
            //arr = arr.Where((source, index) =>index+3 != 2).ToArray();
            arr = arr.Where((source, index) =>index != 2).ToArray();
        }
        lines[index-1] = string.Join(" ", arr);
        //Console.WriteLine("read.colors()");
        taskmd.reWrite(lines, fileName);
        read.readT(fileName, index, editmode.tog);
    }
}