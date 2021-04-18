using _08InterfaceSegregation_Identity.Contracts;
using System;

namespace _08InterfaceSegregation_Identity
{
    public class AccountManager : IChangePassord
    {
        public int MinRequiredPasswordLength { get; set; }

        public int MaxRequiredPasswordLength { get; set; }       

        public void ChangePassword(IUser user, string oldPass, string newPass)
        {
            if (this.MockHashPassword(oldPass) != user.PasswordHash)
            {
                throw new ArgumentException("The password doesn't match the password for changing!");
            }

            if (newPass.Length < this.MinRequiredPasswordLength || newPass.Length > this.MaxRequiredPasswordLength)
            {
                throw new ArgumentException($"The passwrd length must be in range {this.MinRequiredPasswordLength}...{this.MaxRequiredPasswordLength}!");
            }

            user.ChangePassword(this.MockHashPassword(newPass));
        }

        public string MockHashPassword(string password)//Not for using in real applications, where must be used real hash algorithm
        {
            return password + "!A9m+o6@1#al$%^&8*&^%^$1p0#I^9K*";
        }
    }
}