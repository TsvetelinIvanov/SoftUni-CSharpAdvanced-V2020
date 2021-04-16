namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Person person = new Person();
            Person otherPerson = new Person(18);
            Person newPerson = new Person("Stamat", 43);
        }
    }
}