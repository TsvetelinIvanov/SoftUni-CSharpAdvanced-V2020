using System;

namespace _04SynbolInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());
            char[,] charMatrix = new char[matrixSize, matrixSize];
            for (int rows = 0; rows < matrixSize; rows++)
            {
                char[] rowValues = Console.ReadLine().ToCharArray();
                for (int columns = 0; columns < matrixSize; columns++)
                {
                    charMatrix[rows, columns] = rowValues[columns];
                }
            }

            char searchedChar = char.Parse(Console.ReadLine());
            int charRow = -1;
            int charCol = -1;
            bool isSearchedFound = false;
            for (int row = 0; row < charMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < charMatrix.GetLength(1); col++)
                {
                    if (charMatrix[row, col] == searchedChar)
                    {
                        charRow = row;
                        charCol = col;
                        isSearchedFound = true;
                        break;
                    }                    
                }

                if (isSearchedFound == true)
                {
                    break;
                }
            }

            if (isSearchedFound)
            {
                Console.WriteLine($"({charRow}, {charCol})");
            }
            else
            {
                Console.WriteLine(searchedChar + " does not occur in the matrix");
            }
        }
    }
}