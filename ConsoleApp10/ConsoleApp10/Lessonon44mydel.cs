using System;

class Sorter
{
    public static void SortArray<T>(T[] array, Func<T, T, int> comparer)
    {
        for (int i = 0; i < array.Length - 1; i++)
        {
            for (int j = i + 1; j < array.Length; j++)
            {
                if (comparer(array[i], array[j]) > 0)
                {
                   
                    T temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                }
            }
        }
    }
}

class Program
{
    static void Main()
    {
        int[] numbers = { 5, 2, 9, 1, 5, 6 };

        Func<int, int, int> ascending = (x, y) => x.CompareTo(y);
        Sorter.SortArray(numbers, ascending);
        Console.WriteLine("Ascending: " + string.Join(", ", numbers));

        Func<int, int, int> descending = (x, y) => y.CompareTo(x);
        Sorter.SortArray(numbers, descending);
        Console.WriteLine("Descending: " + string.Join(", ", numbers));
    }
}
