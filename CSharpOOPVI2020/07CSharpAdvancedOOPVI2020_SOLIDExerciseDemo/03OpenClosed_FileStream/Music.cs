namespace _03OpenClosed_FileStream
{
    public class Music : IStreamable
    {
        public Music(string artist, string album)
        {
            this.Artist = artist;
            this.Album = album;
        }

        public string Artist { get; }

        public string Album { get; }

        public int Length { get; set; }

        public int Sent { get; set; }        
    }
}