using RobotService.Models.Robots.Contracts;

namespace RobotService.Models.Procedures
{
    public class TechCheck : Procedure
    {
        private const int SubtractedEnergy = 8;

        public TechCheck() : base()
        {

        }

        public override void DoService(IRobot robot, int procedureTime)
        {
            base.DoService(robot, procedureTime);

            robot.Energy -= SubtractedEnergy;
            if (!robot.IsChecked)
            {
                robot.IsChecked = true;
            }
            //else
            //{
            //    robot.Energy -= SubtractedEnergy;
            //}

            this.Robots.Add(robot);
        }
    }
}