namespace _01StreamProgressInfo
{
    public interface IStreamPercentCalculatable
    {
        int Length { get; set; }

        int BytesSent { get; set; }
    }
}