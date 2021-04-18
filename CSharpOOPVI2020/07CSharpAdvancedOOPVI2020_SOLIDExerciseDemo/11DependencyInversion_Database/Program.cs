using System;
using System.Collections.Generic;

namespace _11DependencyInversion_Database
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, string> ourCourses = new Dictionary<int, string>()
            {
                { 1, "Mathematics" },
                { 2, "Physics" },
                { 3, "Chemistry" },
                { 4, "Geography" },
                { 5, "Biology" },
                { 6, "History" },
                { 7, "Literature" },
                { 8, "Bulgarian language" },
                { 9, "English language" },
                { 10, "Russian language" }
            };

            Data data = new Data(ourCourses);
            ConsolePrinter printer = new ConsolePrinter();
            Courses courses = new Courses(data, printer);

            courses.PrintAll();//Mathematics, Physics, Chemistry, Geography, Biology, History, Literature, Bulgarian language, English language, Russian language
            courses.PrintIds();//1, 2, 3, 4, 5, 6, 7, 8, 9, 10
            courses.PrintById(6);//History
            courses.Search("language");//Bulgarian language, English language, Russian language
        }
    }
}