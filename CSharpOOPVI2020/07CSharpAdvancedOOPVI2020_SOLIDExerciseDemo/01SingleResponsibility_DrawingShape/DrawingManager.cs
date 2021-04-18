using _01SingleResponsibility_DrawingShape.Contracts;

namespace _01SingleResponsibility_DrawingShape
{
    public class DrawingManager : IDrawingManager
    {
        private readonly IDrawingContext drawingContext;
        private readonly IRenderer renderer;

        public DrawingManager(IDrawingContext drawingContext, IRenderer renderer)
        {
            this.drawingContext = drawingContext;
            this.renderer = renderer;
        }

        public void Draw(IShape shape)
        {
            this.renderer.Render(this.drawingContext, shape);
        }
    }
}