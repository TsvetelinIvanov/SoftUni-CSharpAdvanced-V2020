using System;

namespace _02TronRacers
{
    class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());
            char[,] field = new char[matrixSize, matrixSize];
            int[] firstPlayerPosition = new int[2];
            int[] secondPlayerPosition = new int[2];
            bool isGameOver = false;
            ReadField(field, firstPlayerPosition, secondPlayerPosition);

            while (true)
            {
                string[] directions = Console.ReadLine().Split();
                string firstPlayerDirection = directions[0];
                string secondPlayerDirection = directions[1];
                bool isFirstPlayer = true;
                isGameOver = Move(field, firstPlayerPosition, firstPlayerDirection, isFirstPlayer);
                if (isGameOver)
                {
                    break;
                }

                isFirstPlayer = false;
                isGameOver = Move(field, secondPlayerPosition, secondPlayerDirection, isFirstPlayer);
                if (isGameOver)
                {
                    break;
                }
            }            

            WriteField(field);
        }
        
        private static void ReadField(char[,] field, int[] firstPlayerPosition, int[] secondPlayerPosition)
        {
            for (int row = 0; row < field.GetLength(0); row++)
            {
                char[] rowValues = Console.ReadLine().ToCharArray();
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    field[row, col] = rowValues[col];
                    if (field[row, col] == 'f')
                    {
                        firstPlayerPosition[0] = row;
                        firstPlayerPosition[1] = col;
                    }
                    else if (field[row, col] == 's')
                    {
                        secondPlayerPosition[0] = row;
                        secondPlayerPosition[1] = col;
                    }
                }
            }
        }

        private static bool Move(char[,] field, int[] playerPosition, string direction, bool isFirstPlayer)
        {
            int playerRow = playerPosition[0];
            int playerCol = playerPosition[1];
            switch (direction)
            {
                case "up":
                    playerRow--;
                    if (!IsInField(field, playerRow, playerCol))
                    {
                        playerRow = field.GetLength(0) - 1;
                    }

                    if (field[playerRow, playerCol] != '*')
                    {
                        field[playerRow, playerCol] = 'x';

                        return true;
                    }
                    else
                    {
                        if (isFirstPlayer)
                        {
                            field[playerRow, playerCol] = 'f';
                        }
                        else
                        {
                            field[playerRow, playerCol] = 's';
                        }
                    }

                    break;
                case "down":
                    playerRow++;
                    if (!IsInField(field, playerRow, playerCol))
                    {
                        playerRow = 0;
                    }

                    if (field[playerRow, playerCol] != '*')
                    {
                        field[playerRow, playerCol] = 'x';

                        return true;
                    }
                    else
                    {
                        if (isFirstPlayer)
                        {
                            field[playerRow, playerCol] = 'f';
                        }
                        else
                        {
                            field[playerRow, playerCol] = 's';
                        }
                    }

                    break;
                case "left":
                    playerCol--;
                    if (!IsInField(field, playerRow, playerCol))
                    {
                        playerCol = field.GetLength(1) - 1;
                    }

                    if (field[playerRow, playerCol] != '*')
                    {
                        field[playerRow, playerCol] = 'x';

                        return true;
                    }
                    else
                    {
                        if (isFirstPlayer)
                        {
                            field[playerRow, playerCol] = 'f';
                        }
                        else
                        {
                            field[playerRow, playerCol] = 's';
                        }
                    }

                    break;
                case "right":
                    playerCol++;
                    if (!IsInField(field, playerRow, playerCol))
                    {
                        playerCol = 0;
                    }

                    if (field[playerRow, playerCol] != '*')
                    {
                        field[playerRow, playerCol] = 'x';

                        return true;
                    }
                    else
                    {
                        if (isFirstPlayer)
                        {
                            field[playerRow, playerCol] = 'f';
                        }
                        else
                        {
                            field[playerRow, playerCol] = 's';
                        }
                    }

                    break;
                default:
                    throw new InvalidOperationException("Inexistent direction!");                    
            }

            playerPosition[0] = playerRow;
            playerPosition[1] = playerCol;

            return false;
        }

        private static bool IsInField(char[,] field, int playerRow, int playerCol)
        {
            return playerRow >= 0 && playerRow < field.GetLength(0) && playerCol >= 0 && playerCol < field.GetLength(1);
        }

        private static void WriteField(char[,] field)
        {
            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    Console.Write(field[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}
