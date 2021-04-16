using System;
using System.Linq;

namespace _02PresentDelivery
{
    class Program
    {
        static void Main(string[] args)
        {
            int presentsCount = int.Parse(Console.ReadLine());
            int neighborhoodSize = int.Parse(Console.ReadLine());
            char[,] neighborhood = new char[neighborhoodSize, neighborhoodSize];
            int[] santaPosition = new int[2];
            int niceKidsCount = 0;
            int niceKidsWithPresentsCount = 0;
            for (int i = 0; i < neighborhoodSize; i++)
            {
                char[] rowValues = Console.ReadLine().Split().Select(char.Parse).ToArray();
                for (int j = 0; j < neighborhoodSize; j++)
                {
                    neighborhood[i, j] = rowValues[j];
                    if (neighborhood[i, j] == 'S')
                    {
                        santaPosition[0] = i;
                        santaPosition[1] = j;
                    }
                    else if (neighborhood[i, j] == 'V')
                    {
                        niceKidsCount++;
                    }
                }
            }

            bool isInNeighborhood = true;
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "Christmas morning")
            {
                if (presentsCount <= 0 || isInNeighborhood == false)
                {
                    Console.WriteLine("Santa ran out of presents!");
                    break;
                }

                int santaRow = santaPosition[0];
                int santaCol = santaPosition[1];
                switch (command)
                {
                    case "up":
                        Tuple<bool, int, int> movedSantaUp = Move(neighborhood, santaPosition, santaRow - 1, santaCol, presentsCount, niceKidsWithPresentsCount);                        
                        isInNeighborhood = movedSantaUp.Item1;
                        presentsCount = movedSantaUp.Item2;
                        niceKidsWithPresentsCount = movedSantaUp.Item3;
                        if (isInNeighborhood)
                        {
                            neighborhood[santaRow, santaCol] = '-';
                        }                        

                        break;
                    case "down":
                        Tuple<bool, int, int> movedSantaDown = Move(neighborhood, santaPosition, santaRow + 1, santaCol, presentsCount, niceKidsWithPresentsCount);
                        isInNeighborhood = movedSantaDown.Item1;
                        presentsCount = movedSantaDown.Item2;
                        niceKidsWithPresentsCount = movedSantaDown.Item3;
                        if (isInNeighborhood)
                        {
                            neighborhood[santaRow, santaCol] = '-';
                        }

                        break;
                    case "left":
                        Tuple<bool, int, int> movedSantaLeft = Move(neighborhood, santaPosition, santaRow, santaCol - 1, presentsCount, niceKidsWithPresentsCount);
                        isInNeighborhood = movedSantaLeft.Item1;
                        presentsCount = movedSantaLeft.Item2;
                        niceKidsWithPresentsCount = movedSantaLeft.Item3;
                        if (isInNeighborhood)
                        {
                            neighborhood[santaRow, santaCol] = '-';
                        }

                        break;
                    case "right":
                        Tuple<bool, int, int> movedSantaRight = Move(neighborhood, santaPosition, santaRow, santaCol + 1, presentsCount, niceKidsWithPresentsCount);
                        isInNeighborhood = movedSantaRight.Item1;
                        presentsCount = movedSantaRight.Item2;
                        niceKidsWithPresentsCount = movedSantaRight.Item3;
                        if (isInNeighborhood)
                        {
                            neighborhood[santaRow, santaCol] = '-';
                        }

                        break;
                }                
            }

            PrintNeighborhood(neighborhood);
            if (niceKidsCount == niceKidsWithPresentsCount)
            {
                Console.WriteLine($"Good job, Santa! {niceKidsCount} happy nice kid/s.");
            }
            else
            {
                Console.WriteLine($"No presents for {niceKidsCount - niceKidsWithPresentsCount} nice kid/s.");
            }
        }        

        private static Tuple<bool, int, int> Move(char[,] neighborhood, int[] santaPosition, int santaRow, int santaCol, int presentsCount, int niceKidsWithPresentsCount)
        {
            bool isInNeighborhood = true;
            if (!IsInNeighborhood(neighborhood, santaRow, santaCol))
            {
                isInNeighborhood = false;
            }
            else
            {
                if (neighborhood[santaRow, santaCol] == 'V')
                {
                    presentsCount--;
                    niceKidsWithPresentsCount++;
                }
                else if (neighborhood[santaRow, santaCol] == 'C')
                {
                    Tuple<int, int> eatingResult = TryGivePresents(neighborhood, santaRow - 1, santaCol, presentsCount, niceKidsWithPresentsCount);
                    presentsCount = eatingResult.Item1;
                    niceKidsWithPresentsCount = eatingResult.Item2;
                    eatingResult = TryGivePresents(neighborhood, santaRow + 1, santaCol, presentsCount, niceKidsWithPresentsCount);
                    presentsCount = eatingResult.Item1;
                    niceKidsWithPresentsCount = eatingResult.Item2;
                    eatingResult = TryGivePresents(neighborhood, santaRow, santaCol + 1, presentsCount, niceKidsWithPresentsCount);
                    presentsCount = eatingResult.Item1;
                    niceKidsWithPresentsCount = eatingResult.Item2;
                    eatingResult = TryGivePresents(neighborhood, santaRow, santaCol - 1, presentsCount, niceKidsWithPresentsCount);
                    presentsCount = eatingResult.Item1;
                    niceKidsWithPresentsCount = eatingResult.Item2;
                }

                neighborhood[santaRow, santaCol] = 'S';
                santaPosition[0] = santaRow;
                santaPosition[1] = santaCol;                
            }

            return new Tuple<bool, int, int>(isInNeighborhood, presentsCount, niceKidsWithPresentsCount);
        }

        private static Tuple<int, int> TryGivePresents(char[,] neighborhood, int santaRow, int santaCol, int presentsCount, int niceKidsWithPresentsCount)
        {
            if (neighborhood[santaRow, santaCol] == 'V')
            {
                presentsCount--;
                niceKidsWithPresentsCount++;
                neighborhood[santaRow, santaCol] = '-';
            }
            else if (neighborhood[santaRow, santaCol] == 'X')
            {
                presentsCount--;                
                neighborhood[santaRow, santaCol] = '-';
            }

            return new Tuple<int, int>(presentsCount, niceKidsWithPresentsCount);
        }

        private static bool IsInNeighborhood(char[,] neighborhood, int santaRow, int santaCol)
        {
            return santaRow >= 0 && santaRow < neighborhood.GetLength(0) && santaCol >= 0 && santaCol < neighborhood.GetLength(1);
        }

        private static void PrintNeighborhood(char[,] neighborhood)
        {
            for (int row = 0; row < neighborhood.GetLength(0); row++)
            {
                for (int col = 0; col < neighborhood.GetLength(1); col++)
                {
                    Console.Write(neighborhood[row, col] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}