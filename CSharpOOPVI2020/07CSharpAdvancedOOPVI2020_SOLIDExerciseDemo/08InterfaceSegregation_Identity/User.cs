using _08InterfaceSegregation_Identity.Contracts;

namespace _08InterfaceSegregation_Identity
{
    public class User : IUser
    {
        public User(string email, string passwordHash)
        {
            this.Email = email;
            this.PasswordHash = passwordHash;
        }

        public string Email { get; }

        public string PasswordHash { get; private set; }

        public void ChangePassword(string passwordHash)
        {
            this.PasswordHash = passwordHash;
        }
    }
}