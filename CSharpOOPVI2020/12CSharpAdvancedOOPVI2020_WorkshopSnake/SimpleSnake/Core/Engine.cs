using SimpleSnake.Enums;
using SimpleSnake.GameObjects;
using System;
using System.Threading;

namespace SimpleSnake.Core
{
    public class Engine : IEngine
    {
        private double sleepTime;
        private Direction direction;
        private Point[] pointsOfDirections;
        private Wall wall;
        private Snake snake;

        public Engine(Wall wall, Snake snake)
        {
            this.wall = wall;
            this.snake = snake;
            this.pointsOfDirections = new Point[4];
            this.sleepTime = 100;
        }

        public void Run()
        {
            this.CreateDirections();

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    this.GetNextDirection();

                    bool isMooving = this.snake.IsMoving(this.pointsOfDirections[(int)this.direction]);
                    if (!isMooving)
                    {
                        this.AskUserForRestart();
                    }

                    this.sleepTime -= 0.01;
                    Thread.Sleep((int)this.sleepTime);
                }
            }            
        }

        private void CreateDirections()
        {
            this.pointsOfDirections[0] = new Point(1, 0);
            this.pointsOfDirections[1] = new Point(-1, 0);
            this.pointsOfDirections[2] = new Point(0, 1);
            this.pointsOfDirections[3] = new Point(0, -1);
        }

        private void GetNextDirection()
        {
            ConsoleKeyInfo userInput = Console.ReadKey();
            if (userInput.Key == ConsoleKey.LeftArrow)
            {
                if (this.direction != Direction.Right)
                {
                    this.direction = Direction.Left;
                }
            }
            else if (userInput.Key == ConsoleKey.RightArrow)
            {
                if (this.direction != Direction.Left)
                {
                    this.direction = Direction.Right;
                }
            }
            else if (userInput.Key == ConsoleKey.UpArrow)
            {
                if (this.direction != Direction.Down)
                {
                    this.direction = Direction.Up;
                }
            }
            else if (userInput.Key == ConsoleKey.DownArrow)
            {
                if (this.direction != Direction.Up)
                {
                    this.direction = Direction.Down;
                }
            }

            Console.CursorVisible = false;
        }

        private void AskUserForRestart()
        {
            int leftX = this.wall.LeftX + 1;
            int topY = 3;

            Console.SetCursorPosition(leftX, topY);
            Console.WriteLine("Player points: " + this.snake.ReportPoints());
            Console.WriteLine("Player level: " + this.snake.ReportPoints() / 10);
            Console.Write("Would you like to continue? y(yes)/n(no): ");
            string input = Console.ReadLine();
            if (input.ToLower() == "y")
            {
                Console.Clear();
                StartUp.Main();
            }
            else
            {
                this.StopGame();
            }
        }

        private void StopGame()
        {
            Console.SetCursorPosition(20, 10);
            Console.Write("Game over!");

            Environment.Exit(0);
        }
    }
}