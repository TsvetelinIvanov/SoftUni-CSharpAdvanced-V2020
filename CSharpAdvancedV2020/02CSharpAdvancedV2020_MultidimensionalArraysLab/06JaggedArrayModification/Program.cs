using System;
using System.Linq;

namespace _06JaggedArrayModification
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[][] square = new int[size][];
            for (int rows = 0; rows < size; rows++)
            {
                square[rows] = Console.ReadLine().Split().Select(int.Parse).ToArray();
            }

            string commandLine;
            while ((commandLine = Console.ReadLine()) != "END")
            {
                string[] commandAndData = commandLine.Split();
                string command = commandAndData[0];
                int row = int.Parse(commandAndData[1]);
                int col = int.Parse(commandAndData[2]);
                int argument = int.Parse(commandAndData[3]);

                bool isInRow = row >= 0 && row < size;
                bool isInCol = col >= 0 && col < size;
                if (!isInRow || !isInCol)
                {
                    Console.WriteLine("Invalid coordinates");
                    continue;
                }

                switch (command)
                {
                    case "Add":
                        square[row][col] += argument;
                        break;
                    case "Subtract":
                        square[row][col] -= argument;
                        break;
                }
            }

            //for (int row = 0; row < square.Length; row++)
            //{
            //    for (int col = 0; col < square[row].Length; col++)
            //    {
            //        Console.Write(square[row][col] + " ");
            //    }

            //    Console.WriteLine();
            //}
            foreach (int[] row in square)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }
    }
}