namespace _03OpenClosed_FileStream
{
    public interface IStreamable
    {
        int Length { get; set; }

        int Sent { get; set; }
    }
}