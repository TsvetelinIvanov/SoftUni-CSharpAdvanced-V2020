using RobotService.Models.Robots.Contracts;

namespace RobotService.Models.Procedures
{
    public class Rest : Procedure
    {
        private const int SubtractedHappiness = 3;
        private const int AddedEnergy = 10;

        public Rest() : base()
        {

        }

        public override void DoService(IRobot robot, int procedureTime)
        {
            base.DoService(robot, procedureTime);

            robot.Happiness -= SubtractedHappiness;
            robot.Energy += AddedEnergy;

            this.Robots.Add(robot);
        }
    }
}