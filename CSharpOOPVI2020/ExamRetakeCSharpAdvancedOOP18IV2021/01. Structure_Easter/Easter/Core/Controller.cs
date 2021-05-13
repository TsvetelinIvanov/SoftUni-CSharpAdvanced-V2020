using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Easter.Core.Contracts;
using Easter.Models.Bunnies;
using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes;
using Easter.Models.Eggs;
using Easter.Models.Eggs.Contracts;
using Easter.Models.Workshops;
using Easter.Repositories;
using Easter.Utilities.Messages;

namespace Easter.Core
{
    public class Controller : IController
    {
        private int coloredEggsCount = 0;

        private BunnyRepository bunnies;
        private EggRepository eggs;

        public Controller()
        {
            this.bunnies = new BunnyRepository();
            this.eggs = new EggRepository();
        }

        public string AddBunny(string bunnyType, string bunnyName)
        {
            Bunny bunny = null;

            switch (bunnyType)
            {
                case nameof(HappyBunny):
                    bunny = new HappyBunny(bunnyName);
                    break;
                case nameof(SleepyBunny):
                    bunny = new SleepyBunny(bunnyName);
                    break;
                default:
                    throw new InvalidOperationException(ExceptionMessages.InvalidBunnyType);//Invalid bunny type.
            }

            this.bunnies.Add(bunny);

            return string.Format(OutputMessages.BunnyAdded, bunny.GetType().Name, bunny.Name);
        }

        public string AddDyeToBunny(string bunnyfName, int power)
        {
            IBunny bunny = this.bunnies.FindByName(bunnyfName);
            if (bunny == null)
            {
                throw new InvalidOperationException(ExceptionMessages.InexistentBunny);
            }

            Dye dye = new Dye(power);
            bunny.AddDye(dye);

            return string.Format(OutputMessages.DyeAdded, dye.Power, bunny.Name);
        }

        public string AddEgg(string eggName, int energyRequired)
        {
            Egg egg = new Egg(eggName, energyRequired);

            this.eggs.Add(egg);

            return string.Format(OutputMessages.EggAdded, egg.Name);
        }

        public string ColorEgg(string eggName)
        {
            List<IBunny> capableBunnies = this.bunnies.Models.Where(b => b.Energy >= 50).ToList();
            if (capableBunnies.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.BunniesNotReady);
            }

            IEgg egg = this.eggs.FindByName(eggName);
            Workshop workshop = new Workshop();
            while (!egg.IsDone() && capableBunnies.Count > 0)
            {
                IBunny bunny = capableBunnies.OrderByDescending(b => b.Energy).First();

                workshop.Color(egg, bunny);
                if (bunny.Energy == 0)
                {
                    capableBunnies.Remove(bunny);
                    this.bunnies.Remove(bunny);
                }
                else if (bunny.Dyes.Count == 0 || bunny.Energy < 50)
                {
                    capableBunnies.Remove(bunny);
                }
            }

            if (egg.IsDone())
            {
                this.coloredEggsCount++;
                return string.Format(OutputMessages.EggIsDone, egg.Name);
            }
            else
            {
                return string.Format(OutputMessages.EggIsNotDone, egg.Name);
            }            
        }

        public string Report()
        {
            StringBuilder reportBuilder = new StringBuilder();
            reportBuilder.AppendLine(this.coloredEggsCount + " eggs are done!");
            reportBuilder.AppendLine("Bunnies info:");
            foreach (Bunny bunny in this.bunnies.Models)
            {
                reportBuilder.AppendLine(bunny.ToString());
            }

            return reportBuilder.ToString().TrimEnd();
        }        
    }
}