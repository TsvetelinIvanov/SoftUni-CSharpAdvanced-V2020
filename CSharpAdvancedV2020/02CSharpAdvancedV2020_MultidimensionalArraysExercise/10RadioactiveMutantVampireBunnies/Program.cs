using System;
using System.Collections.Generic;
using System.Linq;

namespace _10RadioactiveMutantVampireBunnies
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] lairDimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            char[,] lair = new char[lairDimensions[0], lairDimensions[1]];
            char[,] bunnyLair = new char[lairDimensions[0], lairDimensions[1]];
            int[] playerPosition = new int[2];
            for (int row = 0; row < lairDimensions[0]; row++)
            {
                char[] rowValues = Console.ReadLine().ToCharArray();
                for (int col = 0; col < lairDimensions[1]; col++)
                {
                    lair[row, col] = rowValues[col];
                    bunnyLair[row, col] = rowValues[col];
                    if (lair[row, col] == 'P')
                    {
                        playerPosition[0] = row;
                        playerPosition[1] = col;
                    }
                }
            }

            Queue<char> directions = new Queue<char>(Console.ReadLine().ToCharArray());
            bool isDead = false;
            bool isWon = false;
            int lastCellRow = 0;
            int lastCellCol = 0;
            while (true)
            {
                char moveDirection = directions.Dequeue();
                int row = playerPosition[0];
                int col = playerPosition[1];
                switch (moveDirection)
                {
                    case 'U':
                        if (row == 0)
                        {
                            isWon = true;
                            lastCellRow = row;
                            lastCellCol = col;
                            lair[row, col] = '.';
                            bunnyLair[row, col] = '.';
                        }
                        else if (lair[row - 1, col] == 'B')
                        {
                            isDead = true;
                            lastCellCol = row - 1;
                            lastCellCol = col;
                            lair[row, col] = '.';
                            bunnyLair[row, col] = '.';
                        }
                        else if (lair[row - 1, col] == '.')
                        {
                            lair[row - 1, col] = 'P';
                            bunnyLair[row - 1, col] = 'P';
                            lair[row, col] = '.';
                            bunnyLair[row, col] = '.';
                            playerPosition[0] = row - 1;
                        }
                        break;
                    case 'D':
                        if (row == lair.GetLength(0) - 1)
                        {
                            isWon = true;
                            lastCellRow = row;
                            lastCellCol = col;
                            lair[row, col] = '.';
                            bunnyLair[row, col] = '.';
                        }
                        else if (lair[row + 1, col] == 'B')
                        {
                            isDead = true;
                            lastCellRow = row + 1;
                            lastCellCol = col;
                            lair[row, col] = '.';
                            bunnyLair[row, col] = '.';
                        }
                        else if (lair[row + 1, col] == '.')
                        {
                            lair[row + 1, col] = 'P';
                            bunnyLair[row + 1, col] = 'P';
                            lair[row, col] = '.';
                            bunnyLair[row, col] = '.';
                            playerPosition[0] = row + 1;
                        }
                        break;
                    case 'L':
                        if (col == 0)
                        {
                            isWon = true;
                            lastCellRow = row;
                            lastCellCol = col;
                            lair[row, col] = '.';
                            bunnyLair[row, col] = '.';
                        }
                        else if (lair[row, col - 1] == 'B')
                        {
                            isDead = true;
                            lastCellRow = row;
                            lastCellCol = col - 1;
                            lair[row, col] = '.';
                            bunnyLair[row, col] = '.';
                        }
                        else if (lair[row, col - 1] == '.')
                        {
                            lair[row, col - 1] = 'P';
                            bunnyLair[row, col - 1] = 'P';
                            lair[row, col] = '.';
                            bunnyLair[row, col] = '.';
                            playerPosition[1] = col - 1;
                        }
                        break;
                    case 'R': 
                        if (col == lair.GetLength(1) - 1)
                        {
                            isWon = true;
                            lastCellRow = row;
                            lastCellCol = col;
                            lair[row, col] = '.';
                            bunnyLair[row, col] = '.';
                        }
                        else if (lair[row, col + 1] == 'B')
                        {
                            isDead = true;
                            lastCellRow = row;
                            lastCellCol = col + 1;
                            lair[row, col] = '.';
                            bunnyLair[row, col] = '.';
                        }
                        else if (lair[row, col + 1] == '.')
                        {
                            lair[row, col + 1] = 'P';
                            bunnyLair[row, col + 1] = 'P';
                            lair[row, col] = '.';
                            bunnyLair[row, col] = '.';
                            playerPosition[1] = col + 1;
                        }
                        break;
                }

                for (int r = 0; r < lair.GetLength(0); r++)
                {
                    for (int c = 0; c < lair.GetLength(1); c++)
                    {
                        if (lair[r, c] == 'B')
                        {
                            if (IsInLair(lair, r - 1, c))
                            {
                                if (lair[r - 1, c] == 'P')
                                {
                                    isDead = true;
                                    lastCellRow = r - 1;
                                    lastCellCol = c;
                                }

                                bunnyLair[r - 1, c] = 'B';
                            }

                            if (IsInLair(lair, r + 1, c))
                            {
                                if (lair[r + 1, c] == 'P')
                                {
                                    isDead = true;
                                    lastCellRow = r + 1;
                                    lastCellCol = c;
                                }

                                bunnyLair[r + 1, c] = 'B';
                            }

                            if (IsInLair(lair, r, c - 1))
                            {
                                if (lair[r, c - 1] == 'P')
                                {
                                    isDead = true;
                                    lastCellRow = r;
                                    lastCellCol = c - 1;
                                }

                                bunnyLair[r, c - 1] = 'B';
                            }

                            if (IsInLair(lair, r, c + 1))
                            {
                                if (lair[r, c + 1] == 'P')
                                {
                                    isDead = true;
                                    lastCellRow = r;
                                    lastCellCol = c + 1;
                                }

                                bunnyLair[r, c + 1] = 'B';
                            }
                        }
                    }
                }

                for (int r = 0; r < lair.GetLength(0); r++)
                {
                    for (int c = 0; c < lair.GetLength(1); c++)
                    {
                        lair[r, c] = bunnyLair[r, c];
                    }
                }

                if (isDead || isWon)
                {
                    break;
                }
            }

            PrintLair(lair);

            string playerStatus = string.Empty;
            if (isWon) 
            {
                playerStatus = "won";
            }
            else if (isDead)
            {
                playerStatus = "dead";
            }

            Console.WriteLine($"{playerStatus}: {lastCellRow} {lastCellCol}");
        }

        private static bool IsInLair(char[,] lair, int row, int col)
        {
            return row >= 0 && row < lair.GetLength(0) && col >= 0 && col < lair.GetLength(1);
        }

        private static void PrintLair(char[,] lair)
        {
            for (int row = 0; row < lair.GetLength(0); row++)
            {
                for (int col = 0; col < lair.GetLength(1); col++)
                {
                    Console.Write(lair[row, col]);
                }

                Console.WriteLine();
            }
        }        
    }
}