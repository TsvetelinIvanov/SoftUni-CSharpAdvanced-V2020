using System;

namespace _02CreationalPatterns_SimpleFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            FanFactory fanFactory = new FanFactory();
            IFan ceilingFan = fanFactory.CreateFan(FanType.CeilingFan);
            IFan tableFan = fanFactory.CreateFan(FanType.TableFan);

            ceilingFan.SwitchOn();
            tableFan.SwitchOff();

            Console.WriteLine(ceilingFan.GetState());//Ceiling fan state Ceiling On
            Console.WriteLine(tableFan.GetState());//Table fan state Table Off
        }
    }
}