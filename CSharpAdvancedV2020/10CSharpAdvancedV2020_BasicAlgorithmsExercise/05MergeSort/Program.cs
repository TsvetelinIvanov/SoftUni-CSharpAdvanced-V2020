using System;
using System.Linq;

namespace _05MergeSort//In Judje must be paste together with class MergeSort
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();
            MergeSort<int>.Sort(array);
            Console.WriteLine(string.Join(" ", array));
        }
    }

    //public static class MergeSort<T> where T : IComparable
    //{
    //    public static void Sort(T[] array)
    //    {
    //        T[] auxiliaryArray = new T[array.Length];
    //        array.CopyTo(auxiliaryArray, 0);
    //        Sort(auxiliaryArray, 0, array.Length, array);
    //    }

    //    private static void Sort(T[] sorceArray, int begin, int end, T[] destinationArray)
    //    {
    //        if (end - begin <= 1)
    //        {
    //            return;
    //        }

    //        int middle = (begin + end) / 2;
    //        Sort(destinationArray, begin, middle, sorceArray);
    //        Sort(destinationArray, middle, end, sorceArray);
    //        Merge(sorceArray, begin, middle, end, destinationArray);
    //    }

    //    private static void Merge(T[] sorceArray, int begin, int middle, int end, T[] destinationArray)
    //    {
    //        int j = begin;
    //        int k = middle;
    //        for (int i = begin; i < end; i++)
    //        {
    //            if (j < middle && (k >= end || sorceArray[j].CompareTo(sorceArray[k]) <= 0))
    //            {
    //                destinationArray[i] = sorceArray[j];
    //                j++;
    //            }
    //            else
    //            {
    //                destinationArray[i] = sorceArray[k];
    //                k++;
    //            }
    //        }
    //    }
    //}
}