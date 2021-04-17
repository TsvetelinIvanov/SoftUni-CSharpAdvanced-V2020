using System;
using System.Text.RegularExpressions;

namespace _03Telephony
{
    public class Smartphone : ISmartphone
    {
        private const string PhoneNumberPattrn = "[0-9]{10}";
        private const string UrlPattrn = "^[^0-9]+$";

        private string number;
        private string url;

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

        public string Url
        {
            get { return this.url; }
            set
            {
                Regex regex = new Regex(UrlPattrn);
                if (!regex.IsMatch(value))
                {
                    throw new ArgumentException("Invalid URL!");
                }

                this.url = value;
            }
        }

        public string Connect()
        {
            return "Calling... " + this.Number;
        }

        public string Browse()
        {
            return "Browsing: " + this.Url + "!";
        }
    }
}