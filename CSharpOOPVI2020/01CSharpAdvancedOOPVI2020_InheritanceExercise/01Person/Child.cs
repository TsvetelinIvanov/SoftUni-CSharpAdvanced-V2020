namespace Person
{
    public class Child : Person
    {
        public Child(string name, int age) : base(name, age)
        {
            //if (this.Age > 15)
            //{
            //    throw new ArgumentException("The child can not have age over 15 years!");
            //}
        }        
    }
}