using System;

namespace _03Telephony
{
    class Program
    {
        static void Main(string[] args)
        {
            StationaryPhone stationaryPhone = new StationaryPhone();
            Smartphone smartphone = new Smartphone();
            string[] phoneNumbers = Console.ReadLine().Split();
            string[] urls = Console.ReadLine().Split();

            for (int i = 0; i < phoneNumbers.Length; i++)
            {
                try
                {
                    if (phoneNumbers[i].Length == 7)
                    {
                        stationaryPhone.Number = phoneNumbers[i];
                        Console.WriteLine(stationaryPhone.Connect());
                    }
                    else if (phoneNumbers[i].Length == 10)
                    {
                        smartphone.Number = phoneNumbers[i];
                        Console.WriteLine(smartphone.Connect());
                    }
                    else
                    {
                        throw new ArgumentException("Invalid number!");
                    }
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }

            for (int i = 0; i < urls.Length; i++)
            {
                try
                {
                    smartphone.Url = urls[i];
                    Console.WriteLine(smartphone.Browse());
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }
        }
    }
}