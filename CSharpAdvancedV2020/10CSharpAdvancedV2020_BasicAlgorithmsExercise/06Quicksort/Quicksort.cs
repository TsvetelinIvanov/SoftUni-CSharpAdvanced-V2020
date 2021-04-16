using System;

namespace _06Quicksort
{
    public static class Quicksort<T> where T : IComparable
    {
        public static void Sort(T[] array)
        {
            Sort(array, 0, array.Length - 1);
        }

        private static void Sort(T[] array, int lower, int higher)
        {
            if (lower >= higher)
            {
                return;
            }

            int pivot = Partitition(array, lower, higher);
            Sort(array, lower, pivot - 1);
            Sort(array, pivot + 1, higher);
        }

        private static int Partitition(T[] array, int lower, int higher)
        {
            if (lower >= higher)
            {
                return lower;
            }

            int i = lower;
            int j = higher + 1;
            while (true)
            {
                while (array[++i].CompareTo(array[lower]) < 0)
                {
                    if (i == higher)
                    {
                        break;
                    }
                }

                while (array[lower].CompareTo(array[--j]) < 0)
                {
                    if (j == lower)
                    {
                        break;
                    }
                }

                if (i >= j)
                {
                    break;
                }

                T temporal = array[i];
                array[i] = array[j];
                array[j] = temporal;
            }

            T temp = array[lower];
            array[lower] = array[j];
            array[j] = temp;

            return j;
        }
    }
}