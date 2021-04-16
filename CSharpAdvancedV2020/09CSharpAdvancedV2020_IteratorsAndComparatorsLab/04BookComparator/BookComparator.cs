using System.Collections.Generic;

namespace IteratorsAndComparators
{
    public class BookComparator : IComparer<Book>
    {
        public int Compare(Book firstBook, Book secondBook)
        {
            int comparationResult = firstBook.Title.CompareTo(secondBook.Title);
            if (comparationResult == 0)
            {
                comparationResult = secondBook.Year.CompareTo(firstBook.Year);
            }

            return comparationResult;
        }
    }
}