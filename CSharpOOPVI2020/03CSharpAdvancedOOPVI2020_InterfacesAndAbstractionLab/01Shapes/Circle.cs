using System;

namespace Shapes
{
    public class Circle : IDrawable
    {
        private int radius;

        public Circle(int radius)
        {
            this.radius = radius;
        }

        public void Draw()
        {
            double innerRadius = this.radius - 0.4;
            double outerRadius = this.radius + 0.4;
            for (double i = this.radius; i >= -this.radius; --i)
            {
                for (double j = -this.radius; j < outerRadius; j += 0.5)
                {
                    double value = j * j + i * i;
                    if (value >= innerRadius * innerRadius && value <= outerRadius * outerRadius)
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }

                Console.WriteLine();
            }
        }
    }
}