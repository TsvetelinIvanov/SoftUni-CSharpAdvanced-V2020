using System;
using System.Collections.Generic;
using System.Linq;

namespace _12CupsAndBottles
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> cups = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            Stack<int> bottles = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            //int notFulfiledCup = 0;
            int wastedWater = 0;            

            while (cups.Count > 0 && bottles.Count > 0)
            {
                int cup = cups.Peek();                
                int bottle = bottles.Pop();
                if (cup <= bottle)
                {
                    wastedWater += bottle - cup;
                    cups.Dequeue();
                }
                else
                {
                    int cupCapacity = cup;
                    cupCapacity -= bottle;
                    //while (cupCapacity > 0 && bottles.Count > 0)
                    while (cupCapacity > 0)                                        
                        {
                        int newBottle = bottles.Pop();
                        if (cupCapacity <= newBottle)
                        {
                            wastedWater += newBottle - cupCapacity;
                            break;
                        }
                        else
                        {
                            cupCapacity -= newBottle;
                        }
                    }

                    //notFulfiledCup = cupCapacity;
                    //notFulfiledCup = cups.Dequeue();
                    cups.Dequeue();
                }
            }

            if (cups.Count > 0)
            {
                //if (notFulfiledCup > 0)
                //{
                //    Console.WriteLine("Cups: " + notFulfiledCup + " " + string.Join(" ", cups));
                //}
                
                Console.WriteLine("Cups: " + string.Join(" ", cups));
            }
            else
            {
                Console.WriteLine("Bottles: " + string.Join(" ", bottles));
            }

            Console.WriteLine("Wasted litters of water: " + wastedWater);
        }
    }
}
