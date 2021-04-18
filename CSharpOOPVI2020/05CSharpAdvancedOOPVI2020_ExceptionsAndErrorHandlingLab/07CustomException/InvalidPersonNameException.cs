using System;

namespace _07CustomException
{
    public class InvalidPersonNameException : Exception
    {
        private const string CustomMessage = "The name have to consist only of latin letters!";

        public InvalidPersonNameException() : base(CustomMessage)
        {

        }

        public InvalidPersonNameException(string message) : base(message)
        {

        }
    }
}