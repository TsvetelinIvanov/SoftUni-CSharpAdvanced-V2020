using System;

namespace _11DependencyInversion_Database
{
    public class ConsolePrinter : IPrinter
    {
        public void PrintInLine(string data)
        {
            Console.Write(data);
        }

        public void PrintLine(string data)
        {
            Console.WriteLine(data);
        }
    }
}