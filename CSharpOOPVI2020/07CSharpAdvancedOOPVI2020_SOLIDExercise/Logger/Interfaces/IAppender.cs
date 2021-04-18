using Logger.Helpers;

namespace Logger.Interfaces
{
    public interface IAppender
    {
        ReportLevel ReportLevel { get; set; }

        void SetLayoutFields(string dateTime, string reportLevel, string message);

        void Append();

        string ReportLogging();
    }
}