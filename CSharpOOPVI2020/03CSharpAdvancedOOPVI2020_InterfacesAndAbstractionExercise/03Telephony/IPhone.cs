namespace _03Telephony
{
    public interface IPhone
    {
        string Number { get; set; }

        string Connect();
    }
}