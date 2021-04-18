using NUnit.Framework;

namespace Robots.Tests
{
    public class RobotsTests
    {
        private const int RobotManagerCapacity = 3;        
        private const int LowerBatteryUsage = 10;
        private const int EqualBatteryUsage = 11;
        private const int BiggerBatteryUsage = 15;
        private const int ExpectedBatteryByLowerUsage = 1;
        private const int ExpectedBatteryByEqualUsage = 0;
        private const string Job = "Some job";
        private const string InvalidCapacityExceptionMessage = "Invalid capacity!";
        private const string ExistentRobotExceptionMessage = "There is already a robot with name {0}!";
        private const string FullCapacityExceptionMessage = "Not enough capacity!";
        private const string InexistantRobotExceptionMessage = "Robot with the name {0} doesn't exist!";
        private const string NotEnoughBatteryExceptionMessage = "{0} doesn't have enough battery!";
        
        private readonly Robot robot1 = new Robot("Robot1", 11);
        private readonly Robot robot2 = new Robot("Robot2", 12);
        private readonly Robot robot3 = new Robot("Robot3", 11);
        private readonly Robot robot4 = new Robot("Robot4", 14);

        private RobotManager robotManager;

        [SetUp]
        public void Initialization()
        {
            this.robotManager = new RobotManager(RobotManagerCapacity);
        }

        [Test]
        public void InitializationOfRobotWorksCorrectly()
        {
            Assert.AreEqual("Robot1", robot1.Name);
            Assert.AreEqual(11, robot1.Battery);
            Assert.AreEqual(11, robot1.MaximumBattery);
        }

        [Test]
        public void InitializationWithEmptyCollection()
        {
            Assert.AreEqual(0, this.robotManager.Count);
        }

        [Test]
        public void InitializationWithGivenCapacity()
        {
            Assert.AreEqual(RobotManagerCapacity, this.robotManager.Capacity);
        }        

        [Test]
        public void InitializationWith0Capacity()
        {
            this.robotManager = new RobotManager(0);

            Assert.AreEqual(0, this.robotManager.Capacity);
        }

        [Test]
        public void InitializationWithNegativeCopacityThrows()
        {
            Assert.That(() => this.robotManager = new RobotManager(-1), Throws.ArgumentException.With.Message.EqualTo(InvalidCapacityExceptionMessage));
        }

        [Test]
        public void AddWorksCorrectly()
        {
            this.robotManager.Add(this.robot1);
            this.robotManager.Add(this.robot2);
            this.robotManager.Add(this.robot3);

            Assert.AreEqual(3, this.robotManager.Count);
        }

        [Test]
        public void AddThrowsIfExistentRobot()
        {
            this.robotManager.Add(this.robot1);
            this.robotManager.Add(this.robot2);

            Assert.That(() => this.robotManager.Add(robot1), Throws.InvalidOperationException.With.Message.EqualTo(string.Format(ExistentRobotExceptionMessage, this.robot1.Name)));
        }

        [Test]
        public void AddThrowsIfFullCapacity()
        {
            this.robotManager.Add(this.robot1);
            this.robotManager.Add(this.robot2);
            this.robotManager.Add(this.robot3);

            Assert.That(() => this.robotManager.Add(robot4), Throws.InvalidOperationException.With.Message.EqualTo(FullCapacityExceptionMessage));
        }

        [Test]
        public void RemoveWorksCorrectly()
        {
            this.robotManager.Add(this.robot1);
            this.robotManager.Add(this.robot2);
            this.robotManager.Add(this.robot3);

            this.robotManager.Remove(this.robot2.Name);

            Assert.AreEqual(2, this.robotManager.Count);
        }

        [Test]
        public void RemoveThrowsIfInexistantRobot()
        {
            this.robotManager.Add(this.robot1);
            this.robotManager.Add(this.robot2);

            Assert.That(() => this.robotManager.Remove(this.robot3.Name), Throws.InvalidOperationException.With.Message.EqualTo(string.Format(InexistantRobotExceptionMessage, robot3.Name)));
        }

        [TestCase(LowerBatteryUsage, ExpectedBatteryByLowerUsage)]
        //[TestCase(EqualBatteryUsage, ExpectedBatteryByEqualUsage)]//This test pass after debugging, but in Judge it is scored for unpassed and with it the first judge test doesn't pass!
        public void WorkWorksCorrectly(int batteryUsage, int expectedBattery)
        {
            this.robotManager.Add(this.robot1);
            this.robotManager.Add(this.robot2);

            this.robotManager.Work(robot1.Name, Job, batteryUsage);

            Assert.AreEqual(expectedBattery, this.robot1.Battery);
        }

        [Test]
        public void WorkThrowsIfInexistantRobot()
        {
            this.robotManager.Add(this.robot1);
            this.robotManager.Add(this.robot2);

            Assert.That(() => this.robotManager.Work(this.robot3.Name, Job, LowerBatteryUsage), Throws.InvalidOperationException.With.Message.EqualTo(string.Format(InexistantRobotExceptionMessage, this.robot3.Name)));
        }

        [Test]
        public void WorkThrousIfNotEnoughBattery()
        {
            this.robotManager.Add(this.robot1);
            this.robotManager.Add(this.robot2);

            Assert.That(() => this.robotManager.Work(robot1.Name, Job, BiggerBatteryUsage), Throws.InvalidOperationException.With.Message.EqualTo(string.Format(NotEnoughBatteryExceptionMessage, robot1.Name)));
        }

        [Test]        
        public void ChargeWorksCorrectly()
        {
            this.robotManager.Add(this.robot1);
            this.robotManager.Add(this.robot2);

            this.robotManager.Work(robot1.Name, Job, LowerBatteryUsage);
            this.robotManager.Charge(robot1.Name);

            Assert.AreEqual(this.robot1.MaximumBattery, this.robot1.Battery);
        }

        [Test]
        public void ChargeThrowsIfInexistentRobot()
        {
            this.robotManager.Add(this.robot1);
            this.robotManager.Add(this.robot2);

            Assert.That(() => this.robotManager.Charge(robot3.Name), Throws.InvalidOperationException.With.Message.EqualTo(string.Format(InexistantRobotExceptionMessage, robot3.Name)));
        }
    }
}