using _04OpenClosed_DrawingShape.Contracts;
using _04OpenClosed_DrawingShape.Strategies;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _04OpenClosed_DrawingShape
{
    public class DrawingManager : IDrawingManager
    {
        private List<IDrawingStrategy> strategies;

        public DrawingManager()
        {
            this.strategies = new List<IDrawingStrategy>()
            {
                new CircleDrawer(),
                new RectangleDrawer()
            };
        }

        public void Draw(IShape shape)
        {
            IDrawingStrategy drawer = this.strategies.FirstOrDefault(s => s.IsMatch(shape));
            if (drawer == null)
            {
                throw new ArgumentException($"The shape \"{shape.GetType().Name}\" is not supported by our drawer!");
            }
            
            drawer.Draw(shape);
        }
    }
}
