using _08InterfaceSegregation_Identity.Contracts;

namespace _08InterfaceSegregation_Identity
{
    public class AccountController
    {
        private readonly IChangePassord manager;

        public AccountController(IChangePassord manager)
        {
            this.manager = manager;
        }

        public void ChangePassword(IUser user, string oldPass, string newPass)
        {
            this.manager.ChangePassword(user, oldPass, newPass);
        }
    }
}