using _07InterfaceSegregation_Worker.Contracts;
using System;

namespace _07InterfaceSegregation_Worker
{
    public class Robot : IWorker
    {       
        public void Work()
        {
            Console.WriteLine("Working...");
        }
    }
}