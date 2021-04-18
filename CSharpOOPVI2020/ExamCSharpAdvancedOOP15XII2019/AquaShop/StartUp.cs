using AquaShop.Core;
using AquaShop.Core.Contracts;

namespace AquaShop
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            //Don't forget to comment out the commented code lines in the Engine class!
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}