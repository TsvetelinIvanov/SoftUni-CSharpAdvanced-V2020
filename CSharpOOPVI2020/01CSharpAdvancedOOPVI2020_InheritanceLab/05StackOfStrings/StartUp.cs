using System;

namespace CustomStack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            StackOfStrings customStack = new StackOfStrings();
            Console.WriteLine(customStack.IsEmpty());
            string[] names = new[] { "Pesho", "Gosho", "Stamat"};
            customStack.AddRange(names);
            Console.WriteLine(string.Join(", ", customStack));
        }
    }
}