using SantaWorkshop.Models.Dwarfs.Contracts;
using SantaWorkshop.Models.Presents.Contracts;

namespace SantaWorkshop.Models.Workshops.Contracts
{
    public interface IWorkshop
    {
        void Craft(IPresent present, IDwarf dwarf);
    }
}