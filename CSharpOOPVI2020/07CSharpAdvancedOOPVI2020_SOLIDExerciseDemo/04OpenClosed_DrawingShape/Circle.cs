using _04OpenClosed_DrawingShape.Contracts;
using System;

namespace _04OpenClosed_DrawingShape
{
    public class Circle : IShape
    {
        public Circle(double radius)
        {
            this.Radius = radius;            
        }

        public double Radius { get; }        

        public double Area
        {
            get { return Math.PI * this.Radius * this.Radius; }
        }
    }
}