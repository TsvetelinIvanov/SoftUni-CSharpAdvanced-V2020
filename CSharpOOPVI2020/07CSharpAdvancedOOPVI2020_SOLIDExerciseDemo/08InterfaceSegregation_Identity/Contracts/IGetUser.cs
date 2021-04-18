namespace _08InterfaceSegregation_Identity.Contracts
{
    public interface IGetUser
    {
        IUser GetUserByName(string name);
    }
}