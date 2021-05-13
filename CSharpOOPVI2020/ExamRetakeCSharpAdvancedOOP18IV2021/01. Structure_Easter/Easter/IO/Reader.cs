using System;
using Easter.IO.Contracts;

namespace Easter.IO
{
    public class Reader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}