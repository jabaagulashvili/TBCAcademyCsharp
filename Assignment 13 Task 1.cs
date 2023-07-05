using System;
using System.Collections.Generic;

class Book
{
    public string BookNumber { get; }
    public string Title { get; }
    public string Author { get; }

    public Book(string bookNumber, string title, string author)
    {
        if (string.IsNullOrEmpty(bookNumber))
            throw new ArgumentNullException("Book number can't be neither null nor empty.");

        if (string.IsNullOrEmpty(title))
            throw new ArgumentNullException("Title can't be neither null nor empty.");

        if (string.IsNullOrEmpty(author))
            throw new ArgumentNullException("Author can't be neither null nor empty.");

        BookNumber = bookNumber;
        Title = title;
        Author = author;
    }
}

class Library
{
    private List<Book> books;

    public int Capacity { get; }

    public Library(int capacity)
    {
        books = new List<Book>();
        Capacity = capacity;
    }

    public void AddBook(Book book)
    {
        if (book == null)
            throw new ArgumentNullException("Book cannot be null.");

        if (books.Count >= Capacity)
            throw new IndexOutOfRangeException("The library is at its maximum capacity.");

        books.Add(book);
        Console.WriteLine("Book added: " + book.Title);
    }

    public Book GetBook(string bookNumber)
    {
        foreach (var book in books)
        {
            if (book.BookNumber == bookNumber)
                return book;
        }

        throw new BookNotFoundException("Book isn't found.");
    }
}

class BookNotFoundException : Exception
{
    public BookNotFoundException(string message) : base(message)
    {
    }
}

class Assignment

{
    static void Main()
    {
        try
        {
            Library library = new Library(3);

            Book book1 = new Book("Book1", "Book 1", "Author X");
            library.AddBook(book1);

            Book book2 = new Book("Book2", "Book 2", "Author Y");
            library.AddBook(book2);

            Book book3 = new Book("Book3", "Book 3", "Author Z");
            library.AddBook(book3);

            Book book4 = new Book("Book4", "Book 4", "Author H");
            library.AddBook(book4);

            Book foundBook = library.GetBook("B002");
            Console.WriteLine("Found book: " + foundBook.Title);
        }
        catch (ArgumentNullException ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
        catch (IndexOutOfRangeException ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
        catch (BookNotFoundException ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
        finally
        {
            Console.WriteLine("Program execution complete.");
        }
    }
}
