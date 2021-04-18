namespace _04OpenClosed_DrawingShape
{
    class Program
    {
        static void Main(string[] args)
        {
            Rectangle rectangle = new Rectangle(10, 12);
            Circle circle = new Circle(6.9);
            DrawingManager drawingManager = new DrawingManager();
            drawingManager.Draw(rectangle);//Drawing Rectangle with area 120.00.
            drawingManager.Draw(circle);//Drawing Circle with area 149.57.
        }
    }
}