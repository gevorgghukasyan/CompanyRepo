using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {

        static void Swap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }

        static void Swaps(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }


        static void ModifyStruct(MyStruct s)
        {
            s.Number = 100; 
        }
        static void ModifyClass(MyClass c)
        {
            c.Number = 100; 
        }

        static void PrintArray(in int[] array)
        {
            Console.Write("Array elements: ");
            foreach (int num in array)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            Person person = new Person("ann", 2);
            person.Print();

            BankAccout accout = new BankAccout();
            accout.AddBalance(500);


            Student student = new Student();
            student.AddGrade(10);
            student.Print();


            Rectangle rect = new Rectangle(5, 25);
            rect.GetPerimeter();


            Employee employee = new Employee();
            employee.SetSalary(50000);


            Book myBook = new Book("d", "d");
            myBook.DisplayBookInfo();


            User user = new User("pas");
            Console.Write("password: ");
            string enteredPassword = Console.ReadLine();

            if (user.CheckPassword(enteredPassword))
            {
                Console.WriteLine("exellut");
            }
            else
            {
                Console.WriteLine("404։");
            }


            Warrior warrior = new Warrior(150, 100);
            warrior.DisplayInfo();
            warrior.Attack();
            Mage mage = new Mage(60, 60);
            mage.DisplayInfo();
            mage.CastSpell();


            Box<int> intBox = new Box<int>();
            intBox.Add(42);
            Console.WriteLine("Integer value: " + intBox.Get());

            Box<string> stringBox = new Box<string>();
            stringBox.Add("Hello");
            Console.WriteLine("String value: " + stringBox.Get());


            int x = 10, y = 20;
            Console.WriteLine($"Before Swap: x = {x}, y = {y}");
            Swap(ref x, ref y);
            Console.WriteLine($"After Swap: x = {x}, y = {y}");

            Repository<Students> studentRepo = new Repository<Students>();
            studentRepo.Add(new Students { Id = 1, Name = "A" });
            studentRepo.Add(new Students { Id = 2, Name = "B" });
            studentRepo.Display();


            int x1 = 5, y1 = 10;
            Console.WriteLine($"Before Swap: x = {x1}, y = {y1}");

            Swaps(ref x1, ref y1);


            int[] numbers = { 1, 2, 3, 4, 5 };
            PrintArray(numbers);

            MyStruct structExample = new MyStruct { Number = 10 };
            Console.WriteLine($": {structExample.Number}");
            ModifyStruct(structExample);
            Console.WriteLine($": {structExample.Number}");

            Console.WriteLine();
            MyClass classExample = new MyClass { Number = 10 };
            Console.WriteLine($"{classExample.Number}");
            ModifyClass(classExample);
            Console.WriteLine($"{classExample.Number}");
        }

    }


    class Person
    {
        private string _name;
        private int _age;

        public Person(string _name, int _age)
        {
            Name = _name;
            Age = _age;

        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }


        public int Age
        {
            get { return _age; }
            set
            {
                if (value >= 0)
                    _age = value;
                else
                    throw new AccessViolationException("error");

            }
        }

        public void Print()
        {
            Console.WriteLine($"{Name}, {Age}");
        }
    }


    class BankAccout
    {
        private decimal _balance;

        public decimal GetBalance()
        {
            return _balance;
        }

        public void AddBalance(decimal price)
        {
            if (price > 0)
            {
                _balance += price;
            }
            else throw new AccessViolationException("error");
        }


        public void DecBalance(decimal price)
        {
            if (price > 0)
            {
                if (price <= _balance)
                {
                    _balance -= price;
                }
            }
            else throw new AccessViolationException("error");
        }
    }

    class Car
    {
        private int _speed;

        public int Speed
        {
            get { return _speed; }
        }
    }

    class Student
    {
        private List<int> grades = new List<int>();

        public void AddGrade(int grade)
        {
            if (grade > 0 && grade <= 100)
            {
                grades.Add(grade);
            }
            else throw new AccessViolationException("error");
        }

        public void Print()
        {
            if (grades.Count == 0)
            {

                throw new AccessViolationException("error");
            }
            else Console.WriteLine(grades);
        }
    }

    class Rectangle
    {
        private double _w;
        private double _h;

        public Rectangle(double w, double h)
        {
            _w = w;
            _h = h;
        }

        public double W
        {
            get => _w;
            set
            {
                if (value >= 0)
                    _w = value;
                throw new AccessViolationException("error");
            }
        }
        public double H
        {
            get => _h;
            set
            {
                if (value >= 0)
                    _h = value;
                throw new AccessViolationException("error");
            }
        }

        public double GetPerimeter()
        {
            return 2 * (_w + _h);
        }

    }


    class Employee
    {
        private decimal salary;
        public void SetSalary(decimal newSalary)
        {
            if (newSalary >= 0)
            {
                salary = newSalary;

            }
            else
            {
                Console.WriteLine("-------------------");
            }
        }

        public decimal GetSalary()
        {
            return salary;
        }
    }



    class Book
    {
        private string title;
        private readonly string author;

        public Book(string title, string author)
        {
            this.title = title;
            this.author = author;
        }

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public string Author
        {
            get { return author; }
        }
        public void DisplayBookInfo()
        {
            Console.WriteLine($"{title}, {author}");
        }
    }

    class User
    {
        private string password;
        public User(string password)
        {
            this.password = password;
        }
        public bool CheckPassword(string inputPassword)
        {
            return inputPassword == password;
        }
    }



    class EmployeeOne
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public EmployeeOne(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public void DisplayInfo()
        {
            Console.WriteLine($"Աշխատողի ID: {Id}, Անուն: {Name}");
        }
    }

    class Manager : EmployeeOne
    {
        public int TeamSize { get; set; }
        public Manager(int id, string name, int teamSize) : base(id, name)
        {
            TeamSize = teamSize;
        }
        public new void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Team Size: {TeamSize}");
        }
    }


    class GameCharacter
    {
        public int Health { get; set; }
        public GameCharacter(int health)
        {
            Health = health;
        }
        public virtual void DisplayInfo()
        {
            Console.WriteLine($"{Health} HP");
        }
    }

    class Warrior : GameCharacter
    {
        public int Strength { get; set; }
        public Warrior(int health, int strength) : base(health)
        {
            Strength = strength;
        }
        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Այս Warrior-ը ունի {Strength} ուժ");
        }
        public void Attack()
        {
            Console.WriteLine("Warrior-ը հարվածում է սուրը բարձրացնելով!");
        }
    }

    class Mage : GameCharacter
    {
        public int MagicPower { get; set; }
        public Mage(int health, int magicPower) : base(health)
        {
            MagicPower = magicPower;
        }
        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Այս Mage-ը ունի {MagicPower} մոգական ուժ");
        }
        public void CastSpell()
        {
            Console.WriteLine("Mage-ը արտաբերում է հզոր մոգություն!");
        }
    }


    class EmployeeP
    {
        public string Name { get; set; }
        public double Salary { get; set; }
        public EmployeeP(string name, double salary)
        {
            Name = name;
            Salary = salary;
        }
        public virtual double CalculateBonus()
        {
            return Salary * 0.05;
        }
    }

    class ManagerP : EmployeeP
    {
        public int TeamSize { get; set; }

        public ManagerP(string name, double salary, int teamSize) : base(name, salary)
        {
            TeamSize = teamSize;
        }

        public override double CalculateBonus()
        {

            return Salary * 0.1 + TeamSize * 50;
        }
    }

    class DeveloperP : EmployeeP
    {
        public int ProjectsCompleted { get; set; }
        public DeveloperP(string name, double salary, int projectsCompleted) : base(name, salary)
        {
            ProjectsCompleted = projectsCompleted;
        }
        public override double CalculateBonus()
        {
            return Salary * 0.07 + ProjectsCompleted * 100;
        }
    }

    abstract class Worker
    {
        public string Name { get; set; }
        public Worker(string name)
        {
            Name = name;
        }
        public abstract void DoWork();
    }

    class Teacher : Worker
    {
        public string Subject { get; set; }
        public Teacher(string name, string subject) : base(name)
        {
            Subject = subject;
        }
        public override void DoWork()
        {
            Console.WriteLine($"{Name} teaching '{Subject}' subject:");
        }
    }

    class Engineer : Worker
    {
        public string Field { get; set; }
        public Engineer(string name, string field) : base(name)
        {
            Field = field;
        }
        public override void DoWork()
        {
            Console.WriteLine($"{Name} working  {Field} field");
        }
    }




    interface IPlayable
    {
        void Play();
        void Stop();
    }

    class MusicPlayer : IPlayable
    {
        public string Song { get; set; }
        public MusicPlayer(string song)
        {
            Song = song;
        }
        public void Play()
        {
            Console.WriteLine($"--  song '{Song}'");
        }
        public void Stop()
        {
            Console.WriteLine($"song '{Song}' stoping ");
        }
    }

    class VideoPlayer : IPlayable
    {
        public string Video { get; set; }
        public VideoPlayer(string video)
        {
            Video = video;
        }
        public void Play()
        {
            Console.WriteLine($"see the vidio'{Video}'");
        }
        public void Stop()
        {
            Console.WriteLine($"vidio '{Video}' stoping");
        }
    }



    class Box<T>
    {
        private T item;

        public void Add(T newItem)
        {
            item = newItem;
        }

        public T Get()
        {
            return item;
        }
    }

    class Repository<T>
    {
        private List<T> items = new List<T>();
        public void Add(T item)
        {
            items.Add(item);
        }
        public void Display()
        {
            Console.WriteLine("Repository contents:");
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
        }
    }

    class Students
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return $"Student ID: {Id}, Name: {Name}";
        }
    }
    class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }

        public override string ToString()
        {
            return $"Product ID: {ProductId}, Name: {ProductName}, Price: {Price:C}";
        }
    }


    struct MyStruct
    {
        public int Number;
    }
    class MyClass
    {
        public int Number;
    }


}