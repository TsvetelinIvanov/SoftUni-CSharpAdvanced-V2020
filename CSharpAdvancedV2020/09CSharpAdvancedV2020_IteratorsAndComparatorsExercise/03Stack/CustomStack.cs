using System;
using System.Collections;
using System.Collections.Generic;

namespace _03Stack
{
    public class CustomStack<T> : IEnumerable<T>
    {
        private List<T> items;

        public CustomStack()
        {
            this.items = new List<T>();
        }

        public void Push(T item)
        {
            this.items.Add(item);
        }

        public T Pop()
        {
            if (this.items.Count == 0)
            {
                Console.WriteLine("No elements");

                return default;
            }
            else
            {
                T item = this.items[this.items.Count - 1];
                this.items.RemoveAt(this.items.Count - 1);

                return item;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.items.Count - 1; i >= 0; i--)
            {
                yield return this.items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}