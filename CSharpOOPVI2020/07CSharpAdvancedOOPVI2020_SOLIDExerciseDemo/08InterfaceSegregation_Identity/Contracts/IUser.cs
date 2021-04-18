namespace _08InterfaceSegregation_Identity.Contracts
{
    public interface IUser
    {
        string Email { get; }

        string PasswordHash { get; }

        void ChangePassword(string passwordHash);
    }
}