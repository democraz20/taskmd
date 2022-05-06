namespace taskmd;

public class init{
    public static void start(string header="Tasks", string fileName="TASK.md"){
        //check if file exists
        if(!File.Exists(fileName)){
            using (FileStream fs = File.Create(fileName)){} //create the file then close the file
            Console.WriteLine($"File {fileName} created");
            using (StreamWriter writer = new StreamWriter(fileName))  //write to file
            {  
                writer.WriteLine(taskmd.header);
                writer.WriteLine("# "+header); //write markdown header
            }  
        }else{
            Console.WriteLine(" File already exists");
        }
    }
}