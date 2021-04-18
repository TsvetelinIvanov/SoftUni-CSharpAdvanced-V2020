using System;

namespace _01SquareRoot
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int number = int.Parse(Console.ReadLine());
                if (number < 0)
                {
                    throw new ArgumentOutOfRangeException("", "Invalid number");
                }

                double squreRootOfNumber = Math.Sqrt(number);
                Console.WriteLine(squreRootOfNumber);
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid number");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Invalid number");
            }
            catch(ArgumentOutOfRangeException aoore)
            {
                Console.WriteLine(aoore.Message);
            }
            finally
            {
                Console.WriteLine("Good bye");
            }
        }
    }
}