using System;
using System.Collections.Generic;
using System.Linq;

namespace _05FashionBoutique
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] clothes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> box = new Stack<int>(clothes);
            int capacity = int.Parse(Console.ReadLine());
            int rack = 0;
            int racksNumber = 0;
            while (box.Count > 0)
            {
                int cloth = box.Peek();
                if (capacity > (rack + cloth))
                {
                    rack += cloth;
                    box.Pop();
                }
                else if (capacity == (rack + cloth))
                {
                    rack = 0;
                    box.Pop();
                    racksNumber++;
                }
                else if (capacity < (rack + cloth))
                {
                    rack = 0;
                    racksNumber++;
                }
            }

            if (rack > 0)
            {
                racksNumber++;
            }

            Console.WriteLine(racksNumber);
        }
    }
}