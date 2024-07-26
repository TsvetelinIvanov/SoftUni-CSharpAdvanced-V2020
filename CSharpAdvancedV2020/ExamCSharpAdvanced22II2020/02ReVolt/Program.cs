using System;

namespace _02ReVolt
{
    class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());
            int directionsCount = int.Parse(Console.ReadLine());
            char[,] matrix = new char[matrixSize, matrixSize];
            int[] playerPosition = new int[2];
            bool isWon = false;
            ReadMatrix(matrix, playerPosition);            

            for (int i = 0; i < directionsCount; i++)
            {
                int playerRow = playerPosition[0];
                int playerCol = playerPosition[1];
                string direction = Console.ReadLine();
                switch (direction)
                {
                    case "up":
                        int newPlayerRowUp = playerRow - 1;
                        matrix[playerRow, playerCol] = '-';
                        if (!IsInMatrix(matrix, newPlayerRowUp, playerCol))
                        {
                            newPlayerRowUp = matrix.GetLength(0) - 1;                            
                        }
                                                                       
                        if (matrix[newPlayerRowUp, playerCol] == 'B')
                        {                            
                            newPlayerRowUp--;
                            if (!IsInMatrix(matrix, newPlayerRowUp, playerCol))
                            {
                                newPlayerRowUp = matrix.GetLength(0) - 1;                                
                            }                            
                        }
                        else if (matrix[newPlayerRowUp, playerCol] == 'T')
                        {
                            newPlayerRowUp = playerRow;
                        }

                        if (matrix[newPlayerRowUp, playerCol] == 'F')
                        {
                            isWon = true;
                        }

                        matrix[newPlayerRowUp, playerCol] = 'f';
                        playerPosition[0] = newPlayerRowUp;
                        break;
                    case "down":
                        int newPlayerRowDown = playerRow + 1;
                        matrix[playerRow, playerCol] = '-';
                        if (!IsInMatrix(matrix, newPlayerRowDown, playerCol))
                        {
                            newPlayerRowDown = 0;
                        }
                        
                        if (matrix[newPlayerRowDown, playerCol] == 'B')
                        {
                            newPlayerRowDown++;
                            if (!IsInMatrix(matrix, newPlayerRowDown, playerCol))
                            {
                                newPlayerRowDown = 0;
                            }
                        }
                        else if (matrix[newPlayerRowDown, playerCol] == 'T')
                        {
                            newPlayerRowDown = playerRow;
                        }

                        if (matrix[newPlayerRowDown, playerCol] == 'F')
                        {
                            isWon = true;
                        }

                        matrix[newPlayerRowDown, playerCol] = 'f';
                        playerPosition[0] = newPlayerRowDown;
                        break;
                    case "left":
                        int newPlayerColLeft = playerCol - 1;
                        matrix[playerRow, playerCol] = '-';
                        if (!IsInMatrix(matrix, playerRow, newPlayerColLeft))
                        {
                            newPlayerColLeft = matrix.GetLength(1) - 1;
                        }
                        
                        if (matrix[playerRow, newPlayerColLeft] == 'B')
                        {
                            newPlayerColLeft--;
                            if (!IsInMatrix(matrix, playerRow, newPlayerColLeft))
                            {
                                newPlayerColLeft = matrix.GetLength(1) - 1;
                            }
                        }
                        else if (matrix[playerRow, newPlayerColLeft] == 'T')
                        {
                            newPlayerColLeft = playerCol;
                        }

                        if (matrix[playerRow, newPlayerColLeft] == 'F')
                        {
                            isWon = true;
                        }

                        matrix[playerRow, newPlayerColLeft] = 'f';
                        playerPosition[1] = newPlayerColLeft;
                        break;
                    case "right":
                        int newPlayerColRight = playerCol + 1;
                        matrix[playerRow, playerCol] = '-';
                        if (!IsInMatrix(matrix, playerRow, newPlayerColRight))
                        {
                            newPlayerColRight = 0;
                        }
                        
                        if (matrix[playerRow, newPlayerColRight] == 'B')
                        {
                            newPlayerColRight++;
                            if (!IsInMatrix(matrix, playerRow, newPlayerColRight))
                            {
                                newPlayerColRight = 0;
                            }
                        }
                        else if (matrix[playerRow, newPlayerColRight] == 'T')
                        {
                            newPlayerColRight = playerCol;
                        }

                        if (matrix[playerRow, newPlayerColRight] == 'F')
                        {
                            isWon = true;
                        }

                        matrix[playerRow, newPlayerColRight] = 'f';
                        playerPosition[1] = newPlayerColRight;
                        break;
                    default:
                        break;
                        //throw new InvalidOperationException("Invalid command!");
                }

                if (isWon == true)
                {
                    break;
                }
            }

            if (isWon)
            {
                Console.WriteLine("Player won!");
            }
            else
            {
                Console.WriteLine("Player lost!");
            }

            PrintMatrix(matrix);
        }

        private static void ReadMatrix(char[,] matrix, int[] playerPosition)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                char[] rowValues = Console.ReadLine().ToCharArray();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = rowValues[j];
                    if (matrix[i, j] == 'f')
                    {
                        playerPosition[0] = i;
                        playerPosition[1] = j;
                    }
                }
            }
        }

        private static bool IsInMatrix(char[,] matrix, int playerRow, int playerCol)
        {
            return playerRow >= 0 && playerRow < matrix.GetLength(0) && playerCol >= 0 && playerCol < matrix.GetLength(1);
        }

        private static void PrintMatrix(char[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j]);
                }

                Console.WriteLine();
            }
        }        
    }
}
