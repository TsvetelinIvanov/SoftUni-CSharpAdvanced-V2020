using SimpleSnake.Core;
using SimpleSnake.GameObjects;
using SimpleSnake.Utilities;

namespace SimpleSnake
{
    public class StartUp
    {
        public static void Main()
        {
            ConsoleWindow.CustomizeConsole();

            //Point point = new Point(30, 10);
            //point.Draw('a');

            Wall wall = new Wall(60, 20);
            //Food food = new FoodAsterisk(wall);
            //food.SetRandomPosition(new Queue<Point>());
            //food.SetRandomPosition(new Queue<Point>());

            Snake snake = new Snake(wall);
            //snake.IsMoving(new Point(1, 0));
            //snake.IsMoving(new Point(1, 0));
            //snake.IsMoving(new Point(1, 0));
            //snake.IsMoving(new Point(0, 1));
            //snake.IsMoving(new Point(0, 1));
            //snake.IsMoving(new Point(0, 1));

            IEngine engine = new Engine(wall, snake);
            engine.Run();
        }
    }
}