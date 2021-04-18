using System.Collections.Generic;

namespace _11DependencyInversion_Database
{
    public class Data : ICourseData
    {
        IDictionary<int, string> courses;

        public Data(IDictionary<int, string> courses)
        {
            this.courses = courses;            
        }

        public IEnumerable<int> CourseIds()
        {
            // return course ids
            return this.courses.Keys;
        }

        public IEnumerable<string> CourseNames()
        {
            // return course names
            return this.courses.Values;
        }

        public IEnumerable<string> Search(string substring)
        {
            // return found results
            List<string> serchedCourseNames = new List<string>();
            foreach (string courseName in this.courses.Values)
            {
                if (courseName.Contains(substring))
                {
                    serchedCourseNames.Add(courseName);
                }
            }

            return serchedCourseNames;
        }

        public string GetCourseById(int id)
        {
            // return course by id
            if (!this.courses.ContainsKey(id))
            {
                return $"There is no course with id {id} by us!";
            }

            return this.courses[id];
        }
    }
}