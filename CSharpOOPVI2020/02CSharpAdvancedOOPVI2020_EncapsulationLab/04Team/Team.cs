using System.Collections.Generic;

namespace PersonsInfo
{
    public class Team
    {
        private const int AgeForReserveTeam = 40;

        private string name;
        private List<Person> firstTeam;
        private List<Person> reserveTeam;

        public Team(string name)
        {
            this.name = name;
            this.firstTeam = new List<Person>();
            this.reserveTeam = new List<Person>();
        }

        public IReadOnlyCollection<Person> FirstTeam
        {
            get { return this.firstTeam.AsReadOnly(); }
        }

        public IReadOnlyCollection<Person> ReserveTeam
        {
            get { return this.reserveTeam.AsReadOnly(); }
        }

        public void AddPlayer(Person person)
        {
            if (person.Age < AgeForReserveTeam)
            {
                this.firstTeam.Add(person);
            }
            else
            {
                this.reserveTeam.Add(person);
            }
        }
    }
}