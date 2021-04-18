using RobotService.Core;
using RobotService.Core.Contracts;

namespace RobotService
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            //Don't forget to comment out the commented code lines in the Engine class!
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}