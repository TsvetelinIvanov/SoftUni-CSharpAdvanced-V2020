namespace _01SingleResponsibility_DrawingShape.Contracts
{
    public interface IDrawingContext
    {
        void DoSpecificDrawing(IShape shape);
    }
}