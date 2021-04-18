using Logger.Helpers;
using Logger.Interfaces;
using System;

namespace Logger.Appenders
{
    public class ConsoleAppender : IAppender
    {
        private ILayout layout;
        private bool isAppropriateLevel;
        private int appendedMessagesCount;

        public ConsoleAppender(ILayout layout)
        {
            this.layout = layout;
            this.ReportLevel = ReportLevel.INFO;
            this.isAppropriateLevel = false;
            this.appendedMessagesCount = 0;
        }

        public ReportLevel ReportLevel { get; set; }

        public void SetLayoutFields(string dateTime, string reportLevel, string message)
        {            
            ReportLevel level = Enum.Parse<ReportLevel>(reportLevel);
            if (level >= this.ReportLevel)
            {
                this.layout.SetFields(dateTime, reportLevel, message);
                this.isAppropriateLevel = true;
            }            
        }

        public void Append()
        {
            if (isAppropriateLevel)
            {
                Console.WriteLine(this.layout.Format);
                this.appendedMessagesCount++;
            }            
        } 
        
        public string ReportLogging()
        {
            return $"Appender type: {this.GetType().Name}, Layout type: {this.layout.GetType().Name}, Report level: {this.ReportLevel}, Messages appended: {this.appendedMessagesCount}";
        }
    }
}