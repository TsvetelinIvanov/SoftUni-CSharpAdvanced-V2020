using System;

namespace _04Recharge
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee employee = new Employee("IvanIvanov000786");
            Robot robot = new Robot("RHP000908", 12);
            robot.Recharge();

            employee.Work(8);
            robot.Work(8);

            Console.WriteLine(employee.ReportWorkHours());//8
            Console.WriteLine(robot.ReportWorkHours());//8
            Console.WriteLine(robot.CurrentPower);//4           

            employee.Sleep();//Sleep...
            employee.Work(8);
            robot.Work(8);

            Console.WriteLine(employee.ReportWorkHours());//16
            Console.WriteLine(robot.ReportWorkHours());//12
            Console.WriteLine(robot.CurrentPower);//0

            RechargeStation rechargeStation = new RechargeStation();
            rechargeStation.Recharge(robot);
            Console.WriteLine(robot.CurrentPower);//12

            robot.Work(6);
            Console.WriteLine(robot.ReportWorkHours());//18
            Console.WriteLine(robot.CurrentPower);//6
        }
    }
}