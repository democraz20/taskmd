using System;
using System.IO;
using System.Text;

namespace taskmd;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            taskmd.core(args);
        }
        catch(Exception ex)
        {
            Console.WriteLine("Error info : " + ex.Message);
        }
    }
}
