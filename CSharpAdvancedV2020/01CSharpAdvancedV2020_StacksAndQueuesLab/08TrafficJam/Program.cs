using System;
using System.Collections.Generic;

namespace _08TrafficJam
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Queue<string> carsQueue = new Queue<string>();
            int passedCarsCount = 0;
            string carOrGreenLight;
            while ((carOrGreenLight = Console.ReadLine()) != "end")
            {
                if (carOrGreenLight == "green")
                {
                    for (int i = 0; i < n; i++)
                    {
                        if (carsQueue.Count > 0)
                        {
                            Console.WriteLine(carsQueue.Dequeue() + " passed!");
                            passedCarsCount++;
                        }                        
                    }
                }
                else
                {
                    carsQueue.Enqueue(carOrGreenLight);
                }
            }

            Console.WriteLine(passedCarsCount + " cars passed the crossroads.");
        }
    }
}