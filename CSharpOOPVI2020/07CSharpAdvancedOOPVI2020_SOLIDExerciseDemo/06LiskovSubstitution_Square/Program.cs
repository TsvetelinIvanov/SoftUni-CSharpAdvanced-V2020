using System;

namespace _06LiskovSubstitution_Square
{
    class Program
    {
        static void Main(string[] args)
        {
            Rectangle rectangle = new Rectangle(10, 12.1);
            Square square = new Square(1.1);

            Console.WriteLine("{0:f2}", rectangle.Area);//121
            Console.WriteLine("{0:f2}", square.Area);//1.21
        }
    }
}