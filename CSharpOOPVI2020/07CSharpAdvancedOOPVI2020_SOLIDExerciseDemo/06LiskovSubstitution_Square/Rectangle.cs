namespace _06LiskovSubstitution_Square
{
    public class Rectangle : Shape
    {
        public Rectangle(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public double Width { get; }

        public double Height { get; }

        public override double Area => this.Width * this.Height;
    }
}