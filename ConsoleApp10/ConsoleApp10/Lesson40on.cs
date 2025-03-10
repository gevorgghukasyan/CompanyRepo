/*using System;
using System.Collections.Generic;

public interface IBooking
{
    int BookingID { get; }
    string CustomerName { get; }
    string GetBookingDetails();
}

public abstract class Booking : IBooking
{
    public int BookingID { get; protected set; }
    public string CustomerName { get; protected set; }

    public Booking(int bookingId, string customerName)
    {
        BookingID = bookingId;
        CustomerName = customerName;
    }

    public abstract string GetBookingDetails();
}

public class FlightBooking : Booking
{
    public string FlightNumber { get; private set; }

    public FlightBooking(int bookingId, string customerName, string flightNumber)
        : base(bookingId, customerName)
    {
        FlightNumber = flightNumber;
    }

    public override string GetBookingDetails()
    {
        return $"Flight Booking - ID: {BookingID}, Customer: {CustomerName}, Flight: {FlightNumber}";
    }
}

public class HotelBooking : Booking
{
    public string HotelName { get; private set; }

    public HotelBooking(int bookingId, string customerName, string hotelName)
        : base(bookingId, customerName)
    {
        HotelName = hotelName;
    }

    public override string GetBookingDetails()
    {
        return $"Hotel Booking - ID: {BookingID}, Customer: {CustomerName}, Hotel: {HotelName}";
    }
}
public class CarRentalBooking : Booking
{
    public string CarModel { get; private set; }

    public CarRentalBooking(int bookingId, string customerName, string carModel)
        : base(bookingId, customerName)
    {
        CarModel = carModel;
    }

    public override string GetBookingDetails()
    {
        return $"Car Rental Booking - ID: {BookingID}, Customer: {CustomerName}, Car Model: {CarModel}";
    }
}

public class BookingManager
{
    private List<IBooking> bookings = new List<IBooking>();
    public delegate void BookingNotification(string message);
    public event BookingNotification OnBookingConfirmed;
    public event BookingNotification OnBookingCancelled;

    public void AddBooking(IBooking booking)
    {
        bookings.Add(booking);
        OnBookingConfirmed?.Invoke($"Booking confirmed: {booking.GetBookingDetails()}");
    }

    public void CancelBooking(IBooking booking)
    {
        if (bookings.Remove(booking))
        {
            OnBookingCancelled?.Invoke($"Booking cancelled: {booking.GetBookingDetails()}");
        }
    }

    public void DisplayBookings()
    {
        Console.WriteLine("Current Bookings:");
        foreach (var booking in bookings)
        {
            Console.WriteLine(booking.GetBookingDetails());
        }
    }
}

class Program
{
    static void Main()
    {
        BookingManager manager = new BookingManager();
        manager.OnBookingConfirmed += message => Console.WriteLine("[Notification] " + message);
        manager.OnBookingCancelled += message => Console.WriteLine("[Notification] " + message);
        FlightBooking flight = new FlightBooking(1, "A", "a1");
        HotelBooking hotel = new HotelBooking(2, "B", "b1  b1");
        CarRentalBooking car = new CarRentalBooking(3, "c", "b n5");
        manager.AddBooking(flight);
        manager.AddBooking(hotel);
        manager.AddBooking(car);
        manager.DisplayBookings();
        manager.CancelBooking(hotel);
    }
}
*/


using System;
using System.Collections.Generic;

public interface IProduct
{
    int ProductID { get; }
    string Name { get; }
    double Price { get; }
    string GetProductInfo();
}

public abstract class Product : IProduct
{
    public int ProductID { get; protected set; }
    public string Name { get; protected set; }
    public double Price { get; protected set; }

    public Product(int productId, string name, double price)
    {
        ProductID = productId;
        Name = name;
        Price = price;
    }

    public abstract string GetProductInfo();
}

public class ElectronicProduct : Product
{
    public string Brand { get; private set; }

    public ElectronicProduct(int productId, string name, double price, string brand)
        : base(productId, name, price)
    {
        Brand = brand;
    }

    public override string GetProductInfo()
    {
        return $"Electronic Product: {Name}, Brand: {Brand}, Price: {Price:C}";
    }
}

public class ClothingProduct : Product
{
    public string Size { get; private set; }

    public ClothingProduct(int productId, string name, double price, string size)
        : base(productId, name, price)
    {
        Size = size;
    }

    public override string GetProductInfo()
    {
        return $"Clothing Product: {Name}, Size: {Size}, Price: {Price:C}";
    }
}

public class FoodProduct : Product
{
    public DateTime ExpiryDate { get; private set; }

    public FoodProduct(int productId, string name, double price, DateTime expiryDate)
        : base(productId, name, price)
    {
        ExpiryDate = expiryDate;
    }

    public override string GetProductInfo()
    {
        return $"Food Product: {Name}, Expiry Date: {ExpiryDate.ToShortDateString()}, Price: {Price:C}";
    }
}

public class ShoppingCart
{
    private List<IProduct> products = new List<IProduct>();
    public delegate void CartNotification(string message);
    public event CartNotification OnProductAdded;
    public event CartNotification OnProductRemoved;

    public void AddProduct(IProduct product)
    {
        products.Add(product);
        OnProductAdded?.Invoke($"Product added: {product.Name}");
    }

    public void RemoveProduct(IProduct product)
    {
        if (products.Remove(product))
        {
            OnProductRemoved?.Invoke($"Product removed: {product.Name}");
        }
    }

    public void DisplayCart()
    {
        Console.WriteLine("Shopping Cart:");
        foreach (var product in products)
        {
            Console.WriteLine(product.GetProductInfo());
        }
    }
}


class Program
{
    static void Main()
    {
        ShoppingCart cart = new ShoppingCart();

        cart.OnProductAdded += message => Console.WriteLine("[Notification] " + message);
        cart.OnProductRemoved += message => Console.WriteLine("[Notification] " + message);

        ElectronicProduct laptop = new ElectronicProduct(1, "Laptop", 999.99, "Dell");
        ClothingProduct shirt = new ClothingProduct(2, "T-Shirt", 19.99, "M");
        FoodProduct apple = new FoodProduct(3, "A", 0.99, DateTime.Now.AddDays(7));

        cart.AddProduct(laptop);
        cart.AddProduct(shirt);
        cart.AddProduct(apple);

        cart.DisplayCart();
        cart.RemoveProduct(shirt);
    }
}
