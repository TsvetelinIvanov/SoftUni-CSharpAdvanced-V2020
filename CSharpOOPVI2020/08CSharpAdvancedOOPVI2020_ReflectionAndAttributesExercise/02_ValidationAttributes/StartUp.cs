using System;

namespace ValidationAttributes
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Person person = new Person
             (
                 null,
                 -1
             );

            //bool isValid = Validator.TryValidateObject(person, new ValidationContext(person), new List<ValidationResult>());
            bool isValidEntity = Validator.IsValid(person);

            Console.WriteLine(isValidEntity);
        }
    }
}