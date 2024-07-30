using Logger.Appenders;
using Logger.Helpers;
using Logger.Interfaces;
using Logger.Layouts;
using Logger.Loggers;
using System;
using System.Collections.Generic;

namespace Logger.CommandInterpreters
{
    public class ConsoleCommandInterpreter : ICommandInterpreter
    {
        public void Interpret()
        {
            ILogger logger = CreateLogger();
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "END")
            {
                LogMessage(logger, input);
            }

            Console.WriteLine(logger.ReportLogging());
        }        

        private ILogger CreateLogger()
        {
            List<IAppender> appenders = new List<IAppender>();
            int appendersCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < appendersCount; i++)
            {
                string[] appenderData = Console.ReadLine().Split();
                string appenderType = appenderData[0];
                string layoutType = appenderData[1];
                string reportLevelType = null;
                if (appenderData.Length == 3)
                {
                    reportLevelType = appenderData[2].ToUpper();
                }

                ILayout layout = CreateLayout(layoutType);
                IAppender appender = CreateAppender(appenderType, layout);
                if (reportLevelType != null)
                {
                    ReportLevel reportLevel = Enum.Parse<ReportLevel>(reportLevelType);
                    appender.ReportLevel = reportLevel;
                }

                appenders.Add(appender);
            }

            return new LoggerI(appenders);
        }        

        private ILayout CreateLayout(string layoutType)
        {
            switch (layoutType)
            {
                case "SimpleLayout":                
                    return new SimpleLayout();
                case "XmlLayout":
                    return new XmlLayout();
                default:
                    throw new ArgumentException($"The layout type \"{layoutType}\" is not supported!");
            }
        }

        private IAppender CreateAppender(string appenderType, ILayout layout)
        {
            switch (appenderType)
            {
                case "ConsoleAppender":                
                    return new ConsoleAppender(layout);
                case "FileAppender":                
                    ILogFile logFile = new LogFile();
                    return new FileAppender(layout, logFile);
                default:
                    throw new ArgumentException($"The appender type \"{appenderType}\" is not supported!");
            }
        }

        private void LogMessage(ILogger logger, string input)
        {
            string[] messageData = input.Split('|');
            string reportLevel = messageData[0];
            string dateTime = messageData[1];
            string message = messageData[2];
            switch (reportLevel)
            {
                case "INFO":
                    logger.Info(dateTime, message);
                    break;
                case "WARNING":
                    logger.Warning(dateTime, message);
                    break;
                case "ERROR":
                    logger.Error(dateTime, message);
                    break;
                case "CRITICAL":
                    logger.Critical(dateTime, message);
                    break;
                case "FATAL":
                    logger.Fatal(dateTime, message);
                    break;
                default:
                    throw new ArgumentException($"The report level \"{reportLevel}\" is not known!");
            }
        }
    }
}
