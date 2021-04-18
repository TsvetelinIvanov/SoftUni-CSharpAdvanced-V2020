using System;
using System.Linq;
using System.Reflection;

namespace AuthorProblem
{
    public class Tracker
    {
        public void PrintMethodsByAuthor()
        {
            Type type = typeof(StartUp);
            MethodInfo[] methods = type.GetMethods(BindingFlags.Static | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            foreach (MethodInfo method in methods)
            {
                if (method.CustomAttributes.Any(ca => ca.AttributeType == typeof(AuthorAttribute)))
                {
                    object[] attributes = method.GetCustomAttributes(false);
                    foreach (AuthorAttribute attribute in attributes)
                    {
                        Console.WriteLine(method.Name + " is written by " + attribute.Name);
                    }
                }
            }
        }
    }
}