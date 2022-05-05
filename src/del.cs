namespace taskmd;

public class delete{
    public static void delT(int delIndex, string fileName="TASK.md"){
        string[] lines = taskmd.getLines(fileName);
        //remove item from arrays
        delIndex = delIndex - 1;
        lines = lines.Where((source, index) =>index != delIndex).ToArray();
        foreach(string line in lines){
            Console.WriteLine(line);
        }
        read.readT(fileName, delIndex+1, editmode.del);
        taskmd.reWrite(lines);
    }
}