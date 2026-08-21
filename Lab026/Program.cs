using System;
using System.Collections.Generic;

// ================================================================
// GENERIC SWAP METHOD
//
// Works with ANY type.
// ref allows the method to change the original variables.
// ================================================================
public class Lab6
{
    public static void Swap<T>(ref T a, ref T b)
    {
        T temporary = a;
        a = b;
        b = temporary;
    }


    // ============================================================
    // GENERIC Pair<TFirst, TSecond>
    //
    // Can store two different types.
    // Example:
    // Pair<int, string>
    // Pair<string, double>
    // ============================================================
    public class Pair<TFirst, TSecond>
    {
        public TFirst First { get; set; }
        public TSecond Second { get; set; }

        public Pair(TFirst first, TSecond second)
        {
            First = first;
            Second = second;
        }

        public override string ToString()
        {
            return $"({First}, {Second})";
        }
    }


    // ============================================================
    // MinMaxTracker<T>
    //
    // Constraint:
    // T must implement IComparable<T>.
    //
    // We maintain Min and Max while adding values.
    // Therefore each Add() is O(1).
    //
    // We do NOT scan the entire collection every time.
    // ============================================================
    public class MinMaxTracker<T>
        where T : IComparable<T>
    {
        public T Min { get; private set; }
        public T Max { get; private set; }

        private bool hasValue = false;

        public void Add(T value)
        {
            if (!hasValue)
            {
                Min = value;
                Max = value;
                hasValue = true;
                return;
            }

            if (value.CompareTo(Min) < 0)
            {
                Min = value;
            }

            if (value.CompareTo(Max) > 0)
            {
                Max = value;
            }
        }
    }


    // ============================================================
    // AllMatch<T>
    //
    // Returns true only if EVERY element satisfies predicate.
    // ============================================================
    public static bool AllMatch<T>(
        IEnumerable<T> items,
        Func<T, bool> predicate)
    {
        foreach (T item in items)
        {
            if (!predicate(item))
            {
                return false;
            }
        }

        return true;
    }


    // ============================================================
    // Product class
    //
    // Implements IComparable<Product> so Product objects can be
    // compared by price.
    // ============================================================
    public class Product : IComparable<Product>
    {
        public string Name { get; set; }
        public double Price { get; set; }

        public Product(string name, double price)
        {
            Name = name;
            Price = price;
        }

        public int CompareTo(Product other)
        {
            if (other == null)
            {
                return 1;
            }

            return Price.CompareTo(other.Price);
        }

        public override string ToString()
        {
            return $"{Name} (${Price:F2})";
        }
    }


    public static void Main()
    {
        Console.WriteLine("========================================");
        Console.WriteLine("LAB 6 - GENERICS");
        Console.WriteLine("========================================");


        // ========================================================
        // 1. Swap<int>
        // ========================================================

        int a = 10;
        int b = 20;

        Console.WriteLine("\n--- Swap<int> ---");
        Console.WriteLine($"Before: a={a}, b={b}");

        Swap(ref a, ref b);

        Console.WriteLine($"After: a={a}, b={b}");


        // ========================================================
        // 2. Swap<string>
        // ========================================================

        string first = "Hello";
        string second = "World";

        Console.WriteLine("\n--- Swap<string> ---");
        Console.WriteLine(
            $"Before: {first}, {second}"
        );

        Swap(ref first, ref second);

        Console.WriteLine(
            $"After: {first}, {second}"
        );


        // ========================================================
        // 3. Pair<int,string>
        // ========================================================

        Console.WriteLine("\n--- Pair<int,string> ---");

        Pair<int, string> pair1 =
            new Pair<int, string>(
                101,
                "Alice"
            );

        Console.WriteLine(pair1);


        // ========================================================
        // 4. Pair<string,double>
        // ========================================================

        Console.WriteLine("\n--- Pair<string,double> ---");

        Pair<string, double> pair2 =
            new Pair<string, double>(
                "Price",
                99.99
            );

        Console.WriteLine(pair2);


        // ========================================================
        // 5. MinMaxTracker<int>
        // ========================================================

        Console.WriteLine("\n--- MinMaxTracker<int> ---");

        MinMaxTracker<int> intTracker =
            new MinMaxTracker<int>();

        intTracker.Add(50);
        intTracker.Add(10);
        intTracker.Add(90);
        intTracker.Add(30);

        Console.WriteLine(
            $"Min: {intTracker.Min}"
        );

        Console.WriteLine(
            $"Max: {intTracker.Max}"
        );


        // ========================================================
        // 6. MinMaxTracker<Product>
        //
        // Product implements IComparable<Product> by price.
        // ========================================================

        Console.WriteLine(
            "\n--- MinMaxTracker<Product> ---"
        );

        MinMaxTracker<Product> productTracker =
            new MinMaxTracker<Product>();

        Product laptop =
            new Product("Laptop", 70000);

        Product phone =
            new Product("Phone", 30000);

        Product tablet =
            new Product("Tablet", 40000);

        productTracker.Add(laptop);
        productTracker.Add(phone);
        productTracker.Add(tablet);

        Console.WriteLine(
            $"Min: {productTracker.Min}"
        );

        Console.WriteLine(
            $"Max: {productTracker.Max}"
        );


        // ========================================================
        // 7. AllMatch<int>
        // ========================================================

        Console.WriteLine("\n--- AllMatch<int> ---");

        List<int> numbers =
            new List<int> { 2, 4, 6, 8 };

        bool allEven =
            AllMatch(
                numbers,
                number => number % 2 == 0
            );

        Console.WriteLine(
            $"All numbers even: {allEven}"
        );


        // ========================================================
        // 8. AllMatch<string>
        // ========================================================

        Console.WriteLine("\n--- AllMatch<string> ---");

        List<string> names =
            new List<string>
            {
                "Alice",
                "Bob",
                "Charlie"
            };

        bool allLongEnough =
            AllMatch(
                names,
                name => name.Length >= 3
            );

        Console.WriteLine(
            $"All names have at least 3 characters: " +
            $"{allLongEnough}"
        );
    }
}