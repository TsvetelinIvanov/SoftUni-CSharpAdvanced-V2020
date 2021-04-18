namespace _03OpenClosed_FileStream
{
    public class File : IStreamable
    {
        public File(string Name)
        {
            this.Name = Name;
        }

        public string Name { get; }

        public int Length { get; set; }

        public int Sent { get; set; }
    }
}