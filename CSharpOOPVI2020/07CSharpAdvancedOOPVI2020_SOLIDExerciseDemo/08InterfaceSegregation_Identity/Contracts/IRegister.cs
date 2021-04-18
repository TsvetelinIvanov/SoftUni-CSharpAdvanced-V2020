namespace _08InterfaceSegregation_Identity.Contracts
{
    public interface IRegister
    {
        bool RequireUniqueEmail { get; }

        int MinRequiredPasswordLength { get; }

        int MaxRequiredPasswordLength { get; }

        void Register(string username, string password);
    }
}