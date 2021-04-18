using Logger.Helpers;
using Logger.Interfaces;
using System;

namespace Logger.Appenders
{
    public class FileAppender : IAppender
    {
        private ILayout layout;
        ILogFile logFile;
        private bool isAppropriateLevel;
        private int appendedMessagesCount;

        public FileAppender(ILayout layout, ILogFile logFile)
        {
            this.layout = layout;
            this.logFile = logFile;
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
                this.logFile.Write(this.layout.Format);
                this.appendedMessagesCount++;
            }
        }

        public string ReportLogging()
        {
            return $"Appender type: {this.GetType().Name}, Layout type: {this.layout.GetType().Name}, Report level: {this.ReportLevel}, Messages appended: {this.appendedMessagesCount}, File size: {this.logFile.Size}";
        }
    }
}