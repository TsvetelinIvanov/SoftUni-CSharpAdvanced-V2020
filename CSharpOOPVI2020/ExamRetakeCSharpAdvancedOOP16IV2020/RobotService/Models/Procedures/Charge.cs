using RobotService.Models.Robots.Contracts;

namespace RobotService.Models.Procedures
{
    public class Charge : Procedure
    {
        private const int AddedHappiness = 12;
        private const int AddedEnergy = 10;

        public Charge() : base() 
        { 
        }

        public override void DoService(IRobot robot, int procedureTime)
        {
            base.DoService(robot, procedureTime);            

            robot.Happiness += AddedHappiness;
            robot.Energy += AddedEnergy;

            this.Robots.Add(robot);
        }
    }
}