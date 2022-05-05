namespace taskmd;

public class add{
    public static void addT(string newTask, string fileName="TASK.md"){
        newTask = "- [ ] " + newTask;
        string[] lines = taskmd.getLines(fileName);
        string taskName = taskmd.taskName(fileName);
        using (StreamWriter writer = new StreamWriter(fileName))  
        {  
            writer.WriteLine(taskmd.header);
            writer.WriteLine(taskName);
            writer.WriteLine();
            foreach (string line in lines)  
            {  
                writer.WriteLine(line);  
            }  
            writer.Write(newTask);
        }  
        read.readT(fileName, lines.Length+1, editmode.add);
    }
}