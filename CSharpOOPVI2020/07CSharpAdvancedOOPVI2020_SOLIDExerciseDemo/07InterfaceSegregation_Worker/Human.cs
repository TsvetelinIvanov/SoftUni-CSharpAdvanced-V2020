using _07InterfaceSegregation_Worker.Contracts;
using System;

namespace _07InterfaceSegregation_Worker
{
    public class Human : IWorker, IEater, ISleeper
    {
        public void Eat()
        {
            Console.WriteLine("Eating...");
        }

        public void Sleep()
        {
            Console.WriteLine("Sleeping...");
        }

        public void Work()
        {
            Console.WriteLine("Working...");
        }
    }
}