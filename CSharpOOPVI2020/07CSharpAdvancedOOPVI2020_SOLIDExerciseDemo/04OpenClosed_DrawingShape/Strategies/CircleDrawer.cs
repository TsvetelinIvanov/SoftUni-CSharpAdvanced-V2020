using _04OpenClosed_DrawingShape.Contracts;
using System;

namespace _04OpenClosed_DrawingShape.Strategies
{
    public class CircleDrawer : IDrawingStrategy
    {
        public void Draw(IShape shape)
        {
            Console.WriteLine($"Drawing {shape.GetType().Name} with area {shape.Area:f2}.");
        }

        public bool IsMatch(IShape shape)
        {
            return shape is Circle;
        }
    }
}