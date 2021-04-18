using System.Collections.Generic;

namespace _11DependencyInversion_Database
{
    public class Courses
    {
        ICourseData database;
        IPrinter printer;

        public Courses(ICourseData database, IPrinter printer)
        {
            this.database = database;
            this.printer = printer;
        }

        public void PrintAll()
        {            
            IEnumerable<string> courses = database.CourseNames();            
            printer.PrintLine(string.Join(", ", courses));
        }

        public void PrintIds()
        {            
            IEnumerable<int> courseIds = database.CourseIds();           
            printer.PrintLine(string.Join(", ", courseIds));
        }

        public void PrintById(int id)
        {
            
            string course = database.GetCourseById(id);
            printer.PrintLine(course);    
        }

        public void Search(string substring)
        {            
            IEnumerable<string> courses = database.Search(substring);
            printer.PrintLine(string.Join(", ", courses));
        }
    }
}