using Logger.Interfaces;

namespace Logger.Layouts
{
    public class SimpleLayout : ILayout
    {
        public string dateTime;
        private string reportLevel;
        private string message;        

        public string Format => $"{this.dateTime} - {this.reportLevel} - {this.message}";

        public void SetFields(string dateTime, string reportLevel, string message)
        {
            this.dateTime = dateTime;
            this.reportLevel = reportLevel;
            this.message = message;
        }
    }
}