using System;
using System.Collections.Generic;
using System.Linq;

namespace _01DatingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> men = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            Queue<int> women = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            int matchesCount = 0;
            while (men.Count > 0 && women.Count > 0)
            {
                int man = men.Peek();
                if (man <= 0)
                {
                    men.Pop();
                    continue;
                }
                else if (man % 25 == 0)
                {
                    men.Pop();
                    men.Pop();
                    continue;
                }

                int woman = women.Dequeue();
                if (woman <= 0)
                {                    
                }
                else if (woman % 25 == 0)
                {
                    women.Dequeue();                    
                }
                else if (woman == man)
                {
                    men.Pop();
                    matchesCount++;
                }
                else if (woman != man)
                {
                    men.Pop();
                    man -= 2;
                    men.Push(man);
                }
            }

            string leftMales = string.Empty;
            if (men.Count == 0)
            {
                leftMales = "none";
            }
            else
            {
                leftMales = string.Join(", ", men);
            }

            string leftFemales = string.Empty;
            if (women.Count == 0)
            {
                leftFemales = "none";
            }
            else
            {
                leftFemales = string.Join(", ", women);
            }

            Console.WriteLine("Matches: " + matchesCount);
            Console.WriteLine("Males left: " + leftMales);
            Console.WriteLine("Females left: " + leftFemales);
        }
    }
}