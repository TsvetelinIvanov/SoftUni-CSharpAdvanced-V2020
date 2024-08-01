using System;
using System.Collections.Generic;

namespace _19BehavioralPatterns_Strategy
{
    public class MergeSort : SortStrategy
    {
        public override void Sort(List<string> list)
        {
            //list.MergeSort(); not-implemented
            string mergeSortString = @"
    public static class MergeSort<T> where T : IComparable
        {
        public static void Sort(T[] array)
        {
            T[] auxiliaryArray = new T[array.Length];
            array.CopyTo(auxiliaryArray, 0);
            Sort(auxiliaryArray, 0, array.Length, array);
        }

        private static void Sort(T[] sorceArray, int begin, int end, T[] destinationArray)
        {
            if (end - begin <= 1)
            {
                return;
            }

            int middle = (begin + end) / 2;
            Sort(destinationArray, begin, middle, sorceArray);
            Sort(destinationArray, middle, end, sorceArray);
            Merge(sorceArray, begin, middle, end, destinationArray);
        }

        private static void Merge(T[] sorceArray, int begin, int middle, int end, T[] destinationArray)
        {
            int j = begin;
            int k = middle;
            for (int i = begin; i < end; i++)
            {
                if (j < middle && (k >= end || sorceArray[j].CompareTo(sorceArray[k]) <= 0))
                {
                    destinationArray[i] = sorceArray[j];
                    j++;
                }
                else
                {
                    destinationArray[i] = sorceArray[k];
                    k++;
                }
            }
        }
    }";
            Console.WriteLine("MergeSorted list ");
            foreach (string name in list) 
            {
                  Console.WriteLine(name);
            }
        }
    }
}
