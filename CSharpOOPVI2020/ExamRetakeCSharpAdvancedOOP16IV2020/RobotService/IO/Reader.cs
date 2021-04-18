using RobotService.IO.Contracts;
using System;

namespace RobotService.IO
{
    public class Reader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}