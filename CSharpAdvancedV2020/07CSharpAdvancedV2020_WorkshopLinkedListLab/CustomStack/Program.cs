using System;

namespace CustomStack
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomStack customStack = new CustomStack();
            for (int i = 0; i < 10; i++)
            {
                customStack.Push(i);
            }

            Console.WriteLine(customStack.Count);//10
            Console.WriteLine(customStack.Pop());//9
            Console.WriteLine(customStack.Count);//9
            Console.WriteLine(customStack.Peek());//8
            Console.WriteLine(customStack.Count);//9
            Console.WriteLine(customStack);//0 1 2 3 4 5 6 7 8
            Action<int> print = x => Console.WriteLine(x);
            customStack.ForEach(print);

            int customStackCount = customStack.Count;
            for (int i = 0; i < customStackCount; i++)
            {
                Console.WriteLine(customStack.Pop());
            }

            //Console.WriteLine(customStack.Peek());//InvalidOperationException: CustomStack is empty!
            //Console.WriteLine(customStack.Pop());//InvalidOperationException: CustomStack is empty!
        }
    }
}