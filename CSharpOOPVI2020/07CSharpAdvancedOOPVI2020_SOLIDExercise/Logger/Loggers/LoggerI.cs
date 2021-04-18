using Logger.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logger.Loggers
{
    public class LoggerI : ILogger
    {
        private IAppender[] appenders;        

        public LoggerI(params IAppender[] appenders)
        {
            this.appenders = appenders;
        }

        public LoggerI(ICollection<IAppender> appenders)
        {
            this.appenders = appenders.ToArray();
        }

        public void Info(string dateTime, string message)
        {
            this.Log(dateTime, nameof(this.Info).ToUpper(), message);
        }

        public void Warning(string dateTime, string message)
        {
            this.Log(dateTime, nameof(this.Warning).ToUpper(), message);
        }

        public void Error(string dateTime, string message)
        {
            this.Log(dateTime, nameof(this.Error).ToUpper(), message);
        }

        public void Critical(string dateTime, string message)
        {
            this.Log(dateTime, nameof(this.Critical).ToUpper(), message);
        }        

        public void Fatal(string dateTime, string message)
        {
            this.Log(dateTime, nameof(this.Fatal).ToUpper(), message);
        }

        private void Log(string dateTime, string reportLevel, string message)
        {
            for (int i = 0; i < appenders.Length; i++)
            {
                this.appenders[i].SetLayoutFields(dateTime, reportLevel, message);
                this.appenders[i].Append();
            }                        
        }               

        public string ReportLogging()
        {
            StringBuilder reportBuilder = new StringBuilder("Logger info" + Environment.NewLine);
            foreach (IAppender appender in this.appenders)
            {
                reportBuilder.AppendLine(appender.ReportLogging());
            }

            return reportBuilder.ToString().TrimEnd();
        }
    }
}