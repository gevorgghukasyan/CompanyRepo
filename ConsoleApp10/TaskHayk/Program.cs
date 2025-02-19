using System;

namespace TaskHayk
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Task 1------------------------------
            //List<Shape> shapes = new List<Shape>();
            //shapes.Add(new Circle(10));
            //shapes.Add(new Rectangle(4, 5));

            //foreach (Shape el in shapes) 
            //{
            //    el.CalculateArea();
            //    Console.WriteLine();
            //}
            //-----------------------------------------

            // Task 2 -----------------------------
            //List<Animal> animals = new List<Animal>();
            //animals.Add(new Dog());
            //animals.Add(new Cat());
            //foreach (Animal el in animals) 
            //{
            //    el.MakeSound();
            //    Console.WriteLine();
            //    el.Move();
            //    Console.WriteLine();
            //}
            //-------------------------------------------

            //Task 3--------------------------
            //Vehicle car = new Car();
            //car.Start();
            //car.Drive();
            ////car.FuelUp();  ???????????? Chi ashxatum protected-i patcharov
            //Console.WriteLine("----------------------");

            //Vehicle moto = new MotorCicle();
            //moto.Start();
            //moto.Drive();
            //----------------------------------------

            //Task 4 ------------------------------------
            //Employee manager = new Manager("Aram");
            //manager.DisplayDetails();

            //Employee developer = new Developer("Babken", 48);
            //developer.DisplayDetails();
            //--------------------------------------------

            //Task 5 ---------------------------------------
            Payment credit = new CreditCardPayment();
            credit.ProcessPayment();
            credit.PrintReceipt();

            Console.WriteLine("----------------------------");
            Payment paypal = new PayPalPayment();
            paypal.ProcessPayment();
            paypal.PrintReceipt();

        }
    }

    // -------Task 1: Basic Abstraction---------

    abstract class Shape
    {
        abstract protected string Name { get; }
        abstract public void CalculateArea();
    }

    class Circle : Shape
    {
        private int _radius;
        public int Radius
        {
            get
            {
                return _radius;
            }
            set
            {
                if (value > 0)
                {
                    _radius = value;
                }
                else
                {
                    throw new Exception("Radius must be greater than 0.");
                }
            }
        }

        protected override string Name { get; } = "Circle";
         public override void CalculateArea()
        {
            double area = Math.PI * Math.Pow(Radius, 2);
            Console.WriteLine($"The area of the {Name} is: {area}");
        }

        public Circle(int r)
        {
            Radius = r;
        }
    }

    class Rectangle : Shape
    {
        protected override string Name { get; } = "Rectangle";

        private int _length;

        public int Length
        {
            get
            {
                return _length;
            }
            set
            {
                if(value > 0)
                {
                    _length = value;
                }
            }
        }

        private int _width;

        public int Width
        {
            get
            {
                return _width;
            }
            set
            {
                if (value > 0)
                {
                    _width = value;
                }
            }
        }

        public Rectangle(int width, int length)
        {
            Width = width;
            Length = length;
        }

        public override void CalculateArea()
        {
            double arrea = Length * Width;
            Console.WriteLine($"The area of the {Name} is: {arrea}");
        }
    }
    //---------------Task 2: Abstract Methods with Polymorphism-------------------------

    abstract class Animal
    {
        abstract public void MakeSound();

        public void Move()
        {
            Console.WriteLine("The animal moves");
        }
    }

    class Dog : Animal
    {
        override public void MakeSound()
        {
            Console.WriteLine("Dog sound");
        }
    }

    class Cat : Animal
    {
        override public void MakeSound()
        {
            Console.WriteLine("Cat sound");
        }
    }

    //--------------Task 3: Partial Abstraction--------------------------------

    abstract class Vehicle
    {
        abstract public void Drive();

        public void Start()
        {
            Console.WriteLine("Vehicle is starting");
        }

        protected void FuelUp()
        {
            Console.WriteLine("Refueling the vehicle");
        }
    }

    class Car:Vehicle
    {
        public override void Drive()
        {
            Console.WriteLine("Driving a car");
        }
    }

    class MotorCicle:Vehicle
    {
        public override void Drive()
        {
           Console.WriteLine("Riding a motorcycle");
        }
    }

    //---------Task 4: Abstract Properties-----------------

    abstract class Employee
    {
        
        abstract public int Salary { get; }

        public string Name { get; set; }

        public Employee(string name)
        {
            Name = name;
        }

        public void DisplayDetails()
        {
            Console.WriteLine($"Employee name is {Name}, selary is {Salary}");
        }
    }

    class Manager : Employee
    {
        override public int Salary { get; } = 5000;

        public Manager(string name) : base(name) { }
    }

    class Developer : Employee
    {
        public int BonusHours { get; set; }
        override public int Salary => 3000 + 20 * BonusHours;

        public Developer(string name, int hour) : base(name) 
        {
            BonusHours = hour;
        }
    }

    //----------Task 5: Abstract Classes in a Real-World Scenario-----------

    abstract class Payment
    {
        abstract public void ProcessPayment();

        public void PrintReceipt()
        {
            Console.WriteLine("Receipt generated");
        }
    }

    class CreditCardPayment : Payment
    {
        override public void ProcessPayment()
        {
            Console.WriteLine("Processing credit card payment");
        }
    }

    class PayPalPayment  : Payment
    {
        override public void ProcessPayment()
        {
            Console.WriteLine("Processing PayPal payment");
        }
    }

}
