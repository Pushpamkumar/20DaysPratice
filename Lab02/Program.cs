using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

public class Lab1
{
    public static void Main()
    {
        Console.WriteLine("========================================");
        Console.WriteLine("LAB 1 - NON-GENERIC VS GENERIC");
        Console.WriteLine("========================================");

        // ============================================================
        // PART 1: ArrayList
        // ============================================================
        // ArrayList is a non-generic collection.
        // It can store objects of DIFFERENT types.
        //
        // This flexibility can become a problem because the compiler
        // cannot prevent us from adding incompatible data.
        // ============================================================

        ArrayList values = new ArrayList();

        values.Add(10);
        values.Add("twenty");
        values.Add(30.5);
        values.Add(true);

        double sum = 0;

        Console.WriteLine("\nArrayList contents:");

        foreach (object value in values)
        {
            Console.WriteLine($"{value} ({value.GetType().Name})");

            // Pattern matching checks whether the object is numeric.
            if (value is int intValue)
            {
                sum += intValue;
            }
            else if (value is double doubleValue)
            {
                sum += doubleValue;
            }
        }

        Console.WriteLine($"\nNumeric sum: {sum}");


        // ============================================================
        // PART 2: List<int>
        // ============================================================
        // List<int> is a generic collection.
        //
        // It can contain ONLY integers.
        // The compiler prevents us from adding a string such as
        // "twenty".
        // ============================================================

        List<int> numbers = new List<int>();

        numbers.Add(10);
        numbers.Add(20);
        numbers.Add(30);

        int genericSum = 0;

        foreach (int number in numbers)
        {
            genericSum += number;
        }

        Console.WriteLine("\nList<int> contents:");

        foreach (int number in numbers)
        {
            Console.WriteLine(number);
        }

        Console.WriteLine($"Generic list sum: {genericSum}");

        // This would cause a COMPILE-TIME ERROR:
        //
        // numbers.Add("twenty");
        //
        // Why?
        // Because List<int> accepts only int values.
        // The compiler catches the mistake before the program runs.


        // ============================================================
        // PART 3: Performance Benchmark
        // ============================================================
        // Stopwatch measures how long it takes to insert
        // 2,000,000 integers into each collection.
        //
        // ArrayList stores values as object, which can cause boxing
        // for value types such as int.
        //
        // List<int> stores integers directly and avoids this
        // unnecessary boxing/unboxing.
        // ============================================================

        const int count = 2_000_000;

        Stopwatch stopwatch = new Stopwatch();

        // ---------------- ArrayList benchmark ----------------

        ArrayList arrayList = new ArrayList();

        stopwatch.Start();

        for (int i = 0; i < count; i++)
        {
            arrayList.Add(i);
        }

        stopwatch.Stop();

        long arrayListTime = stopwatch.ElapsedMilliseconds;

        // ---------------- List<int> benchmark ----------------

        List<int> intList = new List<int>();

        stopwatch.Restart();

        for (int i = 0; i < count; i++)
        {
            intList.Add(i);
        }

        stopwatch.Stop();

        long listTime = stopwatch.ElapsedMilliseconds;

        Console.WriteLine("\n===== BENCHMARK =====");
        Console.WriteLine(
            $"ArrayList: {arrayListTime} ms"
        );

        Console.WriteLine(
            $"List<int>: {listTime} ms"
        );

        Console.WriteLine("\nSUMMARY:");
        Console.WriteLine(
            "Generic collections provide compile-time type safety."
        );
        Console.WriteLine(
            "List<int> is generally preferable when all elements are integers."
        );
    }
}