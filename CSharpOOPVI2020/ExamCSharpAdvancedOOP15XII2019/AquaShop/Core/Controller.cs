using AquaShop.Core.Contracts;
using AquaShop.Models.Aquariums;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Repositories;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Core
{
    public class Controller : IController
    {
        private DecorationRepository decorations;
        private List<IAquarium> aquariums;

        public Controller()
        {
            this.decorations = new DecorationRepository();
            this.aquariums = new List<IAquarium>();
        }

        public string AddAquarium(string aquariumType, string aquariumName)
        {
            IAquarium aquarium = null;

            switch (aquariumType)
            {
                case nameof(FreshwaterAquarium):
                    aquarium = new FreshwaterAquarium(aquariumName);
                    break;
                case nameof(SaltwaterAquarium):
                    aquarium = new SaltwaterAquarium(aquariumName);
                    break;
                default:
                    throw new InvalidOperationException(ExceptionMessages.InvalidAquariumType);
            }

            this.aquariums.Add(aquarium);

            return string.Format(OutputMessages.SuccessfullyAdded, aquarium.GetType().Name);
        }

        public string AddDecoration(string decorationType)
        {
            IDecoration decoration = null;

            switch (decorationType)
            {
                case nameof(Ornament):
                    decoration = new Ornament();
                    break;
                case nameof(Plant):
                    decoration = new Plant();
                    break;
                default:
                    throw new InvalidOperationException(ExceptionMessages.InvalidDecorationType);
            }

            this.decorations.Add(decoration);

            return string.Format(OutputMessages.SuccessfullyAdded, decoration.GetType().Name);
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            IDecoration decoration =  this.decorations.FindByType(decorationType);
            if (decoration == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InexistentDecoration, decorationType));
            }

            IAquarium aquarium = this.aquariums.FirstOrDefault(a => a.Name == aquariumName);
            aquarium.AddDecoration(decoration);

            this.decorations.Remove(decoration);

            return string.Format(OutputMessages.EntityAddedToAquarium, decoration.GetType().Name, aquarium.Name);
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            IFish fish = null;

            switch (fishType)
            {
                case nameof(FreshwaterFish):
                    fish = new FreshwaterFish(fishName, fishSpecies, price);
                    break;
                case nameof(SaltwaterFish):
                    fish = new SaltwaterFish(fishName, fishSpecies, price);
                    break;
                default:
                    throw new InvalidOperationException(ExceptionMessages.InvalidFishType);
            }

            IAquarium aquarium = this.aquariums.FirstOrDefault(a => a.Name == aquariumName);

            if (!aquarium.GetType().Name.StartsWith(fish.GetType().Name.Substring(0, 4)))
            {
                return OutputMessages.UnsuitableWater;
            }

            aquarium.AddFish(fish);

            return string.Format(OutputMessages.EntityAddedToAquarium, fish.GetType().Name, aquarium.Name);
        }

        public string FeedFish(string aquariumName)
        {
            IAquarium aquarium = this.aquariums.FirstOrDefault(a => a.Name == aquariumName);
            aquarium.Feed();

            return string.Format(OutputMessages.FishFed, aquarium.Fish.Count);
        }

        public string CalculateValue(string aquariumName)
        {
            IAquarium aquarium = this.aquariums.FirstOrDefault(a => a.Name == aquariumName);

            decimal value = aquarium.Fish.Sum(f => f.Price) + aquarium.Decorations.Sum(d => d.Price);

            return string.Format(OutputMessages.AquariumValue, aquarium.Name, value);
        }                

        public string Report()
        {
            StringBuilder reportBuilder = new StringBuilder();
            this.aquariums.ForEach(a => reportBuilder.AppendLine(a.GetInfo()));

            return reportBuilder.ToString().TrimEnd();
        }
    }
}