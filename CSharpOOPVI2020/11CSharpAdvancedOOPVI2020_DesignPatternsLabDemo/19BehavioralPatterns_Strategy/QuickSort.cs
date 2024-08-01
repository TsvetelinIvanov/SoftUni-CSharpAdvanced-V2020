using System;
using System.Collections.Generic;

namespace _19BehavioralPatterns_Strategy
{
    public class QuickSort : SortStrategy
    {
        public override void Sort(List<string> list)
        {
            //list.Sort(); QuickSort is not implemented
            string quickSortString = @"
    public static class Quicksort<T> where T : IComparable<T>
    {
        public static void Sort(T[] array)
        {
            Sort(array, 0, array.Length - 1);
        }

        private static void Sort(T[] array, int lower, int higher)
        {
            T pivot = GetPivot(array, lower, higher);
            if (lower < higher)
            {
                int pivotBorder = Partitition(array, lower, higher, pivot);
                Sort(array, lower, pivotBorder);
                Sort(array, pivotBorder + 1, higher);
            }            
        }

        private static T GetPivot(T[] array, int lower, int higher)
        {
            int middle = lower + ((higher - lower) / 2);
            if (array[middle].CompareTo(array[lower]) < 0)
            {
                Swap(array, lower, middle);
            }

            if (array[higher].CompareTo(array[lower]) < 0)
            {
                Swap(array, lower, higher);
            }

            if (array[middle].CompareTo(array[higher]) < 0)
            {
                Swap(array, middle, higher);
            }

            return array[higher];
        }

        private static int Partitition(T[] array, int lower, int higher, T pivot)
        {           
            int i = lower;
            int j = higher;
            while (true)
            {
                while (array[i].CompareTo(pivot) < 0)
                {
                    i++;
                }

                while (array[j].CompareTo(pivot) > 0)
                {
                    j--;
                }

                if (i >= j)
                {
                    return j;
                }

                Swap(array, i, j);
                i++;
                j--;
            }            
        }

        private static void Swap(T[] array, int swapping, int swapped)
        {
            T temporal = array[swapping];
            array[swapping] = array[swapped];
            array[swapped] = temporal;
        }
    }";
    
            Console.WriteLine("QuickSorted list ");
            foreach (string name in list) 
            {
                  Console.WriteLine(name);
            }
        }
    }
}
