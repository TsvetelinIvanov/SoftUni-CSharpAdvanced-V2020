using System.Collections.Generic;

namespace CustomStack
{
    public class StackOfStrings : Stack<string>
    {
        public bool IsEmpty() => this.Count == 0;

        public void AddRange(IEnumerable<string> collection)
        {
            foreach (string item in collection)
            {
                this.Push(item);
            }
        }
    }
}