namespace _04OpenClosed_DrawingShape.Contracts
{
    public interface IDrawingStrategy
    {
        void Draw(IShape shape);

        bool IsMatch(IShape shape);
    }
}