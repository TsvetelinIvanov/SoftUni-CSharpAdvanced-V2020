using _08CollectionHierarchy.Interfaces;
using System.Collections.Generic;

namespace _08CollectionHierarchy
{
    public class AddCollection : IAddable
    {
        private List<string> collection;
        private List<int> indexes;

        public AddCollection()
        {
            this.collection = new List<string>();
            this.indexes = new List<int>();
        }

        public void Add(string item)
        {
            int currentIndex = this.collection.Count;
            this.collection.Add(item);
            this.indexes.Add(currentIndex);
        }

        public string ReportIndexes()
        {
            return string.Join(" ", this.indexes);
        }
    }
}