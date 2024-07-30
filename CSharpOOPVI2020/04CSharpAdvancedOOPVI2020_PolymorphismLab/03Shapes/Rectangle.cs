using System.Text;

namespace Shapes
{
    public class Rectangle : Shape
    {
        private double height;
        private double width;

        public Rectangle(double height, double width)
        {
            this.height = height;
            this.width = width;
        }        

        public override double CalculatePerimeter()
        {
            return 2 * this.height + 2 * this.width;
        }

        public override double CalculateArea()
        {
            return this.height * this.width;
        }

        public override string Draw()
        {
            return base.Draw() + "Rectangle";
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Rectangle:")
                .AppendLine($" - perimeter: {this.CalculatePerimeter():F2}")
                .AppendLine($" - area: {this.CalculateArea():F2}")
                .Append(this.Draw());
                
            return sb.ToString();
        }
    }
}
