﻿namespace SimpleSnake.GameObjects
{
    public class FoodHash : Food
    {
        private const char FoodSymbol = '#';
        private const int PointsCount = 3;

        public FoodHash(Wall wall) : base(wall, FoodSymbol, PointsCount)
        {

        }
    }
}