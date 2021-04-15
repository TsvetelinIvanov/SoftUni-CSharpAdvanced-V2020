using System;
using System.Linq;

namespace _01DiagonalDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[,] squareMatrix = new int[size, size];
            for (int row = 0; row < size; row++)
            {
                int[] rowValues = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int col = 0; col < size; col++)
                {
                    squareMatrix[row, col] = rowValues[col];
                }
            }

            int leftDiagonalSum = 0;
            int rightDiagonalSum = 0;
            for (int row = 0; row < squareMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < squareMatrix.GetLength(1); col++)
                {
                    if (row == col)
                    {
                        leftDiagonalSum += squareMatrix[row, col];
                        //rightDiagonalSum += squareMatrix[row, squareMatrix.GetLength(1) - 1 - col];
                    }

                    if (row == squareMatrix.GetLength(1) - 1 - col)
                    {
                        rightDiagonalSum += squareMatrix[row, col];
                    }
                }
            }

            int diagonalDifference = Math.Abs(leftDiagonalSum - rightDiagonalSum);
            Console.WriteLine(diagonalDifference);
        }
    }
}