﻿using System;

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
                       
            bool isValidEntity = Validator.IsValid(person);

            Console.WriteLine(isValidEntity);
        }
    }
}