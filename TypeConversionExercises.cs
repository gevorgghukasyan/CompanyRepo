using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


interface IExample
{
    void Display();
}
class Example : IExample
{
    public void Display() => Console.WriteLine("Hello from Example!");
}

namespace TypeConversionExercises
{
    class Program
    {
        static void Main(string[] args)
        {
            //1
            Console.Write("Enter 1 number: ");
            string numone = Console.ReadLine();
            Console.Write("Enter 2 number: ");
            string numtwo = Console.ReadLine();

            int num1 = Convert.ToInt32(numone);
            int num2 = Convert.ToInt32(numtwo);
            int sum = num1 + num2;
            Console.WriteLine("Sum: " + sum);


            //2
            Console.Write("Enter ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out _))
            {
                int number = int.Parse(input);
                Console.WriteLine(number);
            }
            else
            {
                Console.WriteLine("Error occurred.");
            }
            //3
            // value = 42;
            //double result = value;
            //Console.WriteLine(result);


            //4
            double value = 5.8;
            int result = (int)value;
            Console.WriteLine(result);

            //5

            object obj = new Example();
            IExample example = obj as IExample;

            if (example != null)
                example.Display();
            else
                Console.WriteLine("Conversion failed.");


            object obj1 = "Hello"; 

            try
            {
                int number = (int)obj1; 
            }
            catch (InvalidCastException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }   
    }
}
