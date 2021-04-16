using System.Collections.Generic;
using System.Linq;

namespace _03OldestFamilyMember
{
    public class Family
    {
        private List<Person> familyMembers;

        public Family()
        {
            this.FamilyMembers = new List<Person>();
        }

        public List<Person> FamilyMembers
        {
            get { return this.familyMembers; } 
            set { this.familyMembers = value; }
        }

        public void AddMember(Person member)
        {
            this.FamilyMembers.Add(member);
        }

        public Person GetOldestMember()
        {
            return this.FamilyMembers.OrderByDescending(m => m.Age).FirstOrDefault();
        }
    }
}