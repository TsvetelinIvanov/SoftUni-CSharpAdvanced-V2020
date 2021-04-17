using System;
using System.Text;

namespace Shapes
{
    public class Circle : Shape
    {
        private double radius;

        public Circle(double radius)
        {
            this.radius = radius;
        }        

        public override double CalculatePerimeter()
        {
            return Math.PI * 2 * this.radius;            
        }

        public override double CalculateArea()
        {
            return Math.PI * this.radius * this.radius;
        }

        public override string Draw()
        {
            return base.Draw() + "Circle";
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Circle:")
                .AppendLine($" - perimeter: {this.CalculatePerimeter():F2}")
                .AppendLine($" - area: {this.CalculateArea():F2}")
                .Append(this.Draw());
            return sb.ToString();
        }
    }
}