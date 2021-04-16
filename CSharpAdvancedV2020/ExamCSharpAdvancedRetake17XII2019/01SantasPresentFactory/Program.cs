using System;
using System.Collections.Generic;
using System.Linq;

namespace _01SantasPresentFactory
{
    public enum Present
    {
        Doll = 150,
        WoodenTrain = 250,
        TeddyBear = 300,
        Bicycle = 400
    }

    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<Present, int> presents = new Dictionary<Present, int>() 
            {
                {Present.Bicycle, 0 },
                {Present.Doll, 0 },
                {Present.TeddyBear, 0 },
                {Present.WoodenTrain, 0 }
            };

            Stack<int> materials = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            Queue<int> magicLevels = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            while (materials.Count > 0 && magicLevels.Count > 0)
            {
                int material = materials.Peek();                
                int magicLevel = magicLevels.Peek();                
                int presentResult = material * magicLevel;
                if (presents.Any(p => (int)p.Key == presentResult))
                {
                    Present present = presents.First(p => (int)p.Key == presentResult).Key;
                    presents[present]++;
                    materials.Pop();
                    magicLevels.Dequeue();
                }
                else if (presentResult < 0)
                {
                    material += magicLevel;
                    materials.Pop();
                    magicLevels.Dequeue();
                    materials.Push(material);
                }
                else if (presentResult > 0)
                {
                    material += 15;
                    materials.Pop();
                    magicLevels.Dequeue();
                    materials.Push(material);
                }
                else
                {
                    if (material == 0)
                    {
                        materials.Pop();
                    }

                    if (magicLevel == 0)
                    {
                        magicLevels.Dequeue();
                    }
                }
            }

            Dictionary<Present, int> craftedPresents = presents.Where(p => p.Value > 0).ToDictionary(p => p.Key, p => p.Value);
            string craftingResult = string.Empty;
            bool haveDollAndTrain = craftedPresents.ContainsKey(Present.Doll) && craftedPresents.ContainsKey(Present.WoodenTrain);
            bool haveBearAndBicycle = craftedPresents.ContainsKey(Present.TeddyBear) && craftedPresents.ContainsKey(Present.Bicycle);
            if (haveDollAndTrain || haveBearAndBicycle)
            {
                craftingResult = "The presents are crafted! Merry Christmas!" + Environment.NewLine;
            }
            else
            {
                craftingResult = "No presents this Christmas!" + Environment.NewLine;
            }

            if (materials.Count > 0)
            {
                craftingResult += "Materials left: " + string.Join(", ", materials) + Environment.NewLine;
            }
            else if (magicLevels.Count > 0)
            {
                craftingResult += "Magic left: " + string.Join(", ", magicLevels) + Environment.NewLine;
            }

            foreach (KeyValuePair<Present, int> present in craftedPresents)
            {
                string toyName = present.Key.ToString();
                if (toyName == "TeddyBear")
                {
                    toyName = "Teddy bear";
                }
                else if (toyName == "WoodenTrain")
                {
                    toyName = "Wooden train";
                }

                int toyAmount = present.Value;

                craftingResult += toyName + ": " + toyAmount + Environment.NewLine;
            }

            Console.WriteLine(craftingResult.TrimEnd());
        }
    }
}