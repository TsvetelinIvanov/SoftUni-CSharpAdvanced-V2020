namespace SimpleSnake.GameObjects
{
    public class FoodAsterisk : Food
    {
        private const char FoodSymbol = '*';
        private const int PointsCount = 1;

        public FoodAsterisk(Wall wall) : base(wall, FoodSymbol, PointsCount)
        {

        }
    }
}