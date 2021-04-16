using System;
using System.Linq;

namespace _07BinarySearch//In Judje must be paste together with class BinarySearch! If some tests doesn't past because of time limit - submit another time when Judge is less engaged!
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int searchedElement = int.Parse(Console.ReadLine());
            Console.WriteLine(BinarySearch<int>.IndexOf(array, searchedElement));
        }
    }

    //public class BinarySearch<T> where T : IComparable<T>
    //{
    //    public static int IndexOf(T[] array, T value)
    //    {
    //        int start = 0;
    //        int end = array.Length - 1;
    //        while (end >= start)
    //        {
    //            int middle = (start + end) / 2;
    //            if (array[middle].CompareTo(value) < 0)
    //            {
    //                start = middle + 1;
    //            }
    //            else if (array[middle].CompareTo(value) > 0)
    //            {
    //                end = middle - 1;
    //            }
    //            else if (array[middle].CompareTo(value) == 0)
    //            {
    //                return middle;
    //            }
    //        }

    //        return -1;
    //    }
    //}
}