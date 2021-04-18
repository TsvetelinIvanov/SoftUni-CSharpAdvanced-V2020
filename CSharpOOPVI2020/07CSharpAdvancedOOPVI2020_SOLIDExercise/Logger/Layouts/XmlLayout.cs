using Logger.Interfaces;
using System;

namespace Logger.Layouts
{
    public class XmlLayout : ILayout
    {
        public string dateTime;
        private string reportLevel;
        private string message;

        public string Format => $"<log>{Environment.NewLine}    <date>{this.dateTime}</date>{Environment.NewLine}    <level>{this.reportLevel}</level>{Environment.NewLine}    <message>{this.message}</message>{Environment.NewLine}</log>";

        public void SetFields(string dateTime, string reportLevel, string message)
        {
            this.dateTime = dateTime;
            this.reportLevel = reportLevel;
            this.message = message;
        }
    }
}