using System;
using System.Collections.Generic;
using System.Linq;

namespace _07TruckTour
{
    class Program
    {
        static void Main(string[] args)
        {
            int pumpsCount = int.Parse(Console.ReadLine());            
            Queue<int[]> truckInfo = new Queue<int[]>();
            for (int i = 0; i < pumpsCount; i++)
            {
                truckInfo.Enqueue(Console.ReadLine().Split().Select(int.Parse).ToArray());
            }
            
            for (int i = 0; i < pumpsCount; i++)
            {
                bool isCircle = true;
                int petrol = 0;
                for (int j = 0; j < pumpsCount; j++)
                {
                    int[] pumpInfo = truckInfo.Dequeue();
                    petrol += pumpInfo[0] - pumpInfo[1];
                    if (petrol < 0)
                    {
                        isCircle = false;
                    }

                    truckInfo.Enqueue(pumpInfo);
                }

                if (isCircle)
                {
                    Console.WriteLine(i);
                    break;
                }

                truckInfo.Enqueue(truckInfo.Dequeue());
            }            
        }
    }
}