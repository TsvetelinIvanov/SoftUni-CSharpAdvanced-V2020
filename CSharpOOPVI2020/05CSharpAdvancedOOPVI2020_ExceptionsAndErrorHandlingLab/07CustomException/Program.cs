using System;
using System.Collections.Generic;

namespace _07CustomException
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] firstNames = new string[] { "Pesho", "  ", "Gosho", "Stamat", "Prakash", "Yolo", "Ivan", "Dragan", "Dido", "Gin4o", "Gogo", "Dimitar" };
            string[] lasttNames = new string[] { "Peshev", "Goshev", "", null, "Penchev", "Delev", "Ivanov", "Dragov", "Didov", "Ginev", "Gin4ev", "Dimitrov" };
            int[] ages = new int[] { 31, 27, 15, 18, -19, 121, 40, 17, 39, 89, 9, 19 };
            string[] emails = new string[] { "Peshev@abv.bg", "Goshev@gmail.com", "abc@abc.au", "iki@abc.au", "Penchev@abv.bg", "Delev@yahoo.com", "Ivanov@abv.bg", "DragovCom", "d@", "Ginev@abc.au", "Gin4ev.abc.au", "Dimitrov@gmail.com" };
            List<Student> students = new List<Student>();
            for (int i = 0; i < 12; i++)
            {
                try
                {
                    Student student = new Student(firstNames[i], lasttNames[i], ages[i], emails[i]);
                    students.Add(student);
                }
                //catch (ArgumentNullException ane)
                //{
                //    Console.WriteLine("Exception thrown: " + ane.Message);
                //}
                //catch (ArgumentOutOfRangeException aoore)
                //{
                //    Console.WriteLine("Exception thrown: " + aoore.Message);
                //}
                catch (ArgumentException ae)
                {
                    Console.WriteLine("Exception thrown: " + ae.Message);
                }
                catch (InvalidPersonNameException ipne)
                {
                    Console.WriteLine("Exception thrown: " + ipne.Message);
                }
            }

            students.ForEach(s => Console.WriteLine($"Name: {s.Name}, age: {s.Age}, email: {s.Email}."));
        }
    }
}