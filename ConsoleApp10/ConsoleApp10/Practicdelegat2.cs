using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace DelegatePractic2
{
   /*  public delegate int MathAdd(int a, int b);
    public delegate bool Mathev(int c);
    public delegate int StringLenght(string text);
    public delegate int ArryMax(int[] maxNumber);
    public delegate string StringCon(string str1, string str2);
    public delegate double MathPow(int c);
    public delegate double AverageDelegate(int[] numbersAvg);
    public delegate string Reverse(string text);
    public delegate string CapitalizeDelegate(string text);*/
    //14-17
    public delegate TOutput GenericDelegate<TInput, TOutput>(TInput input);

    class Program
    {

        static void Main(string[] args)
        {
            /*MathAdd add = (a, b) => a + b;
            int result = add(5, 3);
            Console.WriteLine(result);

            Mathev evn = c => c % 2 == 0;
            bool result1 = evn(5);
            Console.WriteLine(result1);

            StringLenght textMax =text=>text.Length;
            string result2 = "my name is Elen";
            int length = textMax(result2);
            Console.WriteLine(result2);
            Console.WriteLine(length);

            ArryMax arrayMax = maxNumber=> maxNumber.Max();
            ArryMax arrayMin = maxNumber => maxNumber.Min();
            int[] numbers = { 1, 5, 3, 9, 7 };
            int max = arrayMax(numbers);
            //10---
            int min = arrayMin(numbers);
            Console.WriteLine("Max value: " + max);
            Console.WriteLine("Min value: " + min);

            StringCon stringConcat = (str1, str2)=> str1 + " " + str2;
            Console.WriteLine(stringConcat("h", "k"));


            MathPow pow = c => Math.Pow(c,2);
            double number = pow(5);
            Console.WriteLine(number);


            AverageDelegate average = numbersAvg => numbersAvg.Average();

            int[] numbersArray = { 1, 2, 3, 4, 5 };
            double resultAVG = average(numbersArray);
            Console.WriteLine("Average: " + resultAVG);

            Reverse reverse = text => new string(text.Reverse().ToArray());
            string reversedText = reverse("mydel");
            Console.WriteLine(reversedText);

            CapitalizeDelegate capitalizeFirst = text =>
              string.IsNullOrEmpty(text) ? text : char.ToUpper(text[0]) + text.Substring(1);
            string input = "hello, world!";
            string result3 = capitalizeFirst(input);
            Console.WriteLine("Capitalized Text: " + result3);*/


            //14-17
            // 14. Տեքստի երկարությունը վերադարձնող delegate
            GenericDelegate<string, int> getTextLength = text => text.Length;
            string text1 = "My name is Elen";
            Console.WriteLine($"Length of '{text1}': {getTextLength(text1)}");

            // 15. Թվի հակառակը վերադարձնող delegate
            GenericDelegate<int, int> getNegative = num => -num;
            int number = 25;
            Console.WriteLine($"Negative of {number}: {getNegative(number)}");

            // 16. Զանգվածի մեդիանը վերադարձնող delegate
            GenericDelegate<int[], double> getMedian = numbers =>
            {
                var sortedNumbers = numbers.OrderBy(n => n).ToArray();
                int count = sortedNumbers.Length;
                return count % 2 == 0
                    ? (sortedNumbers[count / 2 - 1] + sortedNumbers[count / 2]) / 2.0
                    : sortedNumbers[count / 2];
            };
            int[] numbersArray = { 3, 1, 4, 5, 2 };
            Console.WriteLine($"Median: {getMedian(numbersArray)}");

            // 17. 
            GenericDelegate<string, char> getLastChar = text => text.Length > 0 ? text[text.Length - 1] : '\0';
            Console.WriteLine($"Last character of '{text1}': {getLastChar(text1)}");


            Console.ReadKey();
        }       
    }
}
