using System;
using System.Collections.Generic;

namespace _05DateModifier
{
    public class DateModifier
    {
        private readonly List<int> dayDifferences;

        public DateModifier()
        {
            this.dayDifferences = new List<int>();
        }

        public List<int> DayDifferences
        {
            get { return this.dayDifferences; }
        }

        public int CalculateDayDifference(string firstDateString, string secondDateString)
        {
            DateTime firstDate = Convert.ToDateTime(firstDateString);
            DateTime secondDate = Convert.ToDateTime(secondDateString);
            int dayDifference = Math.Abs((firstDate - secondDate).Days);
            dayDifferences.Add(dayDifference);

            return dayDifference;
        }
    }
}