using Logger.Appenders;
using Logger.CommandInterpreters;
using Logger.Helpers;
using Logger.Interfaces;
using Logger.Layouts;
using Logger.Loggers;
using System;

namespace Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            //ILayout simpleLayout = new SimpleLayout();
            //IAppender consoleAppender = new ConsoleAppender(simpleLayout);
            //ILogger logger = new LoggerI(consoleAppender);
            //logger.Error("3/26/2015 2:08:11 PM", "Error parsing JSON.");
            //logger.Info("3/26/2015 2:08:11 PM", "User Pesho successfully registered.");

            //var simpleLayout = new SimpleLayout();
            //var consoleAppender = new ConsoleAppender(simpleLayout);
            //var file = new LogFile();
            //var fileAppender = new FileAppender(simpleLayout, file);
            //var logger = new LoggerI(consoleAppender, fileAppender);
            //logger.Error("3/26/2015 2:08:11 PM", "Error parsing JSON.");
            //logger.Info("3/26/2015 2:08:11 PM", "User Pesho successfully registered.");

            //var xmlLayout = new XmlLayout();
            //var consoleAppender = new ConsoleAppender(xmlLayout);
            //var logger = new LoggerI(consoleAppender);
            //logger.Fatal("3/31/2015 5:23:54 PM", "mscorlib.dll does not respond");
            //logger.Critical("3/31/2015 5:23:54 PM", "No connection string found in App.config");

            //var simpleLayout = new SimpleLayout();
            //var consoleAppender = new ConsoleAppender(simpleLayout);
            //consoleAppender.ReportLevel = ReportLevel.ERROR;
            //var logger = new LoggerI(consoleAppender);
            //logger.Info("3/31/2015 5:33:07 PM", "Everything seems fine");
            //logger.Warning("3/31/2015 5:33:07 PM", "Warning: ping is too high - disconnect imminent");
            //logger.Error("3/31/2015 5:33:07 PM", "Error parsing request");
            //logger.Critical("3/31/2015 5:33:07 PM", "No connection string found in App.config");
            //logger.Fatal("3/31/2015 5:33:07 PM", "mscorlib.dll does not respond");

            //var simpleLayout = new SimpleLayout();
            //var file = new LogFile();
            //var fileAppender = new FileAppender(simpleLayout, file);
            //var logger = new LoggerI(fileAppender);
            //logger.Error("3/31/2015 5:33:07 PM", "Error parsing request");
            //Console.WriteLine(file.Size);//2606

            //var xmlLayout = new XmlLayout();
            //var file = new LogFile();
            //var fileAppender = new FileAppender(xmlLayout, file);
            //var logger = new LoggerI(fileAppender);
            //logger.Error("3/31/2015 5:33:07 PM", "Error parsing request");
            //Console.WriteLine(file.Size);//6632

            ICommandInterpreter commandInterpreter = new ConsoleCommandInterpreter();
            commandInterpreter.Interpret();
        }
    }
}