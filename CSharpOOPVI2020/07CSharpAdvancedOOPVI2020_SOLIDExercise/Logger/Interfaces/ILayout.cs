namespace Logger.Interfaces
{
    public interface ILayout
    {
        string Format { get; }

        void SetFields(string dateTime, string reportLevel, string message);
    }
}