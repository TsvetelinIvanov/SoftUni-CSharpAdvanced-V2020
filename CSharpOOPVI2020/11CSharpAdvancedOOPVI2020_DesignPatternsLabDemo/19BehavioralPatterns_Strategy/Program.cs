namespace _19BehavioralPatterns_Strategy
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedList studentRecord = new SortedList();
            studentRecord.Add("Bobby");           
            studentRecord.Add("Kate");
            studentRecord.Add("Mike");
            studentRecord.Add("Ricky");
            studentRecord.Add("Ronny");

            studentRecord.SetSortStrategy(new QuickSort());
            studentRecord.Sort();//QuickSorted list
                                 //Bobby
                                 //Kate
                                 //Mike
                                 //Ricky
                                 //Ronny

            studentRecord.SetSortStrategy(new ShellSort());
            studentRecord.Sort();//ShellSorted list
                                 //Bobby
                                 //Kate
                                 //Mike
                                 //Ricky
                                 //Ronny

            studentRecord.SetSortStrategy(new MergeSort());
            studentRecord.Sort();//MergeSorted list
                                 //Bobby
                                 //Kate
                                 //Mike
                                 //Ricky
                                 //Ronny
        }
    }
}