using System;

namespace _03OldestFamilyMember
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int membersNumber = int.Parse(Console.ReadLine());
            Family family = new Family();
            for (int i = 0; i < membersNumber; i++)
            {
                string[] memberData = Console.ReadLine().Split();
                string name = memberData[0];
                int age = int.Parse(memberData[1]);
                Person person = new Person(name, age);
                family.AddMember(person);
            }

            Person oldestMember = family.GetOldestMember();
            Console.WriteLine(oldestMember.Name + " " + oldestMember.Age);
        }
    }
}