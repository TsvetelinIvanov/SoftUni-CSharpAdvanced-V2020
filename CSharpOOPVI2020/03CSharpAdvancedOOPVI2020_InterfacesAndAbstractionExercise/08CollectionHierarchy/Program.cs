using System;

namespace _08CollectionHierarchy
{
    class Program
    {
        static void Main(string[] args)
        {
            AddCollection addCollection = new AddCollection();
            AddRemoveCollection addRemoveCollection = new AddRemoveCollection();
            MyList myList = new MyList();

            string[] stringsToAdding = Console.ReadLine().Split();
            int countToRemoving = int.Parse(Console.ReadLine());

            for (int i = 0; i < stringsToAdding.Length; i++)
            {
                addCollection.Add(stringsToAdding[i]);
                addRemoveCollection.Add(stringsToAdding[i]);
                myList.Add(stringsToAdding[i]);
            }

            for (int i = 0; i < countToRemoving; i++)
            {
                addRemoveCollection.Remove();
                myList.Remove();
            }

            Console.WriteLine(addCollection.ReportIndexes());
            Console.WriteLine(addRemoveCollection.ReportIndexes());
            Console.WriteLine(myList.ReportIndexes());
            Console.WriteLine(addRemoveCollection.ReportRemovedItems());
            Console.WriteLine(myList.ReportRemovedItems());
        }
    }
}