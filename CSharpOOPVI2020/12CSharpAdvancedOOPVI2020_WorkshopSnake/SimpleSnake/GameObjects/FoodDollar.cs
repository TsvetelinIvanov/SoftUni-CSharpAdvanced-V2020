namespace SimpleSnake.GameObjects
{
    public class FoodDollar : Food
    {
        private const char FoodSymbol = '$';
        private const int PointsCount = 2;

        public FoodDollar(Wall wall) : base(wall, FoodSymbol, PointsCount)
        {

        }
    }
}