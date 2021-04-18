using _01SingleResponsibility_DrawingShape.Contracts;

namespace _01SingleResponsibility_DrawingShape
{
    public class WritingRenderer : IRenderer
    {
        public void Render(IDrawingContext context, IShape shape)
        {
            context.DoSpecificDrawing(shape);
        }
    }
}