using Easter.Models.Bunnies.Contracts;
using Easter.Models.Eggs.Contracts;

namespace Easter.Models.Workshops.Contracts
{
    public interface IWorkshop
    {
        void Color(IEgg egg, IBunny bunny);
    }
}