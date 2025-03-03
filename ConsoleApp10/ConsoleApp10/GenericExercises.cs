using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp8
{
    class Program
    {
        static void Main(string[] args)
        {
            Pair<int, string> pair = new Pair<int, string>(1, "hello");
            var swappedPair = pair.Swap();
            Console.WriteLine($" Swap: First = {swappedPair.First}, Second = {swappedPair.Second}");


            Console.WriteLine(EqualityChecker.AreEqual(1, 1));
            Console.WriteLine(EqualityChecker.AreEqual("abc", "def"));


            SafeDictionary<string, int> dict = new SafeDictionary<string, int>();
            dict.AddOrUpdate("one", 1);
            Console.WriteLine(dict.GetOrDefault("one"));
            Console.WriteLine(dict.GetOrDefault("two"));


            int a = 1, b = 2;
            Utils.Swap(ref a, ref b);
            Console.WriteLine($"a = {a}, b = {b}"); 

            string x = "hi", y = "bye";
            Utils.Swap(ref x, ref y);
            Console.WriteLine($"x = {x}, y = {y}");
        }


        class Pair<T1, T2>
        {
            public T1 First { get; private set; }
            public T2 Second { get; private set; }

            public Pair(T1 first, T2 second)
            {
                First = first;
                Second = second;
            }

            public Pair<T1, T2> Swap()
            {
                return new Pair<T1, T2>(First, Second);
            }
        }


        static class EqualityChecker
        {
            public static bool AreEqual<T>(T first, T second) where T : IEquatable<T>
            {
                return first.Equals(second); ;
            }
        }

        class SafeDictionary<TKey, TValue>
        {
            public Dictionary<TKey, TValue> _dictionary = new Dictionary<TKey, TValue>();


            public void AddOrUpdate(TKey key, TValue value)
            {
                _dictionary[key] = value;
            }

            public TValue GetOrDefault(TKey key)
            {
                return _dictionary.TryGetValue(key, out TValue value) ? value : default(TValue);
            }
        }


        public static class Utils
        {
            public static void Swap<T>(ref T first, ref T second)
            {
                T temp = first;
                first = second;
                second = temp;
            }
        }
    }
}