namespace _01StreamProgressInfo
{
    public class StreamProgressInfo
    {
        private IStreamPercentCalculatable percentCalculatable;
        
        public StreamProgressInfo(IStreamPercentCalculatable percentCalculatable)
        {
            this.percentCalculatable = percentCalculatable;
        }

        public int CalculateCurrentPercent()
        {
            return (this.percentCalculatable.BytesSent * 100) / this.percentCalculatable.Length;
        }
    }
}