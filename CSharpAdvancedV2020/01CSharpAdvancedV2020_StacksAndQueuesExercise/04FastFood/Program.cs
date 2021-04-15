using System;
using System.Collections.Generic;
using System.Linq;

namespace _04FastFood
{
    class Program
    {
        static void Main(string[] args)
        {
            int foodQuantity = int.Parse(Console.ReadLine());
            int[] orders = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> ordersQueue = new Queue<int>(orders);
            int maxOrder = ordersQueue.Max();
            ordersQueue = ProcessOrders(ordersQueue, foodQuantity);
            Console.WriteLine(maxOrder);
            if (ordersQueue.Count == 0)
            {
                Console.WriteLine("Orders complete");
            }
            else
            {
                Console.WriteLine("Orders left: " + string.Join(" ", ordersQueue));
            }
        }

        public static Queue<int> ProcessOrders(Queue<int> ordersQueue, int foodQuantity)
        {
            while (ordersQueue.Count > 0)
            {
                int order = ordersQueue.Peek();
                if (foodQuantity >= order)
                {
                    ordersQueue.Dequeue();
                    foodQuantity -= order;
                }
                else
                {                    
                    return ordersQueue;
                }
            }

            return ordersQueue;
        }
    }
}