using RobotService.Models.Robots.Contracts;

namespace RobotService.Models.Procedures
{
    public class Polish : Procedure
    {
        private const int SubtractedHappiness = 7;

        public Polish() : base()
        {

        }

        public override void DoService(IRobot robot, int procedureTime)
        {
            base.DoService(robot, procedureTime);

            robot.Happiness -= SubtractedHappiness;

            this.Robots.Add(robot);
        }
    }
}