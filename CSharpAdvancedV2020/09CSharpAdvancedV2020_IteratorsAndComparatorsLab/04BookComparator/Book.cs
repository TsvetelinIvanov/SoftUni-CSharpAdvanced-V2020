using System;
using System.Collections.Generic;

namespace IteratorsAndComparators
{
    public class Book : IComparable<Book>
    {
        public Book(string title, int year, params string[] authors)
        {
            this.Title = title;
            this.Year = year;
            this.Authors = authors;
        }

        public string Title { get; private set; }

        public int Year { get; private set; }

        public IReadOnlyCollection<string> Authors { get; private set; }

        public int CompareTo(Book otherBook)
        {
            int comparationResult = this.Year.CompareTo(otherBook.Year);
            if (comparationResult == 0)
            {
                comparationResult = this.Title.CompareTo(otherBook.Title);
            }

            return comparationResult;
        }

        public override string ToString()
        {
            return $"{this.Title} - {this.Year}";
        }
    }
}