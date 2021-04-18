using RobotService.Core.Contracts;
using RobotService.Models.Garages;
using RobotService.Models.Garages.Contracts;
using RobotService.Models.Procedures;
using RobotService.Models.Procedures.Contracts;
using RobotService.Models.Robots;
using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;

namespace RobotService.Core
{
    public class Controller : IController
    {
        private IGarage garage;
        private Dictionary<string, IProcedure> procedures;

        public Controller()
        {
            this.garage = new Garage();
            this.procedures = CreateProcedures();
        }

        public string Manufacture(string robotType, string name, int energy, int happiness, int procedureTime)
        {
            IRobot robot = null;
            switch (robotType)
            {
                case nameof(HouseholdRobot):
                    robot = new HouseholdRobot(name, energy, happiness, procedureTime);
                    break;
                case nameof(WalkerRobot):
                    robot = new WalkerRobot(name, energy, happiness, procedureTime);
                    break;
                case nameof(PetRobot):
                    robot = new PetRobot(name, energy, happiness, procedureTime);
                    break;
                    default:
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidRobotType, robotType));
            }

            this.garage.Manufacture(robot);

            return string.Format(OutputMessages.RobotManufactured, robot.Name);
        }

        public string Chip(string robotName, int procedureTime)
        {            
            IRobot robot = this.GetRobot(robotName);
            Chip chip = this.procedures[nameof(Chip)] as Chip;
            chip.DoService(robot, procedureTime);

            return string.Format(OutputMessages.ChipProcedure, robot.Name);
        }

        public string TechCheck(string robotName, int procedureTime)
        {            
            IRobot robot = this.GetRobot(robotName);
            TechCheck techCheck = this.procedures[nameof(TechCheck)] as TechCheck;
            techCheck.DoService(robot, procedureTime);

            return string.Format(OutputMessages.TechCheckProcedure, robot.Name);
        }

        public string Rest(string robotName, int procedureTime)
        {
            IRobot robot = this.GetRobot(robotName);
            Rest rest = this.procedures[nameof(Rest)] as Rest;
            rest.DoService(robot, procedureTime);

            return string.Format(OutputMessages.RestProcedure, robot.Name);
        }

        public string Work(string robotName, int procedureTime)
        {
            IRobot robot = this.GetRobot(robotName);
            Work work = this.procedures[nameof(Work)] as Work;
            work.DoService(robot, procedureTime);

            return string.Format(OutputMessages.WorkProcedure, robot.Name, procedureTime);
        }

        public string Charge(string robotName, int procedureTime)
        {
            IRobot robot = this.GetRobot(robotName);
            Charge charge = this.procedures[nameof(Charge)] as Charge;
            charge.DoService(robot, procedureTime);

            return string.Format(OutputMessages.ChargeProcedure, robot.Name);
        }

        public string Polish(string robotName, int procedureTime)
        {
            IRobot robot = this.GetRobot(robotName);
            Polish polish = this.procedures[nameof(Polish)] as Polish;
            polish.DoService(robot, procedureTime);

            return string.Format(OutputMessages.PolishProcedure, robot.Name);
        }

        public string Sell(string robotName, string ownerName)
        {
            IRobot robot = this.GetRobot(robotName);
            this.garage.Sell(robot.Name, ownerName);

            string sellReport = string.Format(OutputMessages.SellNotChippedRobot, robot.Owner);
            if (robot.IsChipped)
            {
                sellReport = string.Format(OutputMessages.SellChippedRobot, robot.Owner);
            }

            return sellReport;
        }

        public string History(string procedureType)
        {
            if (!this.procedures.ContainsKey(procedureType))
            {
                throw new ArgumentException($"Invalid procedure type - \"{procedureType}\"!");
            }

            IProcedure procedure = this.procedures[procedureType];

            return procedure.History();//.TrimEnd();
        }             

        private Dictionary<string, IProcedure> CreateProcedures()
        {
            Dictionary<string, IProcedure> procedures = new Dictionary<string, IProcedure>();
            Charge charge = new Charge();
            procedures.Add(nameof(Charge), charge);
            Chip chip = new Chip();
            procedures.Add(nameof(Chip), chip);
            Polish polish = new Polish();
            procedures.Add(nameof(Polish), polish);
            Rest rest = new Rest();
            procedures.Add(nameof(Rest), rest);
            TechCheck techCheck = new TechCheck();
            procedures.Add(nameof(TechCheck), techCheck);
            Work work = new Work();
            procedures.Add(nameof(Work), work);

            return procedures;
        }

        private IRobot GetRobot(string robotName)
        {
            if (this.garage.Robots.ContainsKey(robotName))
            {
                return this.garage.Robots[robotName];
            }
            else
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InexistingRobot, robotName));
            }
        }        
    }
}