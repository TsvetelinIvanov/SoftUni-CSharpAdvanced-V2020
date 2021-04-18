using CounterStrike.Core;
using CounterStrike.Core.Contracts;

namespace CounterStrike
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}