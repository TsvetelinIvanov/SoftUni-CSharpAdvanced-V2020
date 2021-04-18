using System;

namespace _10StructuralPatterns_Proxy
{
    class Program
    {
        static void Main(string[] args)
        {
            CalculateProxy proxy = new CalculateProxy();

            Console.WriteLine("Calculations");//Calculations
            Console.WriteLine("-------------");//-------------
            Console.WriteLine(Environment.NewLine + "10 + 5 = " + proxy.Add(10, 5));//10 + 5 = 15
            Console.WriteLine(Environment.NewLine + "10 - 5 = " + proxy.Subtract(10, 5));//10 - 5 = 5
            Console.WriteLine(Environment.NewLine + "10 * 5 = " + proxy.Multiply(10, 5));//10 * 5 = 50
            Console.WriteLine(Environment.NewLine + "10 / 5 = " + proxy.Divide(10, 5));//10 / 5 = 2
        }
    }
}