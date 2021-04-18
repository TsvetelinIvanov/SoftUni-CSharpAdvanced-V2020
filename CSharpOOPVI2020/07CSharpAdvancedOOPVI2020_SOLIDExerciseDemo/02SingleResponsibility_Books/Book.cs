namespace _02SingleResponsibility_Books
{
    public class Book
    {
        public Book(string author, string title, int pagesCount)
        {
            this.Author = author;
            this.Title = title;
            this.PagesCount = pagesCount;
        }

        public string Title { get; }

        public string Author { get; }

        public int PagesCount { get; }                
    }
}