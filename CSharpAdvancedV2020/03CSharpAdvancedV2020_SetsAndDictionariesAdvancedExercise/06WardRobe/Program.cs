using System;
using System.Collections.Generic;

namespace _06Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();
            int clothesNumber = int.Parse(Console.ReadLine());
            for (int i = 0; i < clothesNumber; i++)
            {
                string[] colorAndClothes = Console.ReadLine().Split(" -> ");
                string color = colorAndClothes[0];
                string[] clothes = colorAndClothes[1].Split(",");

                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe[color] = new Dictionary<string, int>();
                }

                foreach (string cloth in clothes)
                {
                    if (!wardrobe[color].ContainsKey(cloth))
                    {
                        wardrobe[color].Add(cloth, 0);
                    }

                    wardrobe[color][cloth]++;
                }                
            }

            string[] desiredColorAndCloth = Console.ReadLine().Split();
            string desiredColor = desiredColorAndCloth[0];
            string desiredCloth = desiredColorAndCloth[1];

            foreach (KeyValuePair<string, Dictionary<string, int>> colorClothes in wardrobe)
            {
                string color = colorClothes.Key;
                Console.WriteLine(color + " clothes:");

                foreach (KeyValuePair<string, int> clothCount in colorClothes.Value)
                {
                    string cloth = clothCount.Key;
                    int count = clothCount.Value;
                    string clothAndCount = $"* {cloth} - {count}";
                    if (cloth == desiredCloth && color == desiredColor)
                    {
                        clothAndCount += " (found!)";
                    }

                    Console.WriteLine(clothAndCount);
                }
            }
        }
    }
}