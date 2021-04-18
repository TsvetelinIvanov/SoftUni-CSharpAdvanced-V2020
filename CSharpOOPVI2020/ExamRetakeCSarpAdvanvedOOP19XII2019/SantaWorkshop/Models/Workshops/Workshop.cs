using SantaWorkshop.Models.Dwarfs.Contracts;
using SantaWorkshop.Models.Instruments.Contracts;
using SantaWorkshop.Models.Presents.Contracts;
using SantaWorkshop.Models.Workshops.Contracts;
using System.Linq;

namespace SantaWorkshop.Models.Workshops
{
    public class Workshop : IWorkshop
    {
        public void Craft(IPresent present, IDwarf dwarf)
        {
            while (!present.IsDone() && dwarf.Energy > 0 && dwarf.Instruments.Any(i => i.IsBroken() == false))
            {
                present.GetCrafted();
                dwarf.Work();
                IInstrument instrument = dwarf.Instruments.FirstOrDefault(i => i.IsBroken() == false);
                instrument.Use();
                if (instrument.IsBroken())
                {
                    instrument = dwarf.Instruments.FirstOrDefault(i => i.IsBroken() == false);
                }
            }
        }        
    }
}