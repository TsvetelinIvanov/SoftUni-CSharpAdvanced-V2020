using System;
using System.Collections.Generic;
using System.Linq;

namespace _08Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[,] matrix = ReadMatrix(size);
            Queue<int[]> bombsCoordinates = new Queue<int[]>(Console.ReadLine().Split()
                .Select(x => x.Split(",").Select(int.Parse).ToArray()));

            while (bombsCoordinates.Count > 0)
            {
                int[] currentBombCoordinates = bombsCoordinates.Dequeue();
                int bombRow = currentBombCoordinates[0];
                int bombCol = currentBombCoordinates[1];
                if (matrix[bombRow, bombCol] > 0)
                {
                    matrix = ExplodeBomb(matrix, bombRow, bombCol);
                }               
            }           

            int aliveCellsCount = 0;
            int aliveCellsSum = 0;
            foreach (int cell in matrix)
            {
                if (cell > 0)
                {
                    aliveCellsCount++;
                    aliveCellsSum += cell;
                }
            }

            Console.WriteLine("Alive cells: " + aliveCellsCount);
            Console.WriteLine("Sum: " + aliveCellsSum);
            PrintMatrix(matrix);
        }        

        private static int[,] ReadMatrix(int size)
        {
            int[,] matrix = new int[size, size];
            for (int row = 0; row < size; row++)
            {
                int[] rowValues = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = rowValues[col];
                }
            }

            return matrix;
        }

        private static int[,] ExplodeBomb(int[,] matrix, int bombRow, int bombCol)
        {
            int bombDemage = matrix[bombRow, bombCol];
            matrix[bombRow, bombCol] = 0;
            if (IsInMatrix(matrix, bombRow - 1, bombCol - 1) && matrix[bombRow - 1, bombCol - 1] > 0)
            {
                matrix[bombRow - 1, bombCol - 1] -= bombDemage;
            }

            if (IsInMatrix(matrix, bombRow - 1, bombCol) && matrix[bombRow - 1, bombCol] > 0)
            {
                matrix[bombRow - 1, bombCol] -= bombDemage;
            }

            if (IsInMatrix(matrix, bombRow - 1, bombCol + 1) && matrix[bombRow - 1, bombCol + 1] > 0)
            {
                matrix[bombRow - 1, bombCol + 1] -= bombDemage;
            }

            if (IsInMatrix(matrix, bombRow, bombCol - 1) && matrix[bombRow, bombCol - 1] > 0)
            {
                matrix[bombRow, bombCol - 1] -= bombDemage;
            }

            if (IsInMatrix(matrix, bombRow, bombCol + 1) && matrix[bombRow, bombCol + 1] > 0)
            {
                matrix[bombRow, bombCol + 1] -= bombDemage;
            }

            if (IsInMatrix(matrix, bombRow + 1, bombCol - 1) && matrix[bombRow + 1, bombCol - 1] > 0)
            {
                matrix[bombRow + 1, bombCol - 1] -= bombDemage;
            }

            if (IsInMatrix(matrix, bombRow + 1, bombCol) && matrix[bombRow + 1, bombCol] > 0)
            {
                matrix[bombRow + 1, bombCol] -= bombDemage;
            }

            if (IsInMatrix(matrix, bombRow + 1, bombCol + 1) && matrix[bombRow + 1, bombCol + 1] > 0)
            {
                matrix[bombRow + 1, bombCol + 1] -= bombDemage;
            }

            return matrix;
        }

        private static bool IsInMatrix(int[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
        }

        private static void PrintMatrix(int[,] matrix)
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