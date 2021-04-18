using ValidationAttributes.Attributes;

namespace ValidationAttributes
{
    public class Person
    {
        private const int MinAge = 12;
        private const int MaxAge = 90;

        private string fullName;
        private int age;

        public Person(string fullName, int age)
        {
            this.FullName = fullName;
            this.Age = age;
        }

        [MyRequired]
        public string FullName 
        {
            get { return this.fullName; }            
            set { this.fullName = value; }
        }

        [MyRange(MinAge, MaxAge)]
        public int Age
        {
            get { return this.age; }            
            set { this.age = value; }
        }
    }
}