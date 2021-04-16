using System;

namespace GenericArrayCreator//For Judge have to change the name of .csproj fail (in the zip) to GenericArrayCreator
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] strings = ArrayCreator.Create(5, "Pesho");
            int[] integers = ArrayCreator.Create(10, 33);

            Console.WriteLine(string.Join(" ", strings));
            Console.WriteLine(string.Join(" ", integers));
        }
    }
}