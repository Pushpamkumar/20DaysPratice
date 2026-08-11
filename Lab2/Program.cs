using System;
using System.Diagnostics;
using System.Text;
using System.Collections.Generic;

class Lab2
{
    static string BuildWithString(int count)
    {
        string result = "";

        for (int i = 0; i < count; i++)
        {
            result += i.ToString();
        }

        return result;
    }

    static string BuildWithStringBuilder(int count)
    {
        StringBuilder builder = new StringBuilder(count * 6);

        for (int i = 0; i < count; i++)
        {
            builder.Append(i);
        }

        return builder.ToString();
    }

    static string BuildWithList(int count)
    {
        List<string> values = new List<string>(count);

        for (int i = 0; i < count; i++)
        {
            values.Add(i.ToString());
        }

        return string.Join("", values);
    }

    static void RunBenchmark(int count)
    {
        Console.WriteLine();
        Console.WriteLine($"--- Benchmark for {count:N0} items ---");

        // String
        Stopwatch stopwatch = Stopwatch.StartNew();

        string result1 = BuildWithString(count);

        stopwatch.Stop();

        long stringTime = stopwatch.ElapsedMilliseconds;

        Console.WriteLine(
            $"String concatenation ({count:N0} items): {stringTime} ms"
        );


        // StringBuilder
        stopwatch.Restart();

        string result2 = BuildWithStringBuilder(count);

        stopwatch.Stop();

        long stringBuilderTime = stopwatch.ElapsedMilliseconds;

        Console.WriteLine(
            $"StringBuilder ({count:N0} items): {stringBuilderTime} ms"
        );


        // List + Join
        stopwatch.Restart();

        string result3 = BuildWithList(count);

        stopwatch.Stop();

        long listTime = stopwatch.ElapsedMilliseconds;

        Console.WriteLine(
            $"List + Join ({count:N0} items): {listTime} ms"
        );


        // Ratio
        if (stringBuilderTime > 0)
        {
            double ratio =
                (double)stringTime / stringBuilderTime;

            Console.WriteLine(
                $"String / StringBuilder ratio: {ratio:F2}x"
            );
        }
        else
        {
            Console.WriteLine(
                "StringBuilder time was less than 1 ms."
            );
        }
    }


    static void Main()
    {
        // Warm-up
        BuildWithString(1000);
        BuildWithStringBuilder(1000);
        BuildWithList(1000);

        // 50,000
        RunBenchmark(50000);

        // 200,000
        RunBenchmark(200000);
    }
}