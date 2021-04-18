namespace _02GraphicEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            Circle circle = new Circle();
            Rectangle rectangle = new Rectangle();
            Square square = new Square();
            GraphicEditor graphicEditor = new GraphicEditor();

            graphicEditor.DrawShape(circle);
            graphicEditor.DrawShape(rectangle);
            graphicEditor.DrawShape(square);
        }
    }
}