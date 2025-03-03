using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp9
{
    class Program
    {
        static void Main(string[] args)
        {

            //1
            IAnimal myDog = new Dog();
            myDog.MakeSound();
            myDog.Move();
            IAnimal myBird = new Bird();
            myBird.MakeSound();
            myBird.Move();


            //2

            IContainer<int> intList = new MyList<int>();
            intList.Add(10);
            intList.Add(20);
            intList.Add(30);

            intList.GetItem(1);

            //3

            //4

            //5


            //6
            IWorker[] workers = new IWorker[]
       {
            new HumanWorker(),
            new RobotWorker()
       };

            foreach (IWorker worker in workers)
            {
                worker.Work();
                worker.TakeBreak();
            }

            //7

            IProcessor<string> stringProcessor = new StringProcessor();
            string inputString = "hello";
            string processedString = stringProcessor.Process(inputString);
            Console.WriteLine($"Processed String: {processedString}");


            //8-
            List<IFilter> filters = new List<IFilter>
        {
            new UppercaseFilter(),
            new ReverseFilter()
        };

            string inputText = "test";

            foreach (IFilter filter in filters)
            {
                string result = filter.ApplyFilter(inputText);
                Console.WriteLine($"Filtered Text: {result}");
            }

            //9
            IManager<double> itemManager = new ItemManager<double>();
            itemManager.AddItem(1.5);
            itemManager.AddItem(2.3);
            itemManager.RemoveItem(2.3);


            //10

            ICharacter[] characters = new ICharacter[]
      {
            new Warrior(),
            new Mage()
      };

         
            foreach (ICharacter character in characters)
            {
                character.Attack();
                character.Defend();
            }
        }



        //1-
        interface IAnimal
        {
            void MakeSound();
            void Move();
        }

        class Dog : IAnimal
        {
            public void MakeSound()
            {
                Console.WriteLine("Dog barks");
            }

            public void Move()
            {
                Console.WriteLine("Dog runs");
            }
        }

        class Bird : IAnimal
        {
            public void MakeSound()
            {
                Console.WriteLine("Bird chirps");
            }

            public void Move()
            {
                Console.WriteLine("Bird flies");
            }
        }

        //2-

        interface IContainer<T>
        {
            void Add(T item);
            T GetItem(int index);
        }

        class MyList<T> : IContainer<T>
        {
            public List<T> items = new List<T>();

            public void Add(T item)
            {
                items.Add(item);
            }

            public T GetItem(int index)
            {
                if (index < 0 || index >= items.Count)
                {
                    throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range");
                }
                return items[index];
            }
        }


        //4
        interface IShape
        {
            double CalculateArea();
            void Display();
        }

        class Circle : IShape
        {
            public double Radius;

            public Circle(double radius)
            {
                Radius = radius;
            }

            public double CalculateArea()
            {
                return Math.PI * Radius * Radius;
            }

            public void Display()
            {
                Console.WriteLine("Iam circle");
            }

        }
        class Rectangle : IShape
        {
            public double Width { get; set; }
            public double Height { get; set; }

            public Rectangle(double width, double height)
            {
                Width = width;
                Height = height;
            }

            public double CalculateArea()
            {
                return Width * Height; 
            }

            public void Display()
            {
                Console.WriteLine($"Rectangle with width {Width} and height {Height}");
            }
        }

        //5

        interface IComparer<T>
        {
            int Compare(T item1, T item2);
        }

        public class NumberComparer : IComparer<int>
        {
            public int Compare(int item1, int item2)
            {
                if (item1 == item2)
                    return 0;
                else if (item1 > item2)
                    return 1;
                else
                    return -1;
            }
        }

        public class StringComparer : IComparer<string>
        {
            public int Compare(string item1, string item2)
            {
                if (item1.Length == item2.Length)
                    return 0;
                else if (item1.Length > item2.Length)
                    return 1;
                else
                    return -1;
            }
        }

        //6--

        public interface IWorker
        {
            void Work();
            void TakeBreak();
        }

        public class HumanWorker : IWorker
        {
            public void Work()
            {
                Console.WriteLine("Human is working hard");
            }

            public void TakeBreak()
            {
                Console.WriteLine("Human is resting");
            }
        }
        public class RobotWorker : IWorker
        {
            public void Work()
            {
                Console.WriteLine("Robot is processing data");
            }

            public void TakeBreak()
            {
                Console.WriteLine("Robot does not need a break");
            }
        }


        //7
        interface IProcessor<T>
        {
            T Process(T data);
        }

        public class NumberProcessor : IProcessor<int>
        {
            public int  Process(int data)
            {
                return data * 2;

            }
        }

        public class StringProcessor : IProcessor<string>
        {
            public string Process(string data)
            {
                return data.ToUpper();

            }
        }

        //8-
        interface IFilter
        {
          string ApplyFilter(string text);
        }

        public class UppercaseFilter : IFilter
        {
            public string ApplyFilter(string text)
            {
               return text.ToUpper();
            }
        }

        public class ReverseFilter : IFilter
        {
            public string ApplyFilter(string text)
            {
                char[] charArray = text.ToCharArray();
                Array.Reverse(charArray);
                return new string(charArray);
            }
        }


        //9
        interface IManager<T>
        {
            void AddItem(T item);
            void RemoveItem(T item);
            int Count();
        }
        public class ItemManager<T> : IManager<T>
        {
            private List<T> items = new List<T>(); 
            public void AddItem(T item)
            {
                items.Add(item);
            }

            public int Count()
            {
                return items.Count;
            }

            public void RemoveItem(T item)
            {
                items.Remove(item);
            }
        }


        //10
        public interface ICharacter
        {
            void Attack();
            void Defend();
        }

        public class Warrior : ICharacter
        {
            public void Attack()
            {
                Console.WriteLine("Warrior swings sword");
            }

            public void Defend()
            {
                Console.WriteLine("Warrior raises shield");
            }
        }

        public class Mage : ICharacter
        {
            public void Attack()
            {
                Console.WriteLine("Mage casts fireball");
            }

            public void Defend()
            {
                Console.WriteLine("Mage creates magic barrier");
            }
        }
    }
}
