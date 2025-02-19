using System;
using System.Collections.Generic;


//----------------1
abstract class Shape
{
    public string Name { get; }

    public Shape(string name)
    {
        Name = name;
    }

    public abstract double CalculateArea();
}

class Circle : Shape
{
    public double Radius { get; }

    public Circle(double radius) : base("Circle")
    {
        Radius = radius;
    }

    public override double CalculateArea()
    {
        return Math.PI * Radius * Radius;
    }
}
class Rectangle : Shape
{
    public double Length { get; }
    public double Width { get; }

    public Rectangle(double length, double width) : base("Rectangle")
    {
        Length = length;
        Width = width;
    }

    public override double CalculateArea()
    {
        return Length * Width;
    }
}

//2-------------------------------
abstract class Animal
{
    public abstract void MakeSound();

    public void Move()
    {
        Console.WriteLine("animal moves.");
    }
}

class Dog : Animal
{
    public override void MakeSound()
    {
        Console.WriteLine("Wof");
    }
}

class Cat : Animal
{
    public override void MakeSound()
    {
        Console.WriteLine("Meow");
    }
}

//3-----------------------
abstract class Vehicle
{
    public abstract void Drive();
    public void Start()
    {
        Console.WriteLine("Vehicle is starting.");
    }
    protected void FuelUp()
    {
        Console.WriteLine("Refueling the vehicle.");
    }
}
class Car : Vehicle
{
    public override void Drive()
    {
        Console.WriteLine("Driving a car.");
    }
}
class Motorcycle : Vehicle
{
    public override void Drive()
    {
        Console.WriteLine("Riding a motorcycle.");
    }
}

//4----------------------
abstract class Employee
{
    public abstract double Salary { get; }

    private string name;
    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public void DisplayDetails()
    {
        Console.WriteLine($"{Name} / {Salary} ");
    }
}

class Manager : Employee
{
    private double salary = 5000;

    public override double Salary
    {
        get { return salary; }
    }
}
class Developer : Employee
{
    private int bonusHours;
    private double salaryBase = 3000;
    public int BonusHours
    {
        get { return bonusHours; }
        set { bonusHours = value; }
    }
    public override double Salary
    {
        get { return salaryBase + 20 * BonusHours; }
    }
    public int GetBonusHours()
    {
        return BonusHours;
    }
}


//5-----------------------
abstract class Payment
{
    public abstract void ProcessPayment();
    public void PrintReceipt()
    {
        Console.WriteLine("Receipt generated.");
    }
}

class CreditCardPayment : Payment
{
    public override void ProcessPayment()
    {
        Console.WriteLine("card payment.");
    }
}
class PayPalPayment : Payment
{
    public override void ProcessPayment()
    {
        Console.WriteLine("PayPal payment.");
    }
}

class Program
{
    static void Main()
    {
        //1------------------------
        List<Shape> shapes = new List<Shape>
        {
            new Circle(5),
            new Rectangle(4, 6),
            new Circle(3),
            new Rectangle(7, 2)
        };

        foreach (var shape in shapes)
        {
            Console.WriteLine($"{shape.Name} - {shape.CalculateArea()}");
        }


        //2------------------------
        List<Animal> animals = new List<Animal>
        {
            new Dog(),
            new Cat()
        };

        foreach (var item in animals)
        {
            item.MakeSound();
            item.Move();
        }



        //3--------------------------
        Vehicle Car = new Car();
        Vehicle Motorcycle = new Motorcycle();

        Car.Start();
        Car.Drive();

        //4------------------------
        Employee manager = new Manager();
        manager.Name = "A";
        manager.DisplayDetails();

        Developer developer = new Developer();
        developer.Name = "B";
        developer.BonusHours = 2;
        developer.DisplayDetails();

        ///5-------------
        Payment creditCardPayment = new CreditCardPayment();
        Payment paypalPayment = new PayPalPayment();
        creditCardPayment.ProcessPayment();
        creditCardPayment.PrintReceipt();
        paypalPayment.ProcessPayment();
        paypalPayment.PrintReceipt();

        Console.ReadKey();
    }
}
