using System;
using System.Collections.Generic;

namespace _02SingleResponsibility_Books
{
    public class Library
    {
        private Dictionary<Book, int> bookCurrentPages = new Dictionary<Book, int>();
        private Dictionary<Book, string> bookLocations = new Dictionary<Book, string>();

        public bool Contains(Book book) => this.bookLocations.ContainsKey(book);

        public void AddBook(Book book, string location)
        {
            this.bookCurrentPages.Add(book, 0);
            this.bookLocations.Add(book, location);
        }        

        public bool SetCurrentPage(Book book, int currentPage)
        {
            if (!this.bookCurrentPages.ContainsKey(book))
            {
                throw new ArgumentNullException("book", $"The book from author {book.Author} with title \"{book.Title}\" doesn't exist in our library!");
            }

            if (currentPage <= 0 || currentPage > book.PagesCount)
            {
                throw new ArgumentOutOfRangeException("currentPage", $"The page {currentPage} doesn't exist in this book!");
            }

            this.bookCurrentPages[book] = currentPage;

            return true;
        }

        public int GetCurrentPage(Book book)
        {
            if (!this.bookCurrentPages.ContainsKey(book))
            {
                throw new ArgumentNullException("book", $"The book from author {book.Author} with title \"{book.Title}\" doesn't exist in our library!");
            }

            return this.bookCurrentPages[book];
        }

        public bool ChangeLocation(Book book, string newLocation)
        {
            if (!this.bookLocations.ContainsKey(book))
            {
                throw new ArgumentNullException("book", $"The book from author {book.Author} with title \"{book.Title}\" doesn't exist in our library!");
            }            

            this.bookLocations[book] = newLocation;

            return true;
        }

        public string GetLocation(Book book)
        {
            if (!this.bookLocations.ContainsKey(book))
            {
                throw new ArgumentNullException("book", $"The book from author {book.Author} with title \"{book.Title}\" doesn't exist in our library!");
            }

            return this.bookLocations[book];           
        }
    }
}