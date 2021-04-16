using System;

namespace _02Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            int shapeSize = int.Parse(Console.ReadLine());
            char[,] shape = new char[shapeSize, shapeSize];
            int[] snakePosition = new int[2];
            int[] burrowsPositions = new int[4];
            burrowsPositions[0] = -1;
            int foodEaten = 0;
            bool isGameOver = false;
            ReadShape(shape, snakePosition, burrowsPositions);

            while (true)
            {
                string direction = Console.ReadLine();
                int snakeRow = snakePosition[0];
                int snakeCol = snakePosition[1];
                switch (direction)
                {
                    case "up":
                        shape[snakeRow, snakeCol] = '.';
                        snakeRow--;
                        if (!IsInShape(shape, snakeRow, snakeCol))
                        {
                            isGameOver = true;
                            break;
                        }

                        foodEaten = Move(shape, snakePosition, burrowsPositions, snakeRow, snakeCol, foodEaten);              
                        break;
                    case "down":
                        shape[snakeRow, snakeCol] = '.';
                        snakeRow++;
                        if (!IsInShape(shape, snakeRow, snakeCol))
                        {
                            isGameOver = true;
                            break;
                        }

                        foodEaten = Move(shape, snakePosition, burrowsPositions, snakeRow, snakeCol, foodEaten);
                        break;
                    case "left":
                        shape[snakeRow, snakeCol] = '.';
                        snakeCol--;
                        if (!IsInShape(shape, snakeRow, snakeCol))
                        {
                            isGameOver = true;
                            break;
                        }

                        foodEaten = Move(shape, snakePosition, burrowsPositions, snakeRow, snakeCol, foodEaten);
                        break;
                    case "right":
                        shape[snakeRow, snakeCol] = '.';
                        snakeCol++;
                        if (!IsInShape(shape, snakeRow, snakeCol))
                        {
                            isGameOver = true;
                            break;
                        }

                        foodEaten = Move(shape, snakePosition, burrowsPositions, snakeRow, snakeCol, foodEaten);
                        break;
                    default:
                        throw new InvalidOperationException("Unexisting direction!");
                }

                if (foodEaten>= 10 || isGameOver)
                {
                    break;
                }                
            }

            if (foodEaten >= 10)
            {
                Console.WriteLine("You won! You fed the snake.");
            }
            else
            {
                Console.WriteLine("Game over!");
            }

            Console.WriteLine("Food eaten: " + foodEaten);
            WriteShape(shape);
        }
        
        private static void ReadShape(char[,] shape, int[] snakePosition, int[] burrowsPositions)
        {
            for (int row = 0; row < shape.GetLength(0); row++)
            {
                char[] rowValues = Console.ReadLine().ToCharArray();
                for (int col = 0; col < shape.GetLength(1); col++)
                {
                    shape[row, col] = rowValues[col];
                    if (shape[row, col] == 'S')
                    {
                        snakePosition[0] = row;
                        snakePosition[1] = col;
                    }
                    else if (shape[row, col] == 'B')
                    {
                        if (burrowsPositions[0] < 0)
                        {
                            burrowsPositions[0] = row;
                            burrowsPositions[1] = col;
                        }
                        else
                        {
                            burrowsPositions[2] = row;
                            burrowsPositions[3] = col;
                        }
                    }
                }
            }
        }

        private static bool IsInShape(char[,] field, int playerRow, int playerCol)
        {
            return playerRow >= 0 && playerRow < field.GetLength(0) && playerCol >= 0 && playerCol < field.GetLength(1);
        }

        private static int Move(char[,] shape, int[] snakePosition, int[] burrowsPositions, int snakeRow, int snakeCol, int foodEaten)
        {
            if (shape[snakeRow, snakeCol] == '*')
            {
                foodEaten++;
            }
            else if (shape[snakeRow, snakeCol] == 'B' && burrowsPositions[0] == snakeRow && burrowsPositions[1] == snakeCol)
            {
                shape[snakeRow, snakeCol] = '.';
                snakeRow = burrowsPositions[2];
                snakeCol = burrowsPositions[3];
            }
            else if (shape[snakeRow, snakeCol] == 'B' && burrowsPositions[2] == snakeRow && burrowsPositions[3] == snakeCol)
            {
                shape[snakeRow, snakeCol] = '.';
                snakeRow = burrowsPositions[0];
                snakeCol = burrowsPositions[1];
            }

            shape[snakeRow, snakeCol] = 'S';
            snakePosition[0] = snakeRow;
            snakePosition[1] = snakeCol;

            return foodEaten;
        }

        private static void WriteShape(char[,] field)
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