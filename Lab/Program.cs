using System;

public class Lab1
{
    // ============================================================
    // ParseAge()
    // Parses the input string into an integer.
    // Throws:
    // - FormatException if the input is not a number
    // - ArgumentOutOfRangeException if age is outside 0-150
    // ============================================================
    static int ParseAge(string input)
    {
        Console.WriteLine("Step 1");

        // int.Parse() can throw FormatException
        int age = int.Parse(input);

        // Check whether the age is within the allowed range
        if (age < 0 || age > 150)
        {
            throw new ArgumentOutOfRangeException(
                nameof(input),
                "Age must be between 0 and 150"
            );
        }

        // This line runs only when the input is valid
        Console.WriteLine("Step 2 (only if valid)");

        return age;
    }

    public static void Main()
    {
        // ========================================================
        // TEST 1: Non-numeric input
        // "abc" causes FormatException.
        // Only the FormatException catch block should execute.
        // ========================================================

        Console.WriteLine("-- ParseAge(\"abc\") --");

        try
        {
            ParseAge("abc");
        }
        catch (FormatException ex)
        {
            Console.WriteLine($"Caught FormatException: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Caught general Exception: {ex.Message}");
        }

        Console.WriteLine();

        // ========================================================
        // TEST 2: Number is valid but outside allowed range
        // "200" causes ArgumentOutOfRangeException.
        //
        // Catch blocks must be ordered from MOST SPECIFIC
        // to MOST GENERAL.
        // ========================================================

        Console.WriteLine("-- ParseAge(\"200\") --");

        try
        {
            ParseAge("200");
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine(
                $"Caught ArgumentOutOfRangeException " +
                $"(most specific, ran first): {ex.Message}"
            );
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Caught ArgumentException: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Caught Exception: {ex.Message}");
        }

        Console.WriteLine();

        // ========================================================
        // WRONG ORDER EXAMPLE
        //
        // This will NOT compile:
        //
        // catch (Exception ex) { }
        // catch (ArgumentOutOfRangeException ex) { }
        //
        // Why?
        // ArgumentOutOfRangeException is already covered by
        // Exception, so the later catch block can never be reached.
        // ========================================================

        // ========================================================
        // TEST 3: Valid age
        // Both Step 1 and Step 2 should execute.
        // No exception is thrown.
        // ========================================================

        Console.WriteLine("-- ParseAge(\"30\") --");

        try
        {
            int result = ParseAge("30");
            Console.WriteLine($"Result: {result}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Caught: {ex.Message}");
        }
    }
}