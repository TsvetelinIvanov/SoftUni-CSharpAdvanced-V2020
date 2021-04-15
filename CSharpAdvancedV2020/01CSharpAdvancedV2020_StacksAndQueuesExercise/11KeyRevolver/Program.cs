using System;
using System.Collections.Generic;
using System.Linq;

namespace _11KeyRevolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int usedBullets = 0;
            int gunBarrelSize = int.Parse(Console.ReadLine());
            int gunBarreiCounter = 0;
            int[] bulletsBag = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            Stack<int> bullets = new Stack<int>(bulletsBag);
            Queue<int> locks = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            int intelligenceValue = int.Parse(Console.ReadLine());

            bool isSafeOpened = false;
            while (bullets.Count > 0 && locks.Count > 0)
            {
                int bullet = bullets.Pop();
                usedBullets++;

                int @lock = locks.Peek();
                if (bullet <= @lock)
                {
                    Console.WriteLine("Bang!");
                    locks.Dequeue();

                    if (locks.Count == 0)
                    {
                        isSafeOpened = true;
                    }
                }
                else
                {
                    Console.WriteLine("Ping!");
                }

                gunBarreiCounter++;
                if (gunBarreiCounter == gunBarrelSize && bullets.Count > 0)
                {
                    Console.WriteLine("Reloading!");
                    gunBarreiCounter = 0;
                }
            }
            
            if (isSafeOpened)
            {
                int bulletsCost = usedBullets * bulletPrice;
                int earnedSum = intelligenceValue - bulletsCost;
                Console.WriteLine($"{bullets.Count} bullets left. Earned ${earnedSum}");
            }
            else
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            }
        }
    }
}