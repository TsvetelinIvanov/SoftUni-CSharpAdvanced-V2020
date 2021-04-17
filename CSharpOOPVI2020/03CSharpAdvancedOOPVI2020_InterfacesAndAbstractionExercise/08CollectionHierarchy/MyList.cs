using _08CollectionHierarchy.Interfaces;
using System.Collections.Generic;

namespace _08CollectionHierarchy
{
    public class MyList : IMyList
    {
        private List<string> collection;
        private List<int> indexes;
        private List<string> removedItems;

        public MyList()
        {
            this.collection = new List<string>();
            this.indexes = new List<int>();
            this.removedItems = new List<string>();
        }

        public int Used => this.collection.Count;

        public void Add(string item)
        {
            this.collection.Insert(0, item);
            this.indexes.Add(0);
        }

        public void Remove()
        {
            string removedItem = this.collection[0];
            this.collection.RemoveAt(0);
            this.removedItems.Add(removedItem);
        }

        public string ReportIndexes()
        {
            return string.Join(" ", this.indexes);
        }

        public string ReportRemovedItems()
        {
            return string.Join(" ", this.removedItems);
        }
    }
}