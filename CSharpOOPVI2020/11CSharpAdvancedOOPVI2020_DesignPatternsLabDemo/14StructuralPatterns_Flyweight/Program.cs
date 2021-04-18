using System;

namespace _14StructuralPatterns_Flyweight
{
    class Program
    {
        static void Main(string[] args)
        {
            ShapeObjectFactory sof = new ShapeObjectFactory();

            IShape shape = sof.GetShape("Triangle");
            shape.Print();//Printing Triangle
            shape = sof.GetShape("Triangle");
            shape.Print();//Printing Triangle
            shape = sof.GetShape("Triangle");
            shape.Print();//Printing Triangle

            shape = sof.GetShape("Square");
            shape.Print();//Printing Square
            shape = sof.GetShape("Square");
            shape.Print();//Printing Square
            shape = sof.GetShape("Square");
            shape.Print();//Printing Square

            int total = sof.TotalObjectsCreated;
            Console.WriteLine($"{Environment.NewLine} Number of objects created = {total}");//Number of objects created = 2
        }
    }
}