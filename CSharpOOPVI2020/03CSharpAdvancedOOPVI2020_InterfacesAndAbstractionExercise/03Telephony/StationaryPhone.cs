using System;
using System.Text.RegularExpressions;

namespace _03Telephony
{
    public class StationaryPhone : IPhone
    {
        private const string PhoneNumberPattrn = "[0-9]{7}";

        private string number;
        
        public string Number
        {
            get { return this.number; }
            set
            {
                Regex regex = new Regex(PhoneNumberPattrn);
                if (!regex.IsMatch(value))
                {
                    throw new ArgumentException("Invalid number!");
                }

                this.number = value;
            }
        }

        public string Connect()
        {
            return "Dialing... " + this.Number;
        }
    }
}