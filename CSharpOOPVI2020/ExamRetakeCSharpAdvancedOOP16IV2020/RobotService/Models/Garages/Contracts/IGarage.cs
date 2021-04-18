using RobotService.Models.Robots.Contracts;
using System.Collections.Generic;

namespace RobotService.Models.Garages.Contracts
{
    public interface IGarage
    {
        IReadOnlyDictionary<string, IRobot> Robots { get; }

        void Manufacture(IRobot robot);

        void Sell(string robotName, string ownerName);
    }
}