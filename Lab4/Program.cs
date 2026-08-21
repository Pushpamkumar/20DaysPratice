using System;

public class Lab4
{
    // ============================================================
    // ReadRawConfigValue()
    //
    // Simulates reading a configuration value from a low-level
    // source such as a file or database.
    //
    // For "timeout", deliberately throws FormatException.
    // ============================================================
    static string ReadRawConfigValue(string key)
    {
        if (key == "timeout")
        {
            throw new FormatException(
                "Value 'abc' is not a valid integer"
            );
        }

        return "dummy-value";
    }


    // ============================================================
    // GetTimeoutSetting()
    //
    // Converts the low-level FormatException into a more
    // meaningful business-level InvalidOperationException.
    //
    // The original exception is stored as InnerException.
    // ============================================================
    static int GetTimeoutSetting()
    {
        try
        {
            string raw = ReadRawConfigValue("timeout");

            return int.Parse(raw);
        }
        catch (FormatException ex)
        {
            // Wrap the original exception.
            // ex becomes the InnerException.
            throw new InvalidOperationException(
                "Application configuration is invalid",
                ex
            );
        }
    }


    // ============================================================
    // PrintExceptionChain()
    //
    // Walks through the complete InnerException chain.
    //
    // This is better than checking only ex.InnerException because
    // there can be multiple levels of nested exceptions.
    // ============================================================
    static void PrintExceptionChain(Exception ex)
    {
        int depth = 0;

        while (ex != null)
        {
            // Create indentation based on exception depth
            string indentation = new string(' ', depth * 2);

            Console.WriteLine(
                $"{indentation}{ex.GetType().Name}: {ex.Message}"
            );

            // Move to the next inner exception
            ex = ex.InnerException;

            depth++;
        }
    }


    public static void Main()
    {
        try
        {
            GetTimeoutSetting();
        }
        catch (Exception ex)
        {
            // ====================================================
            // Print the outer exception
            // ====================================================

            Console.WriteLine(
                $"Top-level: {ex.Message}"
            );

            // ====================================================
            // Print the original exception message
            // ====================================================

            if (ex.InnerException != null)
            {
                Console.WriteLine(
                    $"Caused by: {ex.InnerException.Message}"
                );

                Console.WriteLine(
                    $"Inner exception type: " +
                    $"{ex.InnerException.GetType().Name}"
                );
            }
            else
            {
                Console.WriteLine("No inner exception.");
            }

            // ====================================================
            // Print the complete exception chain
            // ====================================================

            Console.WriteLine();
            Console.WriteLine("-- PrintExceptionChain --");

            PrintExceptionChain(ex);
        }
    }
}