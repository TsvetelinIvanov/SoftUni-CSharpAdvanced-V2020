using RobotService.Models.Procedures.Contracts;
using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotService.Models.Procedures
{
    public abstract class Procedure : IProcedure
    {
        protected Procedure()
        {
            this.Robots = new List<IRobot>();
        }

        protected IList<IRobot> Robots { get; }

        public virtual void DoService(IRobot robot, int procedureTime)
        {
            if (robot.ProcedureTime < procedureTime)
            {
                throw new ArgumentException(ExceptionMessages.InsufficientProcedureTime);
            }

            robot.ProcedureTime -= procedureTime;
        }

        public string History()
        {
            StringBuilder historyBuilder = new StringBuilder(this.GetType().Name + Environment.NewLine);
            foreach (IRobot robot in this.Robots)
            {
                historyBuilder.AppendLine(robot.ToString());
            }

            return  historyBuilder.ToString().TrimEnd();
        }
    }
}