using OnlineShop.Common.Constants;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Computers;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.Core
{
    public class Controller : IController
    {
        private Dictionary<int, IComputer> computers;
        private Dictionary<int, IComponent> components;
        private Dictionary<int, IPeripheral> peripherals;

        public Controller()
        {
            this.computers = new Dictionary<int, IComputer>();
            this.components = new Dictionary<int, IComponent>();
            this.peripherals = new Dictionary<int, IPeripheral>();
        }

        public string AddComputer(string computerType, int id, string manufacturer, string model, decimal price)
        {
            if (this.computers.ContainsKey(id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingComputerId);
            }

            IComputer computer = null;
            switch (computerType)
            {
                case nameof(DesktopComputer):
                    computer = new DesktopComputer(id, manufacturer, model, price);
                    break;
                case nameof(Laptop):
                    computer = new Laptop(id, manufacturer, model, price);
                    break;
                default:
                    throw new ArgumentException(ExceptionMessages.InvalidComputerType);
            }

            this.computers.Add(computer.Id, computer);

            return string.Format(SuccessMessages.AddedComputer, computer.Id);
        }

        public string AddComponent(int computerId, int id, string componentType, string manufacturer, string model, decimal price, double overallPerformance, int generation)
        {
            IComputer computer = this.TryGetComputer(computerId);

            if (this.components.ContainsKey(id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingComponentId);
            }

            IComponent component = null;
            switch (componentType)
            {
                case nameof(CentralProcessingUnit):
                    component = new CentralProcessingUnit(id, manufacturer, model, price, overallPerformance, generation);
                    break;
                case nameof(Motherboard):
                    component = new Motherboard(id, manufacturer, model, price, overallPerformance, generation);
                    break;
                case nameof(PowerSupply):
                    component = new PowerSupply(id, manufacturer, model, price, overallPerformance, generation);
                    break;
                case nameof(RandomAccessMemory):
                    component = new RandomAccessMemory(id, manufacturer, model, price, overallPerformance, generation);
                    break;
                case nameof(SolidStateDrive):
                    component = new SolidStateDrive(id, manufacturer, model, price, overallPerformance, generation);
                    break;
                case nameof(VideoCard):
                    component = new VideoCard(id, manufacturer, model, price, overallPerformance, generation);
                    break;
                default:
                    throw new ArgumentException(ExceptionMessages.InvalidComponentType);
            }

            computer.AddComponent(component);
            this.components.Add(component.Id, component);

            return string.Format(SuccessMessages.AddedComponent, component.GetType().Name, component.Id, computer.Id);
        }

        public string RemoveComponent(string componentType, int computerId)
        {
            IComputer computer = this.TryGetComputer(computerId);
            IComponent component = computer.RemoveComponent(componentType);
            this.components.Remove(component.Id);

            return string.Format(SuccessMessages.RemovedComponent, component.GetType().Name, component.Id);
        }

        public string AddPeripheral(int computerId, int id, string peripheralType, string manufacturer, string model, decimal price, double overallPerformance, string connectionType)
        {
            IComputer computer = this.TryGetComputer(computerId);

            if (this.peripherals.ContainsKey(id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingPeripheralId);
            }

            IPeripheral peripheral = null;
            switch (peripheralType)
            {
                case nameof(Headset):
                    peripheral = new Headset(id, manufacturer, model, price, overallPerformance, connectionType);
                    break;
                case nameof(Keyboard):
                    peripheral = new Keyboard(id, manufacturer, model, price, overallPerformance, connectionType);
                    break;
                case nameof(Monitor):
                    peripheral = new Monitor(id, manufacturer, model, price, overallPerformance, connectionType);
                    break;
                case nameof(Mouse):
                    peripheral = new Mouse(id, manufacturer, model, price, overallPerformance, connectionType);
                    break;
                default:
                    throw new ArgumentException(ExceptionMessages.InvalidPeripheralType);
            }

            computer.AddPeripheral(peripheral);
            this.peripherals.Add(peripheral.Id, peripheral);

            return string.Format(SuccessMessages.AddedPeripheral, peripheral.GetType().Name, peripheral.Id, computer.Id);
        }

        public string RemovePeripheral(string peripheralType, int computerId)
        {
            IComputer computer = this.TryGetComputer(computerId);
            IPeripheral peripheral = computer.RemovePeripheral(peripheralType);
            this.peripherals.Remove(peripheral.Id);

            return string.Format(SuccessMessages.RemovedPeripheral, peripheral.GetType().Name, peripheral.Id);
        }

        public string BuyComputer(int id)
        {
            IComputer computer = this.TryGetComputer(id);
            this.computers.Remove(computer.Id);

            return computer.ToString();
        }

        public string BuyBest(decimal budget)
        {
            IComputer computer = this.computers.Values.OrderByDescending(c => c.OverallPerformance).FirstOrDefault(c => c.Price <= budget);
            if (computer == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CanNotBuyComputer, budget));
            }

            this.computers.Remove(computer.Id);

            return computer.ToString();
        }

        public string GetComputerData(int id)
        {
            IComputer computer = this.TryGetComputer(id);

            return computer.ToString();
        }

        private IComputer TryGetComputer(int id)
        {
            if (!this.computers.ContainsKey(id))
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }

            return this.computers[id];
        }
    }
}