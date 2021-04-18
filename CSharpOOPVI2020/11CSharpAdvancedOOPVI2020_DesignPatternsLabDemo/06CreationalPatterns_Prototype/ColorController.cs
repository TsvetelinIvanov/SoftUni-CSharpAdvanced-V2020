using System.Collections.Generic;

namespace _06CreationalPatterns_Prototype
{
    public class ColorController
    {
        private Dictionary<string, ColorPrototype> colors;

        public ColorController()
        {
            this.colors = new Dictionary<string, ColorPrototype>();
        }

        public ColorPrototype this[string key]
        {
            get => colors[key];
            set => colors.Add(key, value);
        }
    }
}