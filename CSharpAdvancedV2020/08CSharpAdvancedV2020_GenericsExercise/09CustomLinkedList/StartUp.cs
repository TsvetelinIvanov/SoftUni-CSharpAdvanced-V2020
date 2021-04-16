using System;

namespace CustomDoublyLinkedList//For Judge have to change the name of .csproj fail (in the zip) to CustomDoublyLinkedList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            CustomDoublyLinkedList<int> customLinkedList = new CustomDoublyLinkedList<int>();
            for (int i = 0; i < 10; i++)
            {
                customLinkedList.AddFirst(i);
            }

            Console.WriteLine(customLinkedList.Count);//10

            customLinkedList.AddLast(100);
            Console.WriteLine(customLinkedList);//9 8 7 6 5 4 3 2 1 0 100

            Console.WriteLine(customLinkedList.RemoveFirst());//9
            Console.WriteLine(customLinkedList.RemoveLast());//100
            int[] customLinkedListAsArray = customLinkedList.ToArray();
            Console.WriteLine(string.Join(" ", customLinkedListAsArray));//8 7 6 5 4 3 2 1 0

            int doublyLinkedListCount = customLinkedList.Count;
            for (int i = 0; i < doublyLinkedListCount; i++)
            {
                Console.WriteLine(customLinkedList.RemoveFirst());
            }

            //Console.WriteLine(customLinkedList.RemoveFirst());//InvalidOperationException: The list is empty
            //Console.WriteLine(customLinkedList.RemoveLast());//InvalidOperationException: The list is empty
        }
    }
}