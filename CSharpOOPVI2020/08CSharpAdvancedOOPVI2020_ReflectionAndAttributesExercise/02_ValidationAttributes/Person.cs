﻿using ValidationAttributes.Attributes;

namespace ValidationAttributes
{
    public class Person
    {
        private const int MinAge = 12;
        private const int MaxAge = 90;
       
        public Person(string fullName, int age)
        {
            this.FullName = fullName;
            this.Age = age;
        }

        [MyRequired]
        public string FullName { get; set; }        

        [MyRange(MinAge, MaxAge)]
        public int Age { get; set; }
    }
}