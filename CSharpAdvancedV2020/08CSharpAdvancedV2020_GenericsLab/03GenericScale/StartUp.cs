using System;

namespace GenericScale//For Judge have to change the name of .csproj fail (in the zip) to GenericScale
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            EqualityScale<int> equalityScaleInt = new EqualityScale<int>(6, 7);
            EqualityScale<int> equalityScaleIntEqual = new EqualityScale<int>(8, 8);
            EqualityScale<string> equalityScaleStrig = new EqualityScale<string>("Pesho", "Gosho");
            EqualityScale<string> equalityScaleStringEqual = new EqualityScale<string>("Pesho", "Pesho");

            Console.WriteLine(equalityScaleInt.AreEqual());
            Console.WriteLine(equalityScaleIntEqual.AreEqual());
            Console.WriteLine(equalityScaleStrig.AreEqual());
            Console.WriteLine(equalityScaleStringEqual.AreEqual());            
        }
    }
}