﻿namespace Logger.Interfaces
{
    public interface ILogger
    {
        void Info(string dateTime, string message);

        void Warning(string dateTime, string message);

        void Error(string dateTime, string message);

        void Critical(string dateTime, string message);

        void Fatal(string dateTime, string message);

        string ReportLogging();
    }
}