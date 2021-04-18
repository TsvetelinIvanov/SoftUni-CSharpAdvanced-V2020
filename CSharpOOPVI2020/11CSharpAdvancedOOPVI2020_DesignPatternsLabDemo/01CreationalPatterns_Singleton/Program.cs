using System;

namespace _01CreationalPatterns_Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            Logger logger = Logger.Instance;
            Logger secondLogger = Logger.Instance;
            Console.WriteLine(logger.GetHashCode() == secondLogger.GetHashCode());//True

            LoggerThreadSafe loggerThreadSafe = LoggerThreadSafe.Instance;
            LoggerThreadSafe secondLoggerThreadSafe = LoggerThreadSafe.Instance;
            Console.WriteLine(loggerThreadSafe.GetHashCode() == secondLoggerThreadSafe.GetHashCode());//True
        }
    }
}