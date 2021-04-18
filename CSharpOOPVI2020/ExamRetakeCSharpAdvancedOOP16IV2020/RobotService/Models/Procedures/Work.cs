using RobotService.Models.Robots.Contracts;

namespace RobotService.Models.Procedures
{
    public class Work : Procedure
    {
        private const int SubtractedEnergy = 6;
        private const int AddedHappiness = 12;

        public Work() : base()
        {

        }

        public override void DoService(IRobot robot, int procedureTime)
        {
            base.DoService(robot, procedureTime);

            robot.Energy -= SubtractedEnergy;
            robot.Happiness += AddedHappiness;

            this.Robots.Add(robot);
        }
    }
}