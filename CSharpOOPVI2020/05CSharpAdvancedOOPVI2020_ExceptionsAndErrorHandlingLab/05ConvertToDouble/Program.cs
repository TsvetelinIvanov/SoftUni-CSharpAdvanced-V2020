using System;

namespace _05ConvertToDouble
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                try
                {
                    Convert.ToDouble("7,8");
                }
                catch (FormatException fe)
                {
                    Console.WriteLine(fe.Message);
                    throw;
                }
            }
            catch (FormatException fe)
            {
                Console.WriteLine(fe.ToString());
            }           

            try
            {
                try
                {
                    string upMaxValue = Math.Pow(double.MaxValue, 2).ToString();
                    double doubleNumber = Convert.ToDouble(upMaxValue);                    
                    if (doubleNumber != double.MaxValue)
                    {
                        throw new OverflowException();
                    }
                }
                catch (OverflowException oe)
                {
                    Console.WriteLine(oe.Message);
                    throw;
                }
            }
            catch (OverflowException oe)
            {
                Console.WriteLine(oe.ToString());
            }
        }
    }
}