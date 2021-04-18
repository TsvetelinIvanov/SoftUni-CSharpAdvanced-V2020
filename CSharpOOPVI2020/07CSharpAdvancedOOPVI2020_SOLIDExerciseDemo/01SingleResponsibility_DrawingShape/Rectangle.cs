﻿using _01SingleResponsibility_DrawingShape.Contracts;

namespace _01SingleResponsibility_DrawingShape
{
    public class Rectangle : IShape
    {
        public Rectangle(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public double Width { get; set; }

        public double Height { get; set; }

        public double Area
        {
            get { return this.Width * this.Height; }
        }        
    }
}