using SantaWorkshop.Core;
using SantaWorkshop.Core.Contracts;

namespace SantaWorkshop
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}