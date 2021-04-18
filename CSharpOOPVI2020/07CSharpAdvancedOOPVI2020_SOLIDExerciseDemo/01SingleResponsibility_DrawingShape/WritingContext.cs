using _01SingleResponsibility_DrawingShape.Contracts;
using System;

namespace _01SingleResponsibility_DrawingShape
{
    public class WritingContext : IDrawingContext
    {
        public void DoSpecificDrawing(IShape shape)
        {
            Console.WriteLine($"Drawing {shape.GetType().Name} with area {shape.Area}.");
        }
    }
}