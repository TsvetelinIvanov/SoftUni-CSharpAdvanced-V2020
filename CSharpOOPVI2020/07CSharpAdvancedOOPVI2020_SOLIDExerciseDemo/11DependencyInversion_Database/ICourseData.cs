using System.Collections.Generic;

namespace _11DependencyInversion_Database
{
    public interface ICourseData
    {
        IEnumerable<int> CourseIds();

        IEnumerable<string> CourseNames();

        IEnumerable<string> Search(string substring);

        string GetCourseById(int id);        
    }
}