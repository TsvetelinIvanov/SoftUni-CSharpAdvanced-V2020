﻿using System;

namespace _04Recharge
{
    public class Employee : Worker, ISleeper
    {
        public Employee(string id) : base(id)
        {

        }

        public void Sleep()
        {
            Console.WriteLine("Sleep...");
        }
    }
}