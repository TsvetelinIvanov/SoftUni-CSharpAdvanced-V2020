using System;
using System.Linq;

namespace _06JaggedArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            double[][] jagged = new double[size][];
            for (int row = 0; row < size; row++)
            {
                jagged[row] = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();
                if (row > 0 && jagged[row].Length == jagged[row - 1].Length)
                {
                    for (int col = 0; col < jagged[row].Length; col++)
                    {
                        jagged[row][col] *= 2;
                        jagged[row - 1][col] *= 2;
                    }
                }
                else if (row > 0 && jagged[row].Length != jagged[row - 1].Length)
                {
                    for (int col = 0; col < jagged[row].Length; col++)
                    {
                        jagged[row][col] /= 2;                        
                    }

                    for (int col = 0; col < jagged[row - 1].Length; col++)
                    {                        
                        jagged[row - 1][col] /= 2;
                    }
                }
            }

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] inputData = input.Split();
                string command = inputData[0];
                int row = int.Parse(inputData[1]);
                int col = int.Parse(inputData[2]);
                int value = int.Parse(inputData[3]);

                if (IsInJaggedMatrix(jagged, row, col))
                {
                    switch (command)
                    {
                        case "Add":
                            jagged[row][col] += value;
                            break;
                        case "Subtract":
                            jagged[row][col] -= value;
                            break;
                        default:
                            continue;
                    }
                }
            }

            PrintJagged(jagged);
        }

        private static bool IsInJaggedMatrix(double[][] jagged, int row, int col)
        {
            return row >= 0 && row < jagged.Length && col >= 0 && col < jagged[row].Length;
        }

        private static void PrintJagged(double[][] jagged)
        {
            foreach (double[] row in jagged)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }        
    }
}
