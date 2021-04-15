using System;
using System.Collections.Generic;

namespace _10Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            int greenLightDuration = int.Parse(Console.ReadLine());
            int freeWindowDuration = int.Parse(Console.ReadLine());
            Queue<string> carsToPass = new Queue<string>();
            Stack<string> passedCars = new Stack<string>();
            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                if (input != "green")
                {
                    carsToPass.Enqueue(input);
                }
                else
                {
                    int currentGreenLight = greenLightDuration;
                    int currentFreeWindow = freeWindowDuration;
                    int carsToPassCount = carsToPass.Count;
                    for (int i = 0; i < carsToPassCount; i++)                    
                    {
                        string car = carsToPass.Peek();
                        if (currentGreenLight >= car.Length)
                        {
                            currentGreenLight -= car.Length;
                            passedCars.Push(carsToPass.Dequeue());
                        }
                        else
                        {
                            int timeLeft = currentGreenLight + currentFreeWindow;
                            if (currentGreenLight == 0)
                            {
                                continue;
                            }
                            else if (timeLeft > 0 && timeLeft >= car.Length)
                            {                                
                                passedCars.Push(carsToPass.Dequeue());
                                currentGreenLight = 0;
                                currentFreeWindow = 0;
                            }
                            else if (timeLeft > 0 && timeLeft < car.Length)
                            {
                                Console.WriteLine("A crash happened!" + Environment.NewLine + $"{car} was hit at {car[timeLeft]}.");

                                return;
                            }
                        }
                    }
                }
            }

            Console.WriteLine("Everyone is safe." + Environment.NewLine + passedCars.Count + " total cars passed the crossroads.");
        }
    }
}