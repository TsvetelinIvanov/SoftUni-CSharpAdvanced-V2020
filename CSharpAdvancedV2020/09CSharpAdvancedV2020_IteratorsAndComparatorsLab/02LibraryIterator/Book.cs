﻿using System.Collections.Generic;

namespace IteratorsAndComparators
{
    public class Book
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
    }
}