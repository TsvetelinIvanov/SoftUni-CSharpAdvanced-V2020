using System;

namespace _07KnightGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] board = new char[size, size];            
            for (int row = 0; row < size; row++)
            {
                char[] rowValues = Console.ReadLine().ToCharArray();
                for (int col = 0; col < size; col++)
                {
                    board[row, col] = rowValues[col];
                }
            }

            int removedKnightsCount = 0;
            while (true)
            {
                int maxAttacksCount = 0;
                int maxAttackerRow = -1;
                int maxAttackerCol = -1;
                for (int row = 0; row < board.GetLength(0); row++)
                {
                    for (int col = 0; col < board.GetLength(1); col++)
                    {
                        int currentAttacksCount = 0;
                        if (board[row, col] == 'K')
                        {
                            currentAttacksCount = GetAttacksCount(board, row, col);                            
                        }

                        if (currentAttacksCount > maxAttacksCount)
                        {
                            maxAttacksCount = currentAttacksCount;
                            maxAttackerRow = row;
                            maxAttackerCol = col;
                        }
                    }
                }

                if (maxAttacksCount == 0)
                {
                    break;
                }

                board[maxAttackerRow, maxAttackerCol] = '0';
                removedKnightsCount++;
            }            

            Console.WriteLine(removedKnightsCount);
        }        

        private static int GetAttacksCount(char[,] board, int row, int col)
        {
            int attacksCount = 0;
            if (IsInBoard(board, row - 2, col - 1) && board[row - 2, col - 1] == 'K')
            {
                attacksCount++;
            }

            if (IsInBoard(board, row - 2, col + 1) && board[row - 2, col + 1] == 'K')
            {
                attacksCount++;
            }

            if (IsInBoard(board, row - 1, col - 2) && board[row - 1, col - 2] == 'K')
            {
                attacksCount++;
            }

            if (IsInBoard(board, row - 1, col + 2) && board[row - 1, col + 2] == 'K')
            {
                attacksCount++;
            }

            if (IsInBoard(board, row + 1, col - 2) && board[row + 1, col - 2] == 'K')
            {
                attacksCount++;
            }

            if (IsInBoard(board, row + 1, col + 2) && board[row + 1, col + 2] == 'K')
            {
                attacksCount++;
            }

            if (IsInBoard(board, row + 2, col - 1) && board[row + 2, col - 1] == 'K')
            {
                attacksCount++;
            }

            if (IsInBoard(board, row + 2, col + 1) && board[row + 2, col + 1] == 'K')
            {
                attacksCount++;
            }

            return attacksCount;
        }

        private static bool IsInBoard(char[,] board, int row, int col)
        {
            return row >= 0 && row < board.GetLength(0) && col >= 0 && col < board.GetLength(1);
        }
    }
}