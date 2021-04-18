using EasterRaces.IO.Contracts;
using System;

namespace EasterRaces.IO
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}