using System;
using System.Collections.Generic;
using System.Linq;

namespace _03SumOfCoins//This progect is not for Judge!!! To submit in Judge use providet sceleton or paste the method in ChooseCoins(IList<int> coins, int targetSum) in SumOfCoins.cs in the SumOfCoinsSkeleton.zip, but before do this - uncomment "throw new InvalidOperationException("Error")" and comment "return null" in "if (currentSum != targetSum)"!
{
    class SumOfCoins
    {
        static void Main(string[] args)
        {
            int[] availableCoins = Console.ReadLine().Split(" ", 2)[1].Split(", ").Select(int.Parse).ToArray();
            int targetSum = int.Parse(Console.ReadLine().Split().Last());

            //int[] availableCoins = new[] { 1, 2, 5, 10, 20, 50 };
            //int targetSum = 923;

            Dictionary<int, int> selectedCoins = ChooseCoins(availableCoins, targetSum);
            if (selectedCoins == null)
            {
                Console.WriteLine("Error");

                return;
            }

            Console.WriteLine($"Number of coins to take: {selectedCoins.Values.Sum()}");
            foreach (KeyValuePair<int, int> selectedCoin in selectedCoins)
            {
                Console.WriteLine($"{selectedCoin.Value} coin(s) with value {selectedCoin.Key}");
            }
        }

        public static Dictionary<int, int> ChooseCoins(IList<int> coins, int targetSum)
        {
            List<int> sortedCoins = coins.OrderByDescending(c => c).ToList();
            Dictionary<int, int> chosenCoins = new Dictionary<int, int>();
            int currentSum = 0;
            int coinIndex = 0;
            while (currentSum != targetSum && coinIndex < sortedCoins.Count)
            {
                int currentCoinValue = sortedCoins[coinIndex];
                int remainingSum = targetSum - currentSum;
                int numberOfCoinsToTake = remainingSum / currentCoinValue;
                if (numberOfCoinsToTake > 0)
                {
                    chosenCoins.Add(currentCoinValue, numberOfCoinsToTake);
                    currentSum += currentCoinValue * numberOfCoinsToTake;
                }

                coinIndex++;
            }

            if (currentSum != targetSum)
            {
                //throw new InvalidOperationException("Error");                
                return null;
            }

            return chosenCoins;
        }
    }
}