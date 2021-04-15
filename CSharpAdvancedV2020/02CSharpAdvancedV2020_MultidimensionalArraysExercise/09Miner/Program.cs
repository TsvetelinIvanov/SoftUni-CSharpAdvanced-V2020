using System;
using System.Collections.Generic;

namespace _09Miner
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            Queue<string> directions = new Queue<string>(Console.ReadLine().Split());
            int[] minerCoordinates = new int[2];
            int coalsCount = 0;
            string[,] field = new string[size, size];
            for (int row = 0; row < size; row++)
            {
                string[] rowValues = Console.ReadLine().Split();
                for (int col = 0; col < size; col++)
                {
                    field[row, col] = rowValues[col];
                    if (field[row, col] == "s")
                    {
                        minerCoordinates[0] = row;
                        minerCoordinates[1] = col;
                        field[row, col] = "*";
                    }
                    else if (field[row, col] == "c")
                    {
                        coalsCount++;
                    }
                }
            }

            bool isRouteEnded = false;
            while (directions.Count > 0)
            {
                string direction = directions.Dequeue();
                int row = minerCoordinates[0];
                int col = minerCoordinates[1];
                switch (direction)
                {
                    case "up":
                        if (IsInField(field, row - 1, col))
                        {
                            switch (field[row - 1, col])
                            {
                                case "c":
                                    coalsCount--;
                                    field[row - 1, col] = "*";
                                    minerCoordinates[0] = row - 1;
                                    break;
                                case "e":
                                    isRouteEnded = true;
                                    minerCoordinates[0] = row - 1;
                                    break;
                                case "*":
                                    minerCoordinates[0] = row - 1;
                                    break;
                            }
                        }
                        break;
                    case "down":
                        if (IsInField(field, row + 1, col))
                        {
                            switch (field[row + 1, col])
                            {
                                case "c":
                                    coalsCount--;
                                    field[row + 1, col] = "*";
                                    minerCoordinates[0] = row + 1;
                                    break;
                                case "e":
                                    isRouteEnded = true;
                                    minerCoordinates[0] = row + 1;
                                    break;
                                case "*":
                                    minerCoordinates[0] = row + 1;
                                    break;
                            }
                        }
                        break;
                    case "left":
                        if (IsInField(field, row, col - 1))
                        {
                            switch (field[row, col - 1])
                            {
                                case "c":
                                    coalsCount--;
                                    field[row, col - 1] = "*";
                                    minerCoordinates[1] = col - 1;
                                    break;
                                case "e":
                                    isRouteEnded = true;
                                    minerCoordinates[1] = col - 1;
                                    break;
                                case "*":
                                    minerCoordinates[1] = col - 1;
                                    break;
                            }
                        }
                        break;
                    case "right":
                        if (IsInField(field, row, col + 1))
                        {
                            switch (field[row, col + 1])
                            {
                                case "c":
                                    coalsCount--;
                                    field[row, col + 1] = "*";
                                    minerCoordinates[1] = col + 1;
                                    break;
                                case "e":
                                    isRouteEnded = true;
                                    minerCoordinates[1] = col + 1;
                                    break;
                                case "*":
                                    minerCoordinates[1] = col + 1;
                                    break;
                            }
                        }

                        break;
                }

                if (coalsCount == 0 || isRouteEnded)
                {
                    break;
                }
            }

            if (coalsCount == 0)
            {
                Console.WriteLine($"You collected all coals! ({minerCoordinates[0]}, {minerCoordinates[1]})");
            }
            else if (isRouteEnded)
            {
                Console.WriteLine($"Game over! ({minerCoordinates[0]}, {minerCoordinates[1]})");
            }
            else
            {
                Console.WriteLine($"{coalsCount} coals left. ({minerCoordinates[0]}, {minerCoordinates[1]})");
            }
        }

        private static bool IsInField(string[,] field, int row, int col)
        {
            return row >= 0 && row < field.GetLength(0) && col >= 0 && col < field.GetLength(1);
        }
    }
}