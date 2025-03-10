using System;
using System.Collections.Generic;
using System.Linq;

public abstract class LibraryResource
{
    public string Title { get; set; }
    public bool IsRented { get; private set; }
    public DateTime DueDate { get; private set; }

    public abstract void Rent();
    public abstract void Return();

    public void MarkAsRented()
    {
        IsRented = true;
        DueDate = DateTime.Now.AddDays(7); 
    }

    public void MarkAsReturned()
    {
        IsRented = false;
        DueDate = DateTime.MinValue; 
    }
}

public class Book : LibraryResource
{
    public int PageCount { get; set; }

    public Book(string title, int pageCount)
    {
        Title = title;
        PageCount = pageCount;
    }

    public override void Rent()
    {
        if (IsRented)
        {
            Console.WriteLine($"{Title} is already rented.");
        }
        else
        {
            MarkAsRented();
            Console.WriteLine($"{Title} has been rented. Please return it by {DueDate.ToShortDateString()}.");
        }
    }

    public override void Return()
    {
        if (!IsRented)
        {
            Console.WriteLine($"{Title} was not rented.");
        }
        else
        {
            MarkAsReturned();
            Console.WriteLine($"{Title} has been returned.");
        }
    }
}

public class Magazine : LibraryResource
{
    public string IssueDate { get; set; }

    public Magazine(string title, string issueDate)
    {
        Title = title;
        IssueDate = issueDate;
    }

    public override void Rent()
    {
        if (IsRented)
        {
            Console.WriteLine($"{Title} is already rented.");
        }
        else
        {
            MarkAsRented();
            Console.WriteLine($"{Title} has been rented. Please return it by {DueDate.ToShortDateString()}.");
        }
    }

    public override void Return()
    {
        if (!IsRented)
        {
            Console.WriteLine($"{Title} was not rented.");
        }
        else
        {
            MarkAsReturned();
            Console.WriteLine($"{Title} has been returned.");
        }
    }
}

public class DVD : LibraryResource
{
    public string Genre { get; set; }

    public DVD(string title, string genre)
    {
        Title = title;
        Genre = genre;
    }

    public override void Rent()
    {
        if (IsRented)
        {
            Console.WriteLine($"{Title} is already rented.");
        }
        else
        {
            MarkAsRented();
            Console.WriteLine($"{Title} has been rented. Please return it by {DueDate.ToShortDateString()}.");
        }
    }

    public override void Return()
    {
        if (!IsRented)
        {
            Console.WriteLine($"{Title} was not rented.");
        }
        else
        {
            MarkAsReturned();
            Console.WriteLine($"{Title} has been returned.");
        }
    }
}

public class Library<T> where T : LibraryResource
{
    private List<T> resources = new List<T>();
    private List<T> rentedResources = new List<T>();

    public void AddResource(T resource)
    {
        resources.Add(resource);
    }

    public void RentResource(string title)
    {
        var resource = resources.FirstOrDefault(r => r.Title == title && !r.IsRented);
        if (resource != null)
        {
            resource.Rent();
            resources.Remove(resource);
            rentedResources.Add(resource);
        }
        else
        {
            Console.WriteLine($"Resource {title} is not available for rent.");
        }
    }

    public void ReturnResource(string title)
    {
        var resource = rentedResources.FirstOrDefault(r => r.Title == title && r.IsRented);
        if (resource != null)
        {
            resource.Return();
            rentedResources.Remove(resource);
            resources.Add(resource);
        }
        else
        {
            Console.WriteLine($"Resource {title} was not rented.");
        }
    }

    public void DisplayResources()
    {
        Console.WriteLine("\nAvailable Resources:");
        foreach (var resource in resources)
        {
            Console.WriteLine($"- {resource.Title}");
        }
    }
}

public class Admin
{
    private Library<LibraryResource> library;

    public Admin(Library<LibraryResource> library)
    {
        this.library = library;
    }

    public void AddResource()
    {
        Console.WriteLine("\nEnter the type of resource (Book, Magazine, DVD): ");
        string resourceType = Console.ReadLine().ToLower();

        Console.WriteLine("Enter the title of the resource: ");
        string title = Console.ReadLine();

        switch (resourceType)
        {
            case "book":
                Console.WriteLine("Enter the page count: ");
                int pageCount = int.Parse(Console.ReadLine());
                library.AddResource(new Book(title, pageCount));
                break;

            case "magazine":
                Console.WriteLine("Enter the issue date of the magazine: ");
                string issueDate = Console.ReadLine();
                library.AddResource(new Magazine(title, issueDate));
                break;

            case "dvd":
                Console.WriteLine("Enter the genre of the DVD: ");
                string genre = Console.ReadLine();
                library.AddResource(new DVD(title, genre));
                break;

            default:
                Console.WriteLine("Invalid resource type.");
                break;
        }
    }

    public void ManageLibrary()
    {
        while (true)
        {
            Console.WriteLine("\n--- Admin Menu ---");
            Console.WriteLine("1. Add Resource");
            Console.WriteLine("2. Display Resources");
            Console.WriteLine("3. Exit");
            Console.Write("Select an option: ");
            int option = int.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    AddResource();
                    break;
                case 2:
                    library.DisplayResources();
                    break;
                case 3:
                    return;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }
    }
}

public class Program
{
    static void Main(string[] args)
    {
        Library<LibraryResource> library = new Library<LibraryResource>();

        Admin admin = new Admin(library);
        admin.ManageLibrary();

        while (true)
        {
            Console.WriteLine("\n--- Student Menu ---");
            library.DisplayResources();
            Console.WriteLine("Enter the title of the resource to rent or type 'exit' to quit:");
            string title = Console.ReadLine();

            if (title.ToLower() == "exit")
                break;

            library.RentResource(title);

            Console.WriteLine("\n--- Return Resource ---");
            Console.WriteLine("Enter the title of the resource to return or type 'exit' to quit:");
            title = Console.ReadLine();

            if (title.ToLower() == "exit")
                break;

            library.ReturnResource(title);
        }
    }
}
