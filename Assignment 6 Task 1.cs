using System;

namespace LibrarySystem
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
    }

    public class Library
    {
        private Book[] books;

        public Library()
        {
            books = new Book[0];
        }

        public Book this[int index]
        {
            get { return books[index]; }
            set { books[index] = value; }
        }

        public int Count
        {
            get { return books.Length; }
        }

        public void AddBook(Book book)
        {
            Array.Resize(ref books, books.Length + 1);
            books[books.Length - 1] = book;
        }

        public void RemoveBook(Book book)
        {
            int index = Array.IndexOf(books, book);
            if (index >= 0)
            {
                for (int i = index; i < books.Length - 1; i++)
                {
                    books[i] = books[i + 1];
                }
                Array.Resize(ref books, books.Length - 1);
            }
        }

        public Book FindBook(string title)
        {
            foreach (Book book in books)
            {
                if (book.Title.Equals(title, StringComparison.OrdinalIgnoreCase))
                {
                    return book;
                }
            }
            return null;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();


            library.AddBook(new Book { Title = "Book 1", Author = "Author 1", Year = 1980 });
            library.AddBook(new Book { Title = "Book 2", Author = "Author 2", Year = 1995 });
            library.AddBook(new Book { Title = "Book 3", Author = "Author 3", Year = 2005 });


            Console.WriteLine("Book at index 0: " + library[0].Title);
            Console.WriteLine("Book at index 1: " + library[1].Title);


            Console.WriteLine("Number of books in the library: " + library.Count);


            Book bookToRemove = library.FindBook("Book 2");
            library.RemoveBook(bookToRemove);


            Book bookToFind = library.FindBook("Book 3");
            if (bookToFind != null)
            {
                Console.WriteLine("Book found: " + bookToFind.Title);
            }
            else
            {
                Console.WriteLine("Book not found.");
            }

            Console.ReadLine();
        }
    }
}