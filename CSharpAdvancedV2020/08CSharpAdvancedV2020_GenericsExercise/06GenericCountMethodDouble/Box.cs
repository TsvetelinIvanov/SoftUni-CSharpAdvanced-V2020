using System;
using System.Collections.Generic;
using System.Linq;

namespace _06GenericCountMethodDouble
{
    public class Box<T> where T : IComparable
    {
        private T value;

        public Box()
        {

        }

        public Box(T value)
        {
            this.value = value;
        }

        public int GetGreaterElementsCount(List<T> elements, T element)
        {
            return elements.Where(e => e.CompareTo(element) > 0).Count();
        }

        public override string ToString()
        {
            return $"{this.value.GetType()}: {this.value}";
        }
    }
}