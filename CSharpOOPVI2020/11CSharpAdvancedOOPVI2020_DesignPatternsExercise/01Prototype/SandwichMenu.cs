using System.Collections.Generic;

namespace _01Prototype
{
    public class SandwichMenu
    {
        private Dictionary<string, SandwichProtopype> sandwiches = new Dictionary<string, SandwichProtopype>();

        public SandwichProtopype this[string name]
        {
            get { return this.sandwiches[name]; }
            set { this.sandwiches[name] = value; }
        }
    }
}