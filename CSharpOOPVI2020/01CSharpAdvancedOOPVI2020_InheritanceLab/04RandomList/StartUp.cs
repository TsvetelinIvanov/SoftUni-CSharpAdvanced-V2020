using System;

namespace CustomRandomList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            RandomList randomList = new RandomList();
            randomList.Add("Pesho");
            randomList.Add("Gosho");
            randomList.Add("Stamat");
            Console.WriteLine(randomList.RandomString());
            Console.WriteLine(randomList.RandomString());
            Console.WriteLine(randomList.RandomString());
        }
    }
}