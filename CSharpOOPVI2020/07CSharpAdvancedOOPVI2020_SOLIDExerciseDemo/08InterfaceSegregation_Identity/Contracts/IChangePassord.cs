namespace _08InterfaceSegregation_Identity.Contracts
{
    public interface IChangePassord
    {
        int MinRequiredPasswordLength { get; }

        int MaxRequiredPasswordLength { get; }        

        void ChangePassword(IUser user, string oldPass, string newPass);        
    }
}