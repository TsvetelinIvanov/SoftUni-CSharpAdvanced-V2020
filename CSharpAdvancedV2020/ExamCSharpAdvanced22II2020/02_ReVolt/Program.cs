using System;

namespace _02_ReVolt
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int commands = int.Parse(Console.ReadLine());
            char[,] matrix = new char[size, size];
            int playerRow = -1;
            int playerCol = -1;
            for (int row = 0; row < size; row++)
            {
                string currentRow = Console.ReadLine();
                for (int col = 0; col < size; col++)
                {
                    if (currentRow[col] == 'f')
                    {
                        playerRow = row;
                        playerCol = col;
                    }

                    matrix[row, col] = currentRow[col];
                }
            }
            
            bool isWon = false;
            for (int i = 0; i < commands; i++)
            {
                string direction = Console.ReadLine();
                switch (direction)
                {
                    case "up":
                        SetPlayerPositionToDash(playerRow, playerCol, matrix);
                        playerRow--;
                        if (IsOutsideMatrix(playerRow, playerCol, size))
                        {
                            playerRow = size - 1;
                        }

                        if (CheckIfBonus(playerRow, playerCol, matrix))
                        {
                            playerRow--;
                            if (IsOutsideMatrix(playerRow, playerCol, size))
                            {
                                playerRow = size - 1;
                            }
                        }
                        else if (CheckIfTrap(playerRow, playerCol, matrix))
                        {
                            playerRow++;
                            if (IsOutsideMatrix(playerRow, playerCol, size))
                            {
                                playerRow = 0;
                            }
                        }

                        if (CheckIfGoal(playerRow, playerCol, matrix))
                        {
                            isWon = true;
                            SetNewPlayerPosition(playerRow, playerCol, matrix);

                            goto End;
                        }

                        SetNewPlayerPosition(playerRow, playerCol, matrix);
                        break;
                    case "down":
                        SetPlayerPositionToDash(playerRow, playerCol, matrix);
                        playerRow++;
                        if (IsOutsideMatrix(playerRow, playerCol, size))
                        {
                            playerRow = 0;
                        }

                        if (CheckIfBonus(playerRow, playerCol, matrix))
                        {
                            playerRow++;
                            if (IsOutsideMatrix(playerRow, playerCol, size))
                            {
                                playerRow = 0;
                            }
                        }
                        else if (CheckIfTrap(playerRow, playerCol, matrix))
                        {
                            playerRow--;
                            if (IsOutsideMatrix(playerRow, playerCol, size))
                            {
                                playerRow = size - 1;
                            }
                        }

                        if (CheckIfGoal(playerRow, playerCol, matrix))
                        {
                            isWon = true;
                            SetNewPlayerPosition(playerRow, playerCol, matrix);

                            goto End;
                        }

                        SetNewPlayerPosition(playerRow, playerCol, matrix);
                        break;
                    case "left":
                        SetPlayerPositionToDash(playerRow, playerCol, matrix);
                        playerCol--;
                        if (IsOutsideMatrix(playerRow, playerCol, size))
                        {
                            playerCol = size - 1;
                        }

                        if (CheckIfBonus(playerRow, playerCol, matrix))
                        {
                            playerCol--;
                            if (IsOutsideMatrix(playerRow, playerCol, size))
                            {
                                playerCol = size - 1;
                            }
                        }
                        else if (CheckIfTrap(playerRow, playerCol, matrix))
                        {
                            playerCol++;
                            if (IsOutsideMatrix(playerRow, playerCol, size))
                            {
                                playerCol = 0;
                            }
                        }

                        if (CheckIfGoal(playerRow, playerCol, matrix))
                        {
                            isWon = true;
                            SetNewPlayerPosition(playerRow, playerCol, matrix);

                            goto End;
                        }

                        SetNewPlayerPosition(playerRow, playerCol, matrix);
                        break;
                    case "right":
                        SetPlayerPositionToDash(playerRow, playerCol, matrix);
                        playerCol++;
                        if (IsOutsideMatrix(playerRow, playerCol, size))
                        {
                            playerCol = 0;
                        }
                        
                        if (CheckIfBonus(playerRow, playerCol, matrix))
                        {
                            playerCol++;
                            if (IsOutsideMatrix(playerRow, playerCol, size))
                            {
                                playerCol = 0;
                            }
                        }
                        else if (CheckIfTrap(playerRow, playerCol, matrix))
                        {
                            playerCol--;
                            if (IsOutsideMatrix(playerRow, playerCol, size))
                            {
                                playerCol = size - 1;
                            }
                        }
                        
                        if (CheckIfGoal(playerRow, playerCol, matrix))
                        {
                            isWon = true;
                            SetNewPlayerPosition(playerRow, playerCol, matrix);

                            goto End;
                        }

                        SetNewPlayerPosition(playerRow, playerCol, matrix);
                        break;
                }
            }


        End:;
            if (isWon)
            {
                Console.WriteLine($"Player won!");
            }
            else
            {
                Console.WriteLine($"Player lost!");
            }

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }

        public static void SetPlayerPositionToDash(int playerRow, int playerCol, char[,] matrix)
        {
            matrix[playerRow, playerCol] = '-';
        }

        public static bool IsOutsideMatrix(int row, int col, int size)
        {
            if (row >= size || col >= size || row < 0 || col < 0)
            {
                return true;
            }

            return false;
        }
       
        public static bool CheckIfBonus(int playerRow, int PlayerCol, char[,] matrix)
        {
            if (matrix[playerRow, PlayerCol] == 'B')
            {
                return true;
            }

            return false;
        }

        public static bool CheckIfTrap(int playerRow, int PlayerCol, char[,] matrix)
        {
            if (matrix[playerRow, PlayerCol] == 'T')
            {
                return true;
            }

            return false;
        }

        public static bool CheckIfGoal(int playerRow, int PlayerCol, char[,] matrix)
        {
            if (matrix[playerRow, PlayerCol] == 'F')
            {
                return true;
            }

            return false;
        }

        public static void SetNewPlayerPosition(int playerRow, int playerCol, char[,] matrix)
        {
            matrix[playerRow, playerCol] = 'f';
        }
    }
}
