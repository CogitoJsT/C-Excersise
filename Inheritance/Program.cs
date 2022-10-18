using System;

class Book
{
    decimal isbn13;

    public Book()
    {
        Console.WriteLine("Book default constructor");
    }
    public Book(decimal isbn13)
    {
        this.isbn13 = isbn13;
        Console.WriteLine("Book constructor with isbn13");
    }
}

class EBook : Book
{
    public EBook()
    {
        Console.WriteLine("EBook constructor");
    }

    public EBook(decimal isbn13)
        : base(isbn13)
    {
        Console.WriteLine("EBook constructor with isbn13");
    }
}

namespace Ineritance
{
    class Program
    {
        static void Main(string[] args)
        {
            var ebook = new EBook();
            var ebook2 = new EBook(1234);
        }
    }
}
