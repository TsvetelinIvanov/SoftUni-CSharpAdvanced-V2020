using System;

namespace CustomList
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomList customList = new CustomList();
            for (int i = 0; i < 10; i++)
            {
                customList.Add(i);
            }

            Console.WriteLine(customList.Count);//10

            customList.Insert(8, 70);
            customList.Insert(11, 100);
            //customList.Insert(13, 120);//IndexOutOfRangeException
            Console.WriteLine(customList);//0 1 2 3 4 5 6 7 70 8 9 100

            Console.WriteLine(customList.RemoveAt(5));//5
            //Console.WriteLine(customList.RemoveAt(13));//ArgumentOutOfRangeException            
            Console.WriteLine(customList);//0 1 2 3 4 6 7 70 8 9 100

            Console.WriteLine(customList.Contains(8));//True
            Console.WriteLine(customList.Contains(15));//False

            Console.WriteLine(customList.Find(7));//6
            //Console.WriteLine(customList.Find(15));//ArgumentException: This item does not exist in ouer collection!

            Console.WriteLine(customList.Get(7));//70
            //Console.WriteLine(customList.Get(15));//ArgumentOutOfRangeException

            customList.Swap(0, 10);
            //customList.Swap(17, 10);//ArgumentOutOfRangeException: The index "17" is not in the bounds of ouer collection!
            //customList.Swap(10, 18);//ArgumentOutOfRangeException: The index "18" is not in the bounds of ouer collection!
            Console.WriteLine(customList);//100 1 2 3 4 6 7 70 8 9 0

            customList.Reverse();
            Console.WriteLine(customList);
        }
    }
}