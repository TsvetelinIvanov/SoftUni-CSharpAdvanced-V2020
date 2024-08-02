using SantaWorkshop.Core.Contracts;
using SantaWorkshop.Models.Dwarfs;
using SantaWorkshop.Models.Dwarfs.Contracts;
using SantaWorkshop.Models.Instruments;
using SantaWorkshop.Models.Presents;
using SantaWorkshop.Models.Presents.Contracts;
using SantaWorkshop.Models.Workshops;
using SantaWorkshop.Repositories;
using SantaWorkshop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SantaWorkshop.Core
{
    public class Controller : IController
    {
        private int craftedPresentsCount = 0;

        private DwarfRepository dwarfs;
        private PresentRepository presents;

        public Controller()
        {
            this.dwarfs = new DwarfRepository();
            this.presents = new PresentRepository();
        }

        public string AddDwarf(string dwarfType, string dwarfName)
        {
            Dwarf dwarf = null;
            switch (dwarfType)
            {
                case nameof(HappyDwarf):
                    dwarf = new HappyDwarf(dwarfName);
                    break;
                case nameof(SleepyDwarf):
                    dwarf = new SleepyDwarf(dwarfName);
                    break;
                default:
                    throw new InvalidOperationException(ExceptionMessages.InvalidDwarfType);
            }

            this.dwarfs.Add(dwarf);

            return string.Format(OutputMessages.DwarfAdded, dwarf.GetType().Name, dwarf.Name);
        }

        public string AddInstrumentToDwarf(string dwarfName, int power)
        {
            IDwarf dwarf = this.dwarfs.FindByName(dwarfName);
            if (dwarf == null)
            {
                throw new InvalidOperationException(ExceptionMessages.InexistantDwarf);
            }

            Instrument instrument = new Instrument(power);
            dwarf.AddInstrument(instrument);

            return string.Format(OutputMessages.InstrumentAdded, instrument.Power, dwarf.Name);
        }

        public string AddPresent(string presentName, int energyRequired)
        {
            Present present = new Present(presentName, energyRequired);

            this.presents.Add(present);

            return string.Format(OutputMessages.PresentAdded, present.Name);
        }

        public string CraftPresent(string presentName)
        {
            List <IDwarf> capableDwarfs = this.dwarfs.Models.Where(d => d.Energy >= 50 && d.Instruments.Count(i => !i.IsBroken()) > 0).ToList();            
            if (capableDwarfs.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.DwarfsNotReady);
            }

            IPresent present = presents.FindByName(presentName);
            Workshop workshop = new Workshop();

            while (!present.IsDone() && capableDwarfs.Count > 0)
            {
                IDwarf dwarf = capableDwarfs.OrderByDescending(p => p.Energy).First();

                workshop.Craft(present, dwarf);

                if (dwarf.Energy == 0)
                {
                    capableDwarfs.Remove(dwarf);
                    this.dwarfs.Remove(dwarf);
                }
                else if (dwarf.Instruments.Count(i => i.IsBroken() == false) == 0 || dwarf.Energy < 50)
                {
                    capableDwarfs.Remove(dwarf);
                }
            }            

            if (present.IsDone())
            {
                this.craftedPresentsCount++;
                
                return string.Format(OutputMessages.PresentIsDone, present.Name);
            }
            else
            {
                return string.Format(OutputMessages.PresentIsNotDone, present.Name);
            }
        }        

        public string Report()
        {
            StringBuilder reportBuilder = new StringBuilder();
            reportBuilder.AppendLine(this.craftedPresentsCount + " presents are done!");
            reportBuilder.AppendLine("Dwarfs info:");
            foreach (Dwarf dwarf in this.dwarfs.Models)
            {
                reportBuilder.AppendLine(dwarf.ToString());
            }

            return reportBuilder.ToString().TrimEnd();
        }
    }
}
