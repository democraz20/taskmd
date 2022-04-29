

namespace taskmd;

public class init{
    public static void start(string fileName="TASK.md"){
        if (!File.Exists(fileName)){
            using (FileStream fs = File.Create(fileName))
            {
            }
            //File.Create("Task.md");
            using (StreamWriter writer = new StreamWriter(fileName)){
                writer.WriteLine(taskmd.header);
            }
            Console.WriteLine($" File \"{fileName}\" created.");
        }
        else{
            Console.WriteLine($"File \"{fileName}\" already exists.");
        }
    }
}
