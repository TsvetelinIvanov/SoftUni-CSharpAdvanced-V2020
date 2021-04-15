using System;
using System.Linq;

namespace _04MatrixShuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSize = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string[,] matrix = new string[matrixSize[0], matrixSize[1]];
            for (int row = 0; row < matrixSize[0]; row++)
            {
                string[] rowValues = Console.ReadLine().Split();
                for (int col = 0; col < matrixSize[1]; col++)
                {
                    matrix[row, col] = rowValues[col];
                }
            }

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] inputData = input.Split();
                if (inputData.Length != 5)
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                string command = inputData[0];
                bool isRowSwapping = int.TryParse(inputData[1], out int rowSwapping);
                bool isColSwapping = int.TryParse(inputData[2], out int colSwapping);
                bool isRowSwapped = int.TryParse(inputData[3], out int rowSwapped);
                bool isColSwapped = int.TryParse(inputData[4], out int colSwapped);

                if (command != "swap" || !isRowSwapping || !isColSwapping || !isRowSwapped || !isColSwapped)
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                if (!IsInMatrix(matrix, rowSwapping, colSwapping) || !IsInMatrix(matrix, rowSwapped, colSwapped))
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                string temp = matrix[rowSwapping, colSwapping];
                matrix[rowSwapping, colSwapping] = matrix[rowSwapped, colSwapped];
                matrix[rowSwapped, colSwapped] = temp;

                PrintMatrix(matrix);
            }
        }

        private static bool IsInMatrix(string[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);      
        }

        private static void PrintMatrix(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}