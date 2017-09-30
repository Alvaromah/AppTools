using System;

using AppTools;

namespace Win32Tools
{
    class Program
    {
        static void Main(string[] args)
        {
            LoremSample();
        }

        private static void LoremSample()
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
