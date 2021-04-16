using System;

namespace _07BinarySearch
{
    public class BinarySearch<T> where T : IComparable<T>
    {
        public static int IndexOf(T[] array, T value)
        {
            int start = 0;
            int end = array.Length - 1;
            while (end >= start)
            {
                int middle = (start + end) / 2;
                if (array[middle].CompareTo(value) < 0)
                {
                    start = middle + 1;
                }
                else if(array[middle].CompareTo(value) > 0)
                {
                    end = middle - 1;
                }
                else if(array[middle].CompareTo(value) == 0)
                {
                    return middle;
                }
            }

            return -1;
        }
    }
}