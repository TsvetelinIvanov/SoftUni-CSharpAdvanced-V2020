using System;

namespace _02BookWorm
{
    class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();
            int shapeSize = int.Parse(Console.ReadLine());
            char[][] shape = new char[shapeSize][];
            int[] playerPosition = new int[2];
            for (int i = 0; i < shapeSize; i++)
            {
                char[] rowValues = Console.ReadLine().ToCharArray();
                shape[i] = new char[shapeSize];
                for (int j = 0; j < shapeSize; j++)
                {                    
                    shape[i][j] = rowValues[j];
                    if (shape[i][j] == 'P')
                    {
                        playerPosition[0] = i;
                        playerPosition[1] = j;                        
                    }
                }
            }

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "end")
            {
                int playerRow = playerPosition[0];
                int playerCol = playerPosition[1];
                switch (command)
                {
                    case "up":
                        Tuple<string, bool> moveDataUp = TryMove(shape, playerPosition, playerRow - 1, playerCol, message);
                        message = moveDataUp.Item1;
                        bool isMoveUp = moveDataUp.Item2;
                        if (isMoveUp)
                        {
                            shape[playerRow][playerCol] = '-';
                        }
                       
                        break;
                    case "down":
                        Tuple<string, bool> moveDataDown = TryMove(shape, playerPosition, playerRow + 1, playerCol, message);
                        message = moveDataDown.Item1;
                        bool isMoveDown = moveDataDown.Item2;
                        if (isMoveDown)
                        {
                            shape[playerRow][playerCol] = '-';
                        }
                        
                        break;
                    case "left":
                        Tuple<string, bool> moveDataLeft = TryMove(shape, playerPosition, playerRow, playerCol - 1, message);
                        message = moveDataLeft.Item1;
                        bool isMoveLeft = moveDataLeft.Item2;
                        if (isMoveLeft)
                        {
                            shape[playerRow][playerCol] = '-';
                        }
                        
                        break;
                    case "right":
                        Tuple<string, bool> moveDataRight = TryMove(shape, playerPosition, playerRow, playerCol + 1, message);
                        message = moveDataRight.Item1;
                        bool isMoveRight = moveDataRight.Item2;
                        if (isMoveRight)
                        {
                            shape[playerRow][playerCol] = '-';
                        }
                        
                        break;
                }                
            }

            Console.WriteLine(message);
            foreach (char[] row in shape)
            {
                Console.WriteLine(string.Join("", row));
            }
        }

        private static Tuple<string, bool> TryMove(char[][] shape, int[] playerPosition, int playerRow, int playerCol, string message)
        {
            bool isMove = false;
            if (!IsInShape(shape, playerRow, playerCol))
            {
                if (!string.IsNullOrEmpty(message))
                {
                    message = message.Substring(0, message.Length - 1);
                }
            }
            else
            {
                if (shape[playerRow][playerCol] != '-')
                {
                    message += shape[playerRow][playerCol];
                }

                shape[playerRow][playerCol] = 'P';
                playerPosition[0] = playerRow;
                playerPosition[1] = playerCol;
                isMove = true;
            }
            
            return new Tuple<string, bool>(message, isMove);
        }

        private static bool IsInShape(char[][] shape, int playerRow, int playerCol)
        {
            return playerRow >= 0 && playerRow < shape.Length && playerCol >= 0 && playerCol < shape[playerRow].Length;
        }
    }
}