using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace box
{
    //9
    struct Point
    {
        public int X;
        public int Y;
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //4
            object boxedNumber = 10;
            try
            {
                int unboxedNumber = (int)boxedNumber;
                Console.WriteLine($"{unboxedNumber}");
            }
            catch (InvalidCastException)
            {
                Console.WriteLine("Unboxing failed due to invalid cast.");
            }
            object boxedString = "Hello, world!";
            try
            {
                int unboxedString = (int)boxedString;
            }
            catch (InvalidCastException)
            {
                Console.WriteLine("Unboxing failed: object is not an int.");
            }

            //9
            Point p = new Point(10, 20);
            object boxedPoint = p;
            Point unboxedPoint = (Point)boxedPoint;
            Console.WriteLine($"X={unboxedPoint.X}, Y = {unboxedPoint.Y}");

            //10
            List<int> numbers = new List<int>();
            numbers.Add(10);
            numbers.Add(20);
            numbers.Add(30);
            
            foreach (int number in numbers)
            {
                Console.WriteLine($"Value: {number}");
            }
        }
    }
}
