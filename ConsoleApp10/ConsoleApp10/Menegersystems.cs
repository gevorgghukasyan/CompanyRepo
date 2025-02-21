using System;
using System.Collections.Generic;

public abstract class LibraryEntity
{
    public int Id { get; set; }
    public string Name { get; set; }

    public abstract void DisplayDetails();
}

public class Book : LibraryEntity
{
    public string Author { get; set; }
    public string ISBN { get; set; }
    public string Category { get; set; }

    public override void DisplayDetails()
    {
        Console.WriteLine($" ID: {Id}, Title: {Name}, Author: {Author}, ISBN: {ISBN}, Category: {Category}");
    }
}

public class Member : LibraryEntity
{
    public string MembershipType { get; set; }
    public List<Book> BorrowedBooks { get; set; } = new List<Book>();

    public override void DisplayDetails()
    {
        Console.WriteLine($"Member ID: {Id}, Name: {Name}, Membership Type: {MembershipType}");
        Console.WriteLine("Borrowed Books:");
        foreach (var book in BorrowedBooks)
        {
            Console.WriteLine($" {book.Name} / {book.Author}");
        }
    }
}

public class Library
{
    private List<Book> books = new List<Book>();
    private List<Member> members = new List<Member>();

    public void AddBook(Book book)
    {
        books.Add(book);
    }

    public void AddMember(Member member)
    {
        members.Add(member);
    }

    public void DisplayBooks()
    {
        Console.WriteLine("Books in the Library:");
        foreach (var book in books)
        {
            book.DisplayDetails();
        }
    }

    public void DisplayMembers()
    {
        Console.WriteLine("Library Members:");
        foreach (var member in members)
        {
            member.DisplayDetails();
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Library library = new Library();

        while (true)
        {

            Console.WriteLine("1. Add Book");
            Console.WriteLine("2. Add Member");
            Console.WriteLine("3. Display Books");
            Console.WriteLine("4. Display Members");
            Console.WriteLine("5. Exit");
            Console.Write("Enter number: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Book newBook = new Book();
                    Console.Write("Enter Book ID: ");
                    newBook.Id = int.Parse(Console.ReadLine());
                    Console.Write("Enter Book Name: ");
                    newBook.Name = Console.ReadLine();
                    Console.Write("Enter Author: ");
                    newBook.Author = Console.ReadLine();
                    Console.Write("Enter ISBN: ");
                    newBook.ISBN = Console.ReadLine();
                    Console.Write("Enter Category: ");
                    newBook.Category = Console.ReadLine();
                    library.AddBook(newBook);
                    break;

                case "2":
                    Member newMember = new Member();
                    Console.Write("Enter Member ID: ");
                    newMember.Id = int.Parse(Console.ReadLine());
                    Console.Write("Enter Member Name: ");
                    newMember.Name = Console.ReadLine();
                    Console.Write("Enter Membership Type: ");
                    newMember.MembershipType = Console.ReadLine();
                    library.AddMember(newMember);
                    break;

                case "3":
                    library.DisplayBooks();
                    break;

                case "4":
                    library.DisplayMembers();
                    break;

                case "5":
                    Console.WriteLine("Exiting the program...");
                    return;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}
