namespace _01SingleResponsibility_DrawingShape
{
    class Program
    {
        static void Main(string[] args)
        {
            Rectangle rectangle = new Rectangle(10, 12);
            WritingContext writingContext = new WritingContext();
            WritingRenderer writingRenderer = new WritingRenderer();
            DrawingManager drawingManager = new DrawingManager(writingContext, writingRenderer);
            drawingManager.Draw(rectangle);//Drawing Rectangle with area 120.
        }
    }
}