internal class DavidHomework28
{
    private static void Main(string[] args)
    {
        Shape cyrcle = new Circle(25);
        cyrcle.CalculateArea();

        //-----------------------------------------------

        Animal animal1 = new Dog();
        Animal animal2 = new Cat();
        List<Animal> animals = new List<Animal>();
        animals.Add(animal1);
        animals.Add(animal2);

        foreach (Animal animal in animals)
        {
            animal.MakeSound();
            animal.Move();
        }

        //-----------------------------------------------

        Vehicle vehicle1 = new Car();
        Vehicle vehicle2 = new Motorcycle();

        List<Vehicle> vehicles = new List<Vehicle>();
        vehicles.Add(vehicle1);
        vehicles.Add(vehicle2);

        foreach (Vehicle vehicle in vehicles)
        {
            vehicle.Start();
            vehicle.Drive();
            vehicle.GetFuel();
        }

        //-----------------------------------------------

        Manager manager = new Manager("John");
        Developer developer = new Developer("Jeffrey", 65);

        manager.DisplayDetails();
        developer.DisplayDetails();

        //-----------------------------------------------

        List<Payment> payments = new List<Payment>();
        payments.Add(new CreditCreditCardPayment());
        payments.Add(new PayPalPayment());

        foreach(Payment payment in payments)
        {
            payment.ProcessPayment();
            payment.PrintReceipt();
        }
    }
}

//-------------------------------- SHAPE -------------------------------------

abstract class Shape
{
    public abstract void CalculateArea();
}

class Circle : Shape
{
    private double _radius;
    public double Radius
    {
        get
        {
            return _radius;
        }
        set
        {
            if (value <= 0)
            {
                throw new Exception("Radius can't be a negative number");
            }
            _radius = value;
        }
    }

    public Circle(double radius)
    {
        Radius = radius;
    }

    public override void CalculateArea()
    {
        Console.WriteLine($"Circle area: {Math.PI * Math.Pow(Radius, 2)}");
    }
}

class Rectangle : Shape
{
    private double _size1;
    private double _size2;

    public double Size1
    {
        get
        {
            return _size1;
        }

        set
        {
            if (value <= 0)
            {
                throw new Exception("Negative or Zero value exception!");
            }
            _size1 = value;
        }
    }

    public double Size2
    {
        get
        {
            return _size2;
        }

        set
        {
            if (value <= 0)
            {
                throw new Exception("Negative or Zero value exception!");
            }
            _size2 = value;
        }
    }

    public Rectangle(double size1, double size2)
    {
        Size1 = size1;
        Size2 = size2;
    }

    public override void CalculateArea()
    {
        Console.WriteLine($"Rectangle area: {Size1 * Size2}");
    }
}

//-------------------------------- ANIMAL -------------------------------------

abstract class Animal
{
    public abstract void MakeSound();
    public void Move()
    {
        Console.WriteLine("The animal moves.");
    }
}

class Dog : Animal
{
    public override void MakeSound()
    {
        Console.WriteLine("Woof");
    }
}

class Cat : Animal
{
    public override void MakeSound()
    {
        Console.WriteLine("Meow");
    }
}

//-------------------------------- VEHICLE -------------------------------------

abstract class Vehicle
{
    public abstract void Drive();

    public void Start()
    {
        Console.WriteLine($"{GetType()} is starting.");
    }

    protected void FuelUp()
    {
        Console.WriteLine($"Refueling the {GetType()}.");
    }

    public void GetFuel() => FuelUp();
}

class Car : Vehicle
{
    public override void Drive()
    {
        Console.WriteLine("Driving a Car");
    }
}

class Motorcycle : Vehicle
{
    public override void Drive()
    {
        Console.WriteLine("Riding a Motorcycle");
    }
}

//-------------------------------- EMPLOYEE -------------------------------------

abstract class Employee
{
    protected int _salary;
    protected abstract int Salary { get; set; }
    protected string Name { get; set; }

    public void DisplayDetails()
    {
        Console.WriteLine($"Name: {Name}  |  Salary: {Salary}");
    }
}

class Manager : Employee
{
    protected override int Salary
    {
        get
        {
            return _salary;
        }
        set
        {
            _salary = 5000;
        }
    }

    public Manager(string name)
    {
        Name = name;
        Salary = Salary;
    }
}

class Developer : Employee
{
    private int _bonusHours;

    public int BonusHours
    {
        get
        {
            return _bonusHours;
        }
        set
        {
            if (value <= 0)
            {
                _bonusHours = 0;
                return;
            }
            _bonusHours = value;
        }
    }

    protected override int Salary
    {
        get
        {
            return _salary;
        }
        set
        {
            _salary = 3000 + 20 * BonusHours;
        }
    }

    public Developer(string name, int bonusHours)
    {
        Name = name;
        BonusHours = bonusHours;
        Salary = Salary;
    }
}

//-------------------------------- PAYMENT -------------------------------------

abstract class Payment
{
    public abstract void ProcessPayment();

    public void PrintReceipt()
    {
        Console.WriteLine("Receipt generated.");
    }
}

class CreditCreditCardPayment : Payment
{
    public override void ProcessPayment()
    {
        Console.WriteLine("Processing credit card payment.");
    }

}

class PayPalPayment : Payment
{
    public override void ProcessPayment()
    {
        Console.WriteLine("Processing PayPal payment.");
    }
}