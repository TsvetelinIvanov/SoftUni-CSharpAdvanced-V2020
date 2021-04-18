using System;
using System.Collections.Generic;

namespace _19BehavioralPatterns_Strategy
{
    public class QuickSort : SortStrategy
    {
        public override void Sort(List<string> list)
        {
            list.Sort();
            Console.WriteLine("QuickSorted list ");
        }
    }
}