using System;

namespace CustomDoublyLinkedList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            CustomDoublyLinkedList doublyLinkedList = new CustomDoublyLinkedList();
            for (int i = 0; i < 10; i++)
            {
                doublyLinkedList.AddFirst(i);
            }

            Console.WriteLine(doublyLinkedList.Count);//10

            doublyLinkedList.AddLast(100);
            Console.WriteLine(doublyLinkedList);//9 8 7 6 5 4 3 2 1 0 100

            Console.WriteLine(doublyLinkedList.RemoveFirst());//9
            Console.WriteLine(doublyLinkedList.RemoveLast());//100
            int[] doublyLinkedListAsArray = doublyLinkedList.ToArray();
            Console.WriteLine(string.Join(" ", doublyLinkedListAsArray));//8 7 6 5 4 3 2 1 0

            int doublyLinkedListCount = doublyLinkedList.Count;
            for (int i = 0; i < doublyLinkedListCount; i++)
            {
                Console.WriteLine(doublyLinkedList.RemoveFirst());
            }

            //Console.WriteLine(doublyLinkedList.RemoveFirst());//InvalidOperationException: The list is empty!
            //Console.WriteLine(doublyLinkedList.RemoveLast());//InvalidOperationException: The list is empty!
        }
    }
}