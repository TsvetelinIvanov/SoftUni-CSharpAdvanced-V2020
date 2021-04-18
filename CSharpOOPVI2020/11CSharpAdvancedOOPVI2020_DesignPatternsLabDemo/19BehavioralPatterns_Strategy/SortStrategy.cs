using System.Collections.Generic;

namespace _19BehavioralPatterns_Strategy
{
    public abstract class SortStrategy
    {
        public abstract void Sort(List<string> list);
    }
}