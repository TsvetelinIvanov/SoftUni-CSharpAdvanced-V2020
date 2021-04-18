using System;

namespace _10DependencyInversion_Worker
{
    public class Worker : IWorker
    {
        public void Work()
        {
            Console.WriteLine("Working...");
        }
    }
}