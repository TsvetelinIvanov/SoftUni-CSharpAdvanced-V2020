using System;
using System.Collections;
using System.Collections.Generic;

namespace _02Collection
{
    public class ListyIterator<T> : IEnumerable<T>
    {
        private T[] elements;
        private int index;

        public ListyIterator(T[] elements)
        {
            this.elements = elements;
            this.index = 0;
        }

        public bool HasNext => this.index + 1 < this.elements.Length;        

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
            if (this.elements.Length == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }

            Console.WriteLine(this.elements[index]);
        }

        public void PrintAll()
        {
            foreach (T element in this.elements)
            {
                Console.Write(element + " ");
            }

            Console.WriteLine();
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.elements.Length; i++)
            {
                yield return this.elements[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}