using System;
using System.Collections.Generic;
using System.Linq;

namespace _02AverageStudentGrades
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<decimal>> studentGrades = new Dictionary<string, List<decimal>>();
            int gradesNumber = int.Parse(Console.ReadLine());
            for (int i = 0; i < gradesNumber; i++)
            {
                string[] nameAndGrade = Console.ReadLine().Split();
                string name = nameAndGrade[0];
                decimal grade = decimal.Parse(nameAndGrade[1]);

                if (!studentGrades.ContainsKey(name))
                {
                    studentGrades[name] = new List<decimal>();
                }

                studentGrades[name].Add(grade);
            }

            foreach (KeyValuePair<string,List<decimal>> studentGrade in studentGrades)
            {
                string studentName = studentGrade.Key;
                List<decimal> grades = studentGrade.Value;
                decimal averageGrade = grades.Average();
                Console.WriteLine(studentName + " -> " + string.Join(" ", grades.Select(g => $"{g:f2}")) + $" (avg: {averageGrade:f2})");
            }
        }
    }
}