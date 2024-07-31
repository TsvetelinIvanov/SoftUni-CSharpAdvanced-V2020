using System;

namespace _08InterfaceSegregation_Identity
{
    class Program
    {
        static void Main(string[] args)
        {
            AccountManager accountManager = new AccountManager();
            accountManager.MinRequiredPasswordLength = 3;
            accountManager.MaxRequiredPasswordLength = 18;
            
            User user = new User("test@abv.bg", accountManager.MockHashPassword("789"));
            Console.WriteLine(user.PasswordHash);//789!A9m+o6@1#al$%^&8*&^%^$1p0#I^9K*
            
            AccountController accountController = new AccountController(accountManager);
            accountController.ChangePassword(user, "789", "987");
            Console.WriteLine(user.PasswordHash);//987!A9m+o6@1#al$%^&8*&^%^$1p0#I^9K*
        }
    }
}
