using CounterStrike.IO.Contracts;
using System;

namespace CounterStrike.IO
{
    public class Reader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}