using System;

namespace Win32Tools
{
    static public class SampleLorem
    {
        static public void Run()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(Lorem.Generate(10));
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(Lorem.Generate(40));
            Console.WriteLine();
            Console.WriteLine(Lorem.Generate(60));
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(Lorem.Generate(10));
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(Lorem.Generate(50));
            Console.WriteLine();
            Console.WriteLine(Lorem.Generate(40));
            Console.WriteLine();
        }
    }
}
