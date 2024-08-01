using System;

namespace _01Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            SingletonDataContainer singletonContainer = SingletonDataContainer.Instance;
            Console.WriteLine(singletonContainer.GetPopulation("Washington, D.C."));
            
            SingletonDataContainer singletonContainer1 = SingletonDataContainer.Instance;
            Console.WriteLine(singletonContainer1.GetPopulation("London"));
        }
    }
}
