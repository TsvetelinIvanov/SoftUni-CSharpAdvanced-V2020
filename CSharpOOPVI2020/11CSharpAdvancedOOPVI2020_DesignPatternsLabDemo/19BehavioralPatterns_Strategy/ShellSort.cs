using System;
using System.Collections.Generic;

namespace _19BehavioralPatterns_Strategy
{
    public class ShellSort : SortStrategy
    {
        public override void Sort(List<string> list)
        {
            //list.Sort(); ShellSort is not implemented
            string shellSortString = @"
    public class ShellSort 
    {
        public static void Sort(int[] array) {
        int n = array.Length;        

        for (int gap = n / 2; gap > 0; gap /= 2) {
            for (int i = gap; i < n; i += 1) {
                int temp = array[i];
                int j;
                for (j = i; j >= gap && array[j - gap] > temp; j -= gap)
                    array[j] = array[j - gap];
                array[j] = temp;
            }
        }
    }    
    
    public static void PrintArray(int[] array) {
        int n = array.Length;
        for (int i = 0; i < n; i++)
            Console.Write(array[i] + " ");
        Console.WriteLine();
    }    

    public static void Main(string[] args) {
        int[] array = { 12, 34, 54, 2, 3 };
        Console.WriteLine("Array before sorting:");
        PrintArray(array);
        Sort(array );
        Console.WriteLine("Array after sorting:");
        PrintArray(array);
    }
}":
        
            Console.WriteLine("ShellSorted list ");
            foreach (string name in list) 
            {
                  Console.WriteLine(name);
            }
        }
    }
}
