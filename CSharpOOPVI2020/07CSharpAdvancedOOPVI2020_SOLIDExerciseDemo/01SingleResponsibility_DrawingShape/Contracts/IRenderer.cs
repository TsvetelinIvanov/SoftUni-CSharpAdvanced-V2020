namespace _01SingleResponsibility_DrawingShape.Contracts
{
    public interface IRenderer
    {
        void Render(IDrawingContext context, IShape shape);
    }
}