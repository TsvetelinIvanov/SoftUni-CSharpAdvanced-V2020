using System;

namespace CustomStack
{
    public class CustomStack
    {
        private const int InitialCapacity = 4;
        private int[] items;
        private int count;

        public CustomStack()
        {
            this.items = new int[InitialCapacity];
            this.count = 0;
        }

        public int Count
        {
            get { return this.count; }
        }

        public void Push(int item)
        {
            if (this.items.Length == this.count)
            {
                int[] itemsCopy = new int[this.items.Length * 2];
                for (int i = 0; i < this.items.Length; i++)
                {
                    itemsCopy[i] = this.items[i];
                }

                this.items = itemsCopy;
            }

            this.items[this.count] = item;
            this.count++;
        }

        public int Pop()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("CustomStack is empty!");
            }

            int lastIndex = this.count - 1;
            int lastItem = this.items[lastIndex];
            this.count--;

            return lastItem;
        }

        public int Peek()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("CustomStack is empty!");
            }

            int lastIndex = this.count - 1;
            int lastItem = this.items[lastIndex];            

            return lastItem;
        }

        public void ForEach(Action<int> action)
        {
            for (int i = 0; i < this.count; i++)
            {
                action(this.items[i]);
            }
        }

        public override string ToString()
        {
            int[] currentItems = new int[this.Count];
            for (int i = 0; i < this.Count; i++)
            {
                currentItems[i] = items[i];
            }

            return string.Join(" ", currentItems);
        }
    }
}
