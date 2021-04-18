using AquaShop.IO.Contracts;
using System;

namespace AquaShop.IO
{
    public class Reader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}