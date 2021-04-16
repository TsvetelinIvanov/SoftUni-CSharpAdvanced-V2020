using System;
using System.Collections.Generic;
using System.Linq;

namespace _01Bombs
{
    public enum Bomb
    {       
        CherryBomb = 60,
        DaturaBomb = 40,
        SmokeDecoyBomb = 120
    }

    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<Bomb, int> bombs = new Dictionary<Bomb, int>()
            {              
                {Bomb.CherryBomb, 0 },
                {Bomb.DaturaBomb, 0 },
                {Bomb.SmokeDecoyBomb, 0 }
            };

            Queue<int> bombEfects = new Queue<int>(Console.ReadLine().Split(", ").Select(int.Parse));
            Stack<int> bombCasings = new Stack<int>(Console.ReadLine().Split(", ").Select(int.Parse));
            
            while (bombEfects.Count > 0 && bombCasings.Count > 0)
            {
                int bombEfect = bombEfects.Peek();
                int bombCasing = bombCasings.Peek();
                int bombResult = bombEfect + bombCasing;
                if (bombs.Any(b => (int)b.Key == bombResult))
                {
                    Bomb bomb = bombs.First(p => (int)p.Key == bombResult).Key;
                    bombs[bomb]++;
                    bombEfects.Dequeue();
                    bombCasings.Pop();
                }                
                else 
                {
                    bombCasing -= 5;
                    bombCasings.Pop();
                    bombCasings.Push(bombCasing);
                }

                if (bombs.All(b => b.Value >= 3))
                {
                    break;
                }                
            }
            
            if (bombs.All(b => b.Value >= 3))
            {
                Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
            }
            else
            {
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
            }

            if (bombEfects.Count > 0)
            {
                Console.WriteLine("Bomb Effects: " + string.Join(", ", bombEfects));
            }
            else
            {
                Console.WriteLine("Bomb Effects: empty");
            }

            if (bombCasings.Count > 0)
            {
                Console.WriteLine("Bomb Casings: " + string.Join(", ", bombCasings));
            }
            else
            {
                Console.WriteLine("Bomb Casings: empty");
            }
            
            foreach (KeyValuePair<Bomb, int> bomb in bombs)
            {
                string bombName = bomb.Key.ToString();
                if (bombName == "CherryBomb")
                {
                    bombName = "Cherry Bombs: ";
                }
                else if (bombName == "DaturaBomb")
                {
                    bombName = "Datura Bombs: ";
                }
                else if (bombName == "SmokeDecoyBomb")
                {
                    bombName = "Smoke Decoy Bombs: ";
                }

                int bombAmount = bomb.Value;

                Console.WriteLine(bombName + bombAmount);
            }            
        }
    }
}