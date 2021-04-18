namespace _17BehavioralPatterns_Command
{
    class Program
    {
        static void Main(string[] args)
        {
            User user = new User();

            user.Compute('+', 100);//Current value = 100 (following + 100)
            user.Compute('-', 50);//Current value =  50 (following - 50)
            user.Compute('*', 10);//Current value = 500 (following * 10)
            user.Compute('/', 2);//Current value = 250 (following / 2)

            user.Undo(4);//---- Undo 4 levels
            //Current value = 500(following * 2)
            //Current value = 50(following / 10)
            //Current value = 100(following + 50)
            //Current value = 0(following - 100)

            user.Redo(3);//---- Redo 3 levels
            //Current value = 100(following + 100)
            //Current value = 50(following - 50)
            //Current value = 500(following * 10)
        }
    }
}