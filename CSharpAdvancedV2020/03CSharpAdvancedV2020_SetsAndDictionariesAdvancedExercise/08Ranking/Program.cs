using System;
using System.Collections.Generic;
using System.Linq;

namespace _08Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contests = new Dictionary<string, string>();
            SortedDictionary<string, Dictionary<string, int>> students = new SortedDictionary<string, Dictionary<string, int>>();
            Dictionary<string, int> studentPoints = new Dictionary<string, int>();

            string contestInput;
            while ((contestInput = Console.ReadLine()) != "end of contests")
            {
                string contest = contestInput.Split(":").First();
                string password = contestInput.Split(":").Last();
                //if (!contests.ContainsKey(contest))
                //{
                //    contests.Add(contest, password);
                //}
                
                contests[contest] = password;
            }

            string submissionInput;
            while ((submissionInput = Console.ReadLine()) != "end of submissions")
            {
                string[] submissionData = submissionInput.Split("=>");
                string contest = submissionData[0];
                string password = submissionData[1];
                string username = submissionData[2];
                int pointsCount = int.Parse(submissionData[3]);

                if (contests.ContainsKey(contest) && contests[contest] == password)
                {
                    if (!students.ContainsKey(username))
                    {
                        students[username] = new Dictionary<string, int>();
                        studentPoints[username] = 0;
                    }

                    if (!students[username].ContainsKey(contest))
                    {
                        students[username].Add(contest, pointsCount);
                        studentPoints[username] += pointsCount;
                    }
                    else if (students[username][contest] < pointsCount)
                    {
                        studentPoints[username] -= students[username][contest];
                        studentPoints[username] += pointsCount;
                        students[username][contest] = pointsCount;
                    }
                }
            }

            KeyValuePair<string, int> bestStudent = studentPoints.OrderByDescending(s => s.Value).First();
            string bestStudentName = bestStudent.Key;
            int bestStudentPoints = bestStudent.Value;
            Console.WriteLine($"Best candidate is {bestStudentName} with total {bestStudentPoints} points.");
            Console.WriteLine("Ranking:");
            foreach (KeyValuePair<string, Dictionary<string, int>> student in students)
            {
                Console.WriteLine(student.Key);                
                foreach (KeyValuePair<string, int> contest in student.Value.OrderByDescending(c => c.Value))
                {
                    Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
                }
            }
        }
    }
}
