﻿using System;
using System.Collections.Generic;

namespace _23BehavioralPatterns_Interpreter
{
    class Program
    {
        static void Main(string[] args)
        {
            string roman = "MMXVII";
            Context context = new Context(roman);

            List<Expression> tree = new List<Expression>();
            tree.Add(new ThousandExpression());
            tree.Add(new HundredExpression());
            tree.Add(new TenExpression());
            tree.Add(new OneExpression());

            foreach (Expression exp in tree)
            {
                exp.Interpret(context);
            }

            Console.WriteLine($"{roman} = {context.Output}");//MMXVII = 2017
        }
    }
}