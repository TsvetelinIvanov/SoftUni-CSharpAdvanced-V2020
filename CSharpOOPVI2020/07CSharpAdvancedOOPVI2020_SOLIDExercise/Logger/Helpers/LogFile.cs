using Logger.Interfaces;
using System;
using System.IO;

namespace Logger.Helpers
{
    public class LogFile : ILogFile
    {
        public LogFile()
        {
            this.Size = 0;
        }

        public int Size { get; private set; }

        public void Write(string formatedText)
        {
            foreach (char character in formatedText)
            {
                if (char.IsLetter(character))
                {
                    this.Size += (int)character;
                }
            }

            File.AppendAllText("log.txt", formatedText + Environment.NewLine);
        }
    }
}