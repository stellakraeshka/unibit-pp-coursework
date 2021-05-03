using System;
using System.IO;

namespace Kursova_Rabota_PP
{
    class Program
    {
        static void Main(string[] args)
        {
            // Uncomment following lines to read input from a file instead of console

            //using (StreamReader reader = new StreamReader("input.txt"))
            //{
                //Console.SetIn(reader);
                Engine engine = new Engine();
                engine.Run();
            //}
            
        }
    }
}
