using System;
using System.Collections.Generic;
using System.Linq;

namespace _05SnakeMoves
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] stairsDimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            char[,] stairs = new char[stairsDimensions[0], stairsDimensions[1]];
            Queue<char> snake = new Queue<char>(Console.ReadLine().ToCharArray());
            for (int row = 0; row < stairs.GetLength(0); row++)
            {
                for (int col = 0; col < stairs.GetLength(1); col++)
                {
                    char snakePart = snake.Dequeue();
                    if (row % 2 == 0)
                    {
                        stairs[row, col] = snakePart;
                    }
                    else
                    {
                        stairs[row, stairs.GetLength(1) - col - 1] = snakePart;
                    }
                    
                    snake.Enqueue(snakePart);
                }                
            }

            PrintStairs(stairs);
        }

        private static void PrintStairs(char[,] stairs)
        {
            for (int row = 0; row < stairs.GetLength(0); row++)
            {
                for (int col = 0; col < stairs.GetLength(1); col++)
                {
                    Console.Write(stairs[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}