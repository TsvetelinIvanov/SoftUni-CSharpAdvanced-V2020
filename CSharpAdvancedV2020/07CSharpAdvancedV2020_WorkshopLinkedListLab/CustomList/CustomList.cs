using System;

namespace CustomList
{
    public class CustomList
    {
        private const int InitialCapacity = 2;

        private int[] items;

        public CustomList()
        {
            this.items = new int[InitialCapacity];
        }

        public int Count { get; private set; }

        public int this[int index]
        {
            get
            {
                if (index < 0 || index >= this.Count)
                {
                    throw new ArgumentOutOfRangeException();
                }

                return this.items[index];
            }

            set
            {
                if (index < 0 || index >= this.Count)
                {
                    throw new ArgumentOutOfRangeException();
                }

                this.items[index] = value;
            }
        }

        public void Add(int item)
        {
            if (this.Count == this.items.Length)
            {
                this.Resize();
            }

            this.items[this.Count] = item;
            this.Count++;
        }

        public void Insert(int index, int item)
        {
            if (index < 0 || index > this.Count)
            {
                throw new IndexOutOfRangeException();
            }

            if (this.Count >= this.items.Length)
            {
                this.Resize();
            }

            this.ShifToRight(index);
            this.items[index] = item;
            this.Count++;
        }

        public int RemoveAt(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            int item = this.items[index];
            this.items[index] = default(int);
            this.Shift(index);
            this.Count--;
            if (this.Count <= this.items.Length / 4)
            {
                this.Shrink();
            }

            return item;
        }

        public bool Contains(int item)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (items[i] == item)
                {
                    return true;
                }
            }

            return false;
        }

        public int Find(int item)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (items[i] == item)
                {
                    return i;
                }
            }

            throw new ArgumentException("This item does not exist in ouer collection!");
        }

        public int Get(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            return this.items[index];
        }

        public void Swap(int firstIndex, int secondIndex)
        {
            if (firstIndex < 0 || firstIndex >= this.Count || secondIndex < 0 || secondIndex >= this.Count)
            {
                int index = firstIndex;
                if (secondIndex < 0 || secondIndex >= this.Count)
                {
                    index = secondIndex;
                }

                throw new ArgumentOutOfRangeException("", $"The index \"{index}\" is not in the bounds of ouer collection!");
            }

            int tempItem = items[firstIndex];
            items[firstIndex] = items[secondIndex];
            items[secondIndex] = tempItem;
        }

        public void Reverse()
        {
            int[] reversedItems = new int[this.Count];
            for (int i = 0; i < this.Count; i++)
            {
                reversedItems[reversedItems.Length - 1 - i] = items[i];
            }

            items = reversedItems;
        }

        private void Resize()
        {
            int[] itemsCopy = new int[this.items.Length * 2];
            for (int i = 0; i < this.items.Length; i++)
            {
                itemsCopy[i] = this.items[i];
            }

            this.items = itemsCopy;
        }

        private void Shift(int index)
        {
            for (int i = index; i < this.Count - 1; i++)
            {
                this.items[i] = this.items[i + 1];
            }
        }

        private void ShifToRight(int index)
        {
            for (int i = this.Count; i >= index; i--)
            {
                this.items[i] = this.items[i - 1];
            }
        }

        private void Shrink()
        {
            int[] itemsCopy = new int[this.items.Length / 2];
            for (int i = 0; i < this.Count; i++)
            {
                itemsCopy[i] = this.items[i];
            }

            this.items = itemsCopy;
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