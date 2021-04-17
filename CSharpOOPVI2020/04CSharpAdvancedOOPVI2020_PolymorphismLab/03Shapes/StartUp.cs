using System;

namespace Shapes
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Circle circle = new Circle(6.1);
            Rectangle rectangle = new Rectangle(7.1, 10);

            Console.WriteLine(circle);            
            Console.WriteLine(rectangle);
        }
    }
}