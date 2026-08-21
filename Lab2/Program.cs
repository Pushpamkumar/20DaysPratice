using System;

public class Lab2
{
    // ============================================================
    // Process()
    //
    // Demonstrates that finally always executes:
    // - When execution finishes normally
    // - When an exception occurs
    // - When the method returns early
    // ============================================================
    static void Process(int mode)
    {
        Console.WriteLine("Opening");

        try
        {
            // Mode 1 deliberately throws an exception
            if (mode == 1)
            {
                throw new InvalidOperationException(
                    "Simulated failure"
                );
            }

            Console.WriteLine("Working");

            // Mode 2 returns early
            // Even though return happens, finally still executes.
            if (mode == 2)
            {
                return;
            }

            Console.WriteLine("Finishing normally");
        }
        finally
        {
            // Finally ALWAYS executes before leaving the method
            Console.WriteLine("Closing");
        }
    }


    // ============================================================
    // FakeFileHandle
    //
    // Simulates a resource such as a file/database connection.
    // IDisposable allows it to be automatically cleaned up by using.
    // ============================================================
    class FakeFileHandle : IDisposable
    {
        public FakeFileHandle()
        {
            Console.WriteLine("Handle opened");
        }

        public void Dispose()
        {
            Console.WriteLine("Handle closed");
        }
    }


    // ============================================================
    // UseFakeFile()
    //
    // The using statement automatically calls Dispose()
    // even when an exception occurs.
    // ============================================================
    static void UseFakeFile()
    {
        using (FakeFileHandle handle = new FakeFileHandle())
        {
            Console.WriteLine("Working with handle");

            // Simulate an error while using the resource
            throw new InvalidOperationException(
                "Simulated resource failure"
            );
        }
    }


    public static void Main()
    {
        // ========================================================
        // TEST 1: Normal execution
        // ========================================================

        Console.WriteLine("-- Process(0) --");
        Process(0);

        Console.WriteLine();

        // ========================================================
        // TEST 2: Exception occurs
        //
        // finally executes BEFORE the outer catch.
        // ========================================================

        Console.WriteLine("-- Process(1) --");

        try
        {
            Process(1);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Caught: {ex.Message}");
        }

        Console.WriteLine();

        // ========================================================
        // TEST 3: Early return
        //
        // finally still executes before returning.
        // ========================================================

        Console.WriteLine("-- Process(2) --");
        Process(2);

        Console.WriteLine();

        // ========================================================
        // TEST 4: using + IDisposable
        //
        // Dispose() executes automatically when leaving the
        // using block, even if an exception is thrown.
        // ========================================================

        Console.WriteLine("-- using / IDisposable --");

        try
        {
            UseFakeFile();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Caught: {ex.Message}");
        }
    }
}