using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;
using System;

namespace RobotService.Models.Procedures
{
    public class Chip : Procedure
    {
        private const int SubtractedHappiness = 5;

        public Chip() : base()
        {

        }

        public override void DoService(IRobot robot, int procedureTime)
        {
            base.DoService(robot, procedureTime);            

            if (robot.IsChipped)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.AlreadyChipped, robot.Name));
            }

            robot.Happiness -= SubtractedHappiness;
            robot.IsChipped = true;

            this.Robots.Add(robot);
        }
    }
}