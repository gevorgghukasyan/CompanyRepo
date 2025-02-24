using System;

namespace Interface
    
{

    //1---------------------------------

    public interface IShape
    {
        double GetArea();
        double GetPerimeter();
    }

    public class Circle : IShape
    {
        public double Radius { get; set; }

        public Circle(double radius)
        {
            Radius = radius;
        }

        public double GetArea()
        {
            return Math.PI * Radius * Radius;
        }

        public double GetPerimeter()
        {
            return 2 * Math.PI * Radius;
        }
    }

    public class Rectangle : IShape
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public Rectangle(double width, double height)
        {
            Width = width;
            Height = height;
        }

        public double GetArea()
        {
            return Width * Height;
        }

        public double GetPerimeter()
        {
            return 2 * (Width + Height);
        }
    }


    //2----------------
    public interface IVehicle
    {
        string Make { get; set; }
        string Model { get; set; }
    }

    public class Car : IVehicle
    {
        public string Make { get; set; }
        public string Model { get; set; }

        public void DisplayInfo()
        {
            Console.WriteLine($"Car: {Make} {Model}");
        }
    }

    public class Motorcycle : IVehicle
    {
        public string Make { get; set; }
        public string Model { get; set; }

        public void DisplayInfo()
        {
            Console.WriteLine($"Motorcycle: {Make} {Model}");
        }
    }


    //3-----------------------------

    /*public interface IFlyable
    {
        void Fly();
    }

    public interface ISwimmable
    {
        void Swim();
    }

    public class Duck : IFlyable, ISwimmable
    {
        public void Fly()
        {
            Console.WriteLine("flying.");
        }

        public void Swim()
        {
            Console.WriteLine("swimming.");
        }
    }*/

    //4----------------------------
    public interface IBase
    {
        void BaseMethod();
    }
    public interface IDerived : IBase
    {
        void DerivedMethod();
    }

    public class DerivedClass : IDerived
    {
        public void BaseMethod()
        {
            Console.WriteLine("BaseMethod() IBase interface.");
        }

        public void DerivedMethod()
        {
            Console.WriteLine("DerivedMethod()  IDerived interface.");
        }
    }


    //5--------------------------------

    //7------------------


    public interface IDisplayable
    {
        void Display();
    }
    public class Product : IDisplayable
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public Product(string name, double price)
        {
            Name = name;
            Price = price;
        }
        public void Display()
        {
            Console.WriteLine($"Product Name: {Name}, Price: ${Price}");
        }
    }

    //1----------------------
    public abstract class Animal
    {
        public abstract void MakeSound();
        public void Sleep()
        {
            Console.WriteLine("The animal is sleeping.");
        }
    }

    public interface IMovable
    {
        void Move();
    }

    public class Dog : Animal, IMovable
    {

        public override void MakeSound()
        {
            Console.WriteLine("Dog says: Woof!");
        }

        public void Move()
        {
            Console.WriteLine("The dog is running.");
        }
    }

    //2-+-------------------
    /* public abstract class Shape
     {
         public abstract double Area { get; }
     }

     public interface IColorable
     {
         string Color { get; set; }
     }

     public class Rectangle : Shape, IColorable
     {
         public double Width { get; set; }
         public double Height { get; set; }
         public override double Area
         {
             get { return Width * Height; }
         }

         public string Color { get; set; }

         public Rectangle(double width, double height, string color)
         {
             Width = width;
             Height = height;
             Color = color;
         }
     }*/

    //3---------------------
    public interface IFlyable
    {
        void Fly();
    }

    public abstract class Bird
    {
        public abstract void MakeSound();
    }

    public class Eagle : Bird, IFlyable
    {
        public override void MakeSound()
        {
            Console.WriteLine("Eagle sound: Screech!");
        }
        public void Fly()
        {
            Console.WriteLine("The eagle soars high in the sky.");
        }
    }


    //4----------------------------------------

    public abstract class Device
    {
        public string Name { get; set; }

        public Device(string name)
        {
            Name = name;
        }
        public abstract string GetDeviceName();
    }
    public interface IPower
    {
        void TurnOn();
    }

    public class Smartphone : Device, IPower
    {
        public Smartphone(string name) : base(name)
        {
        }

        public override string GetDeviceName()
        {
            return Name;
        }
        public void TurnOn()
        {
            Console.WriteLine($"The {Name} is now turned on.");
        }
    }


    //5--------------------------------

    public abstract class Person
    {
        public abstract void Work();
    }
    public interface IEducable
    {
        void Study();
    }
    public class Student : Person, IEducable
    {
        public override void Work()
        {
            Console.WriteLine("The student is studying.");
        }
        public void Study()
        {
            Console.WriteLine("The student is learning new topics.");
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            //1-------------------------------
            IShape circle = new Circle(7);
            Console.WriteLine(circle.GetArea());
            Console.WriteLine(circle.GetPerimeter());

            IShape rectangle = new Rectangle(2, 8);
            Console.WriteLine(rectangle.GetArea());
            Console.WriteLine(rectangle.GetPerimeter());



            //2--------------------------------

            IVehicle car = new Car
            {
                Make = "A",
                Model = "A",
            };
            ((Car)car).DisplayInfo();

            IVehicle motorcycle = new Motorcycle
            {
                Make = "B",
                Model = "B",
            };
            ((Motorcycle)motorcycle).DisplayInfo();


            //3--------------------
            /*  Duck duck = new Duck();
              duck.Fly();
              duck.Swim();*/


            //4---------------------------

            DerivedClass derivedObject = new DerivedClass();
            derivedObject.BaseMethod();
            derivedObject.DerivedMethod();

            //5---------------------------

            //7-------------------------
            IDisplayable product = new Product("div", 1024);
            product.Display();

            //1---------------------

            Dog myDog = new Dog();
            myDog.MakeSound();
            myDog.Sleep();
            myDog.Move();

            ///2-----------------------
           /* Rectangle myRectangle = new Rectangle(9.0, 10.0, "Pink");

            Console.WriteLine($"Rectangle Color: {myRectangle.Color}");
            Console.WriteLine($"Rectangle Area: {myRectangle.Area}");*/

            //3-----------------------
            Eagle myEagle = new Eagle();
            myEagle.MakeSound();
            myEagle.Fly();

            //4--------------------------
            Smartphone mySmartphone = new Smartphone("iPhone");
            Console.WriteLine($"Device Name: {mySmartphone.GetDeviceName()}");
            mySmartphone.TurnOn();

            //5------------------------------

            Student myStudent = new Student();
            myStudent.Work();
            myStudent.Study();

        }
    }
}
