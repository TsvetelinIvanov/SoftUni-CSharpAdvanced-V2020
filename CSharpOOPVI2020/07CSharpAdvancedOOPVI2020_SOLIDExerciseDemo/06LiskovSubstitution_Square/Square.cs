namespace _06LiskovSubstitution_Square
{
    public class Square : Shape
    {
        public Square(double side)
        {
            this.Side = side;
        }

        public double Side { get; }

        public override double Area => this.Side * this.Side;
    }
}