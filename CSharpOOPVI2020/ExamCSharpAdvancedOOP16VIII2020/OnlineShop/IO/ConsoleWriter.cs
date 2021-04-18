using System;

namespace OnlineShop.IO
{
    public class ConsoleWriter : IWriter
    {
        public void CustomWrite(string text)
        {
            Console.Write(text);
        }

        public void CustomWriteLine(string text)
        {
            Console.WriteLine(text);
        }        
    }
}