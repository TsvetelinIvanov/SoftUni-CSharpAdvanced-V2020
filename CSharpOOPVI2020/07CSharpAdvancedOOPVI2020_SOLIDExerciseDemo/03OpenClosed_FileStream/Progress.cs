namespace _03OpenClosed_FileStream
{
    public class Progress
    {
        private readonly IStreamable streamable;
        

        public Progress(IStreamable streamable)
        {
            this.streamable = streamable;            
        }

        public int CurrentPercent()
        {
            return this.streamable.Sent * 100 / this.streamable.Length;            
        }
    }
}