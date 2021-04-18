using System;

namespace _04Fixing
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1, num2;
            byte result;
            num1 = 30;
            num2 = 60;

            try
            {
                result = Convert.ToByte(num1 * num2);
                Console.WriteLine("{0} x {1} = {2}", num1, num2, result);
            }
            catch (OverflowException)
            {
                Console.WriteLine("{0} x {1} = {2} can't be printed because maximal byte value is {3}!", num1, num2, num1 * num2, byte.MaxValue);
            }
        }
    }
}