﻿namespace _07Tuple
{
    public class Tuple<T1, T2>
    {
        private T1 item1;
        private T2 item2;

        public Tuple(T1 item1, T2 item2)
        {
            this.Item1 = item1;
            this.Item2 = item2;
        }

        public T1 Item1
        {
            get { return this.item1; }
            private set { this.item1 = value; }
        }

        public T2 Item2
        {
            get { return this.item2; }
            private set { this.item2 = value; }
        }
    }
}