namespace _03Telephony
{
    public interface ISmartphone : IPhone
    {
        string Url { get; set; }

        string Browse();
    }
}