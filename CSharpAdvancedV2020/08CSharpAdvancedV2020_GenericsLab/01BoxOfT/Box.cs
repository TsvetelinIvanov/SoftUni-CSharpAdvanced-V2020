﻿using System.Collections.Generic;
using System.Linq;

namespace BoxOfT
{
    public class Box<T>
    {
        private List<T> data;

        public Box()
        {
            this.data = new List<T>();
        }

        public int Count => this.data.Count;

        public void Add(T element)
        {
            this.data.Add(element);
        }

        public T Remove()
        {
            T removedElement = this.data.LastOrDefault();
            this.data.RemoveAt(this.data.Count - 1);

            return removedElement;
        }
    }
}