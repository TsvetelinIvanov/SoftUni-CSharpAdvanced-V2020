using System;
using System.Collections.Generic;

namespace _02EnterNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter ten integer numbers in range 2...99, but every next enteret number must be bigger than previous entered number!");
            Console.WriteLine("Please enter the sequence:");
            bool isSequenceEntered = false;
            List<int> sequence = new List<int>();
            while (!isSequenceEntered)
            {
                try
                {
                    sequence.Add(1);
                    int number = ReadNumber(1, 100);                    
                    sequence.Add(number);
                    for (int i = 1; i < 10; i++)
                    {
                        Console.Write($"{number} < ");
                        number = ReadNumber(number, 100);                        
                        sequence.Add(number);
                    }
                    
                    sequence.Add(100);
                    isSequenceEntered = true;
                }
                catch (FormatException)
                {
                    sequence.Clear();
                    Console.WriteLine("Invalid number! There must be entered an integer number! Please enter the sequence again!");
                }
                catch (OverflowException)
                {
                    sequence.Clear();
                    Console.WriteLine("Invalid number! The number is too big for integer number! Please enter the sequence again!");
                }
                catch (ArgumentOutOfRangeException aoore)
                {
                    sequence.Clear();
                    Console.WriteLine(aoore.Message + " Please enter the sequence again!");
                }
            }

            Console.WriteLine("Congratulations! You entered the sequence successfully!");
            Console.WriteLine(string.Join(" < ", sequence));
        }

        public static int ReadNumber(int start, int end)
        {
            int number = int.Parse(Console.ReadLine());
            if (number <= start || number >= end)
            {
                throw new ArgumentOutOfRangeException($"{number}", $"The numbrer {number} must be bigger than {start} and less than {end}!");
            }

            return number;
        }
    }
}