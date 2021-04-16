namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Person person = new Person();
            Person otherPerson = new Person();
            Person newPerson = new Person();

            person.Name = "Pesho";
            person.Age = 20;
            otherPerson.Name = "Gosho";
            otherPerson.Age = 18;
            newPerson.Name = "Stamat";           
            newPerson.Age = 43;
        }
    }
}