using System;

namespace _09DependencyInversion_HelloWorld
{
    public class HelloWorld
    {
        public string Greeting(string name, DateTime now)
        {
            if (now.Hour < 12)
            {
                return "Good morning, " + name;
            }

            if (now.Hour < 18)
            {
                return "Good afternoon, " + name;
            }

            return "Good evening, " + name;
        }
    }
}