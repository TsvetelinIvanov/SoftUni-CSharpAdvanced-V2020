using System;
using System.Collections.Generic;
using System.Linq;

namespace _09PokemonTrainer
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Trainer> trainers = new List<Trainer>();
            string input = string.Empty;
            while((input = Console.ReadLine()) != "Tournament")
            {
                string[] inputData = input.Split();
                string trainerName = inputData[0];
                string pokemonName = inputData[1];
                string pokemonElement = inputData[2];
                int pokemonHealth = int.Parse(inputData[3]);

                if (!trainers.Any(t => t.Name == trainerName))
                {
                    Trainer newTrainer = new Trainer(trainerName);
                    trainers.Add(newTrainer);
                }

                Trainer trainer = trainers.FirstOrDefault(t => t.Name == trainerName);
                Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);
                trainer.Pokemons.Add(pokemon);
            }

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "End")
            {
                foreach (Trainer trainer in trainers)
                {
                    if (trainer.Pokemons.Any(p => p.Element == command))
                    {
                        trainer.BadgesNumber++;
                    }
                    else
                    {
                        trainer.Pokemons.ForEach(p => p.Health -= 10);                        
                        trainer.Pokemons = trainer.Pokemons.Where(p => p.Health > 0).ToList();                        
                    }
                }
            }

            trainers.OrderByDescending(t => t.BadgesNumber).ToList().ForEach(t => Console.WriteLine($"{t.Name} {t.BadgesNumber} {t.Pokemons.Count}"));
        }
    }
}