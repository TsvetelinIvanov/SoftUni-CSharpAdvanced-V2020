using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleSnake.GameObjects
{
    public class Snake
    {
        private const char SnakeSymbol = '\u25CF';
        private const char EmptySpace = ' ';
        private const int SnakeTailYStartPosition = 1;
        private const int SnakeHeadYStartPosition = 6;
        private const int SnakeXStartPosition = 2;
        private const int FoodTypesCount = 3;

        private int nextLeftX;
        private int nextTopY;
        private int foodIndex;
        private int eatenPointsCount;

        private Queue<Point> snakeElements;
        private Food[] food;
        private Wall wall;

        public Snake(Wall wall)
        {
            this.wall = wall;
            this.snakeElements = new Queue<Point>();
            this.food = new Food[FoodTypesCount];
            this.foodIndex = RandomFoodNumber;
            this.eatenPointsCount = 0;
            this.GetFoods();
            this.CreateSnake();
            this.CreateFood();
        }

        private int RandomFoodNumber => new Random().Next(0, this.food.Length);

        public bool IsMoving(Point direction)
        {
            Point currentSnakeHead = this.snakeElements.Last();
            this.GetNextPoint(direction, currentSnakeHead);
            bool isPointOfSnake = this.snakeElements.Any(se => se.LeftX == this.nextLeftX && se.TopY == this.nextTopY);
            if (isPointOfSnake)
            {
                return false;
            }

            Point snakeNewHead = new Point(this.nextLeftX, this.nextTopY);
            if (this.wall.IsPointOfWall(snakeNewHead))
            {
                return false;
            }

            this.snakeElements.Enqueue(snakeNewHead);
            snakeNewHead.Draw(SnakeSymbol);

            if (this.food[this.foodIndex].IsFoodPoint(snakeNewHead))
            {
                this.Eat(direction, currentSnakeHead);
            }

            Point snakeTail = this.snakeElements.Dequeue();
            snakeTail.Draw(EmptySpace);

            return true;
        }

        public int ReportPoints()
        {
            return this.eatenPointsCount;
        }

        private void CreateSnake()
        {
            for (int topY = SnakeTailYStartPosition; topY <= SnakeHeadYStartPosition; topY++)
            {
                this.snakeElements.Enqueue(new Point(SnakeXStartPosition, topY));
            }
        }

        private void CreateFood()
        {
            this.foodIndex = this.RandomFoodNumber;
            this.food[this.foodIndex].SetRandomPosition(this.snakeElements);
        }

        private void GetFoods()
        {
            this.food[0] = new FoodHash(this.wall);
            this.food[1] = new FoodDollar(this.wall);
            this.food[2] = new FoodAsterisk(this.wall);
        }

        private void GetNextPoint(Point direction, Point snakeHead)
        {
            this.nextLeftX = snakeHead.LeftX + direction.LeftX;
            this.nextTopY = snakeHead.TopY + direction.TopY;
        }

        private void Eat(Point direction, Point currentSnakeHead)
        {
            int length = this.food[this.foodIndex].FoodPoints;
            for (int i = 0; i < length; i++)
            {
                this.snakeElements.Enqueue(new Point(this.nextLeftX, this.nextTopY));
                this.GetNextPoint(direction, currentSnakeHead);
                this.eatenPointsCount++;
            }

            //this.foodIndex = this.RandomFoodNumber;
            //this.food[this.foodIndex].SetRandomPosition(this.snakeElements);
            this.CreateFood();
        }
    }
}