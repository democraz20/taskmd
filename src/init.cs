

namespace taskmd;

public class init{
    public static void start(string fileName="TASK.md"){
        if (!File.Exists(fileName)){
             Console.WriteLine($"File \"{fileName}\" not found \n Creating new one in current directory.");
            using (FileStream fs = File.Create(fileName))
            {
            }
            //File.Create("Task.md");
            Console.WriteLine($" File \"{fileName}\" created.");
            Thread.Sleep(1000);
            using (StreamWriter writer = new StreamWriter(fileName)){
                writer.WriteLine(headers.header);
            }
        }
        else{
            Console.WriteLine($"File \"{fileName}\" already exists.");
        }
    }
}
