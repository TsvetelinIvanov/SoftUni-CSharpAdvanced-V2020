using System.Collections.Generic;

namespace _08InterfaceSegregation_Identity.Contracts
{
    public interface IGetUsersOnline
    {
        IEnumerable<IUser> GetAllUsersOnline();
    }
}