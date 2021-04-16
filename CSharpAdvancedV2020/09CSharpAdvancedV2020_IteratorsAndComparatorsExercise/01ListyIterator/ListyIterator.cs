using System;
using System.Collections.Generic;

namespace _01ListyIterator
{
    public class ListyIterator<T>
    {
        private List<T> elements;
        private int index;

        public ListyIterator(T[] elements)
        {
            this.elements = new List<T>(elements);
            this.index = 0;
        }

        public bool HasNext => this.index + 1 < this.elements.Count;

        public bool Move()
        {
            if (!HasNext)
            {
                return false;
            }

            this.index++;

            return true;
        }

        public void Print()
        {
            if (this.elements.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }

            Console.WriteLine(this.elements[index]);
        }
    }
}