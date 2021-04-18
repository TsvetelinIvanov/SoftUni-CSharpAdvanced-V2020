using System;

namespace _02SingleResponsibility_Books
{
    class Program
    {
        static void Main(string[] args)
        {
            Book book = new Book("Isaac Asimov", "Foundation", 910);
            Library library = new Library();
            library.AddBook(book, "Reading room");

            Console.WriteLine(library.SetCurrentPage(book, 67));//True
            Console.WriteLine(library.Contains(book));//True
            Console.WriteLine(library.GetCurrentPage(book));//67
            Console.WriteLine(library.GetLocation(book));//Reading room
            Console.WriteLine(library.ChangeLocation(book, "Store 8"));//True
            Console.WriteLine(library.GetLocation(book));//Store 8
        }
    }
}