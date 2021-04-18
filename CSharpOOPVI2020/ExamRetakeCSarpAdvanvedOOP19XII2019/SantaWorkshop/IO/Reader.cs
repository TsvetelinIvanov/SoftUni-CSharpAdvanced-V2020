using SantaWorkshop.IO.Contracts;
using System;

namespace SantaWorkshop.IO
{
    public class Reader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}