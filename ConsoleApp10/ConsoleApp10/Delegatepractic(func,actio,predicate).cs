using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatePractic_Func_action_predicate_
{
    class Program
    {
        static int ApplyFunction(Func<int, int> func, int numm)
        {
            return func(numm); 
        }

        static void ExecuteAction(Action<string> action, string message)
        {
            action(message); 
        }


        static List<int> FilterList(Predicate<int> predicate, List<int> numbers)
        {
            return numbers.FindAll(predicate);
        }


        static Func<int, Func<int, int>> Add = x => y => x + y;


        static void ActionTimes(Action action)
        {
            for (int i = 0; i < 5; i++)
            {
                action(); 
            }
        }
        static void Main(string[] args)
        {
            //Func Delegate

            Func<int, int, int> addNumbers = (a, b) => a + b;
            int result = addNumbers(5, 7);
            Console.WriteLine(result);

            Func<string, int> getLength = str => str.Length;
            string text = "elen elen";
            int length = getLength(text);
            Console.WriteLine($"lenght:{length}");

            /*Func<double, double> square = num => num * num;
            double number = 5.5;
            double result1 = square(number);
            Console.WriteLine($"{result1}");*/

            /*Func<int, bool> isEven = num => num % 2 == 0;
            int number1 = 10;
            bool result3 = isEven(number1);
            Console.WriteLine($"{number1} / {result3}");*/

            Func<string, string, bool> areEqual = (str1, str2) => str1 == str2;
            string text1 = "Hello";
            string text2 = "Hello";
            bool result4 = areEqual(text1, text2);
            Console.WriteLine(result4);


            //Action
            Action<string> printMessage = message => Console.WriteLine(message);
            printMessage("Elen,elen");

            Action<int, int> print = (a, b) => Console.WriteLine( a * b);
            print(5, 7);

            Action print1= () => Console.WriteLine("elen elen");
            print1();

            Action<string, int> print2 = (message, count) =>
            {
                for (int i = 0; i < count; i++)
                {
                    Console.WriteLine(message);
                }
            };

            print2("c#", 3);

            Action<List<int>> print4 = list =>
            {
                foreach (var item in list)
                {
                    Console.WriteLine(item);
                }
            };
            
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };
            print4(numbers);

            //Predicate
            Predicate<int> positive = isnum => isnum > 0;
            int num = 24;
            bool result5 = positive(num);

            Console.WriteLine(result5);


            Predicate<string> sA = str => str.Contains('a');
            string texta = "abcd";
            bool result6 = sA(texta);

            Console.WriteLine($"row : {text1} {result6}");


            //Խառը Խնդիրներ

            Func<int, int> square = x => x * x;
            int result7 = ApplyFunction(square, 5);
            Console.WriteLine($"5 pow ՝ {result7}");

            Action<string> print7= message => Console.WriteLine(message);
            ExecuteAction(print7, "C#");


            /* List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
             Predicate<int> isOdd = num => num % 2 != 0;
             List<int> oddNumbers = FilterList(isOdd, numbers);

             foreach (var number in oddNumbers)
             {
                 Console.WriteLine(number); 
             }*/

            var addnum = Add(5);
            int resultnum = addnum(10);
            Console.WriteLine($"5 + 10 = {result}");


            Action greet = () => Console.WriteLine("C#-");
            ActionTimes(greet);
        }
    }
}
