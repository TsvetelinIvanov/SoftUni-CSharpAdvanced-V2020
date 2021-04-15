using System;
using System.Linq;

namespace _03PrimaryDiagonal
{
    class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());
            int[,] matrix = new int[matrixSize, matrixSize];
            for (int rows = 0; rows < matrixSize; rows++)
            {
                int[] rowValues = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int columns = 0; columns < matrixSize; columns++)
                {
                    matrix[rows, columns] = rowValues[columns];
                }
            }

            int primaryDiagonalSum = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (row == col)
                    {
                        primaryDiagonalSum += matrix[row, col];
                    }
                }
            }

            Console.WriteLine(primaryDiagonalSum);
        }
    }
}