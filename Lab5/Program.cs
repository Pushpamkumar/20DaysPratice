using System;

// ================================================================
// BASE CUSTOM EXCEPTION
// ================================================================
// This exception represents general order-validation failures.
// It also stores the name of the field that caused the problem.
// ================================================================
public class OrderValidationException : Exception
{
    public string FieldName { get; }

    // Default constructor
    public OrderValidationException()
        : base()
    {
    }

    // Constructor with message
    public OrderValidationException(string message)
        : base(message)
    {
    }

    // Constructor with message + inner exception
    public OrderValidationException(
        string message,
        Exception inner)
        : base(message, inner)
    {
    }

    // Constructor with message + field name
    public OrderValidationException(
        string message,
        string fieldName)
        : base(message)
    {
        FieldName = fieldName;
    }
}


// ================================================================
// MISSING FIELD EXCEPTION
// ================================================================
// More specific exception for missing required fields.
// ================================================================
public class MissingFieldException : OrderValidationException
{
    public MissingFieldException(string fieldName)
        : base(
            $"Required field '{fieldName}' is missing.",
            fieldName
        )
    {
    }
}


// ================================================================
// INVALID QUANTITY EXCEPTION
// ================================================================
// More specific exception for invalid quantities.
// ================================================================
public class InvalidQuantityException : OrderValidationException
{
    public InvalidQuantityException(int quantity)
        : base(
            $"Quantity must be greater than zero. Received: {quantity}",
            "quantity"
        )
    {
    }
}


// ================================================================
// LAB 5
// ================================================================
public class Lab5
{
    // ============================================================
    // ValidateOrder()
    //
    // Validates customer name, quantity and unit price.
    //
    // Validation rules:
    // 1. Customer name cannot be empty.
    // 2. Quantity must be greater than zero.
    // 3. Unit price cannot be negative.
    // 4. If everything is valid, return quantity * unitPrice.
    // ============================================================
    static decimal ValidateOrder(
        string customerName,
        int quantity,
        decimal unitPrice)
    {
        // Check customer name
        if (string.IsNullOrWhiteSpace(customerName))
        {
            throw new MissingFieldException("customerName");
        }

        // Check quantity
        if (quantity <= 0)
        {
            throw new InvalidQuantityException(quantity);
        }

        // Check price
        if (unitPrice < 0)
        {
            throw new OrderValidationException(
                "Unit price cannot be negative",
                "unitPrice"
            );
        }

        // Calculate and return total
        return quantity * unitPrice;
    }


    // ============================================================
    // SaveOrder()
    //
    // Simulates a low-level database failure.
    // ============================================================
    static void SaveOrder(
        string customerName,
        int quantity,
        decimal unitPrice)
    {
        throw new InvalidOperationException(
            "Database unavailable"
        );
    }


    // ============================================================
    // ProcessOrder()
    //
    // Performs validation and then attempts to save the order.
    //
    // Catch blocks are ordered from MOST SPECIFIC to GENERAL:
    //
    // 1. MissingFieldException
    // 2. InvalidQuantityException
    // 3. OrderValidationException
    //
    // Finally always prints the completion message.
    // ============================================================
    static void ProcessOrder(
        string customerName,
        int quantity,
        decimal unitPrice)
    {
        try
        {
            // First validate the order
            decimal total = ValidateOrder(
                customerName,
                quantity,
                unitPrice
            );

            // If validation succeeds, try saving the order
            try
            {
                SaveOrder(
                    customerName,
                    quantity,
                    unitPrice
                );

                Console.WriteLine($"Order total: ${total:F2}");
            }
            catch (InvalidOperationException ex)
            {
                // The database exception is a low-level error.
                //
                // Wrap it in our business-level exception.
                //
                // We use "throw new..." because we are creating
                // a BRAND NEW exception object.
                //
                // "throw;" alone only works inside a catch block
                // to rethrow the SAME currently caught exception.

                throw new OrderValidationException(
                    "Could not save order",
                    ex
                );
            }
        }

        // Most specific exception first
        catch (MissingFieldException ex)
        {
            Console.WriteLine(
                $"Missing field: {ex.FieldName}"
            );
        }

        // Second most specific exception
        catch (InvalidQuantityException ex)
        {
            Console.WriteLine(
                $"Invalid quantity for field: {ex.FieldName}"
            );
        }

        // General order-validation exception
        catch (OrderValidationException ex)
        {
            string message = ex.Message;

            // If the exception has an inner exception,
            // include its message as the cause.
            if (ex.InnerException != null)
            {
                message +=
                    $" (caused by: {ex.InnerException.Message})";
            }

            Console.WriteLine(
                $"Order validation failed: {message}"
            );
        }

        finally
        {
            // This executes regardless of success or exception.
            Console.WriteLine("Order attempt complete.");
        }
    }


    public static void Main()
    {
        // ========================================================
        // TEST 1: Missing customer name
        // Expected: MissingFieldException catch
        // ========================================================

        Console.WriteLine("-- Missing customer name --");

        ProcessOrder(
            "",
            2,
            99.98m
        );

        Console.WriteLine();


        // ========================================================
        // TEST 2: Zero quantity
        // Expected: InvalidQuantityException catch
        // ========================================================

        Console.WriteLine("-- Zero quantity --");

        ProcessOrder(
            "Alice",
            0,
            99.98m
        );

        Console.WriteLine();


        // ========================================================
        // TEST 3: Negative price
        // Expected: general OrderValidationException catch
        // ========================================================

        Console.WriteLine("-- Negative price --");

        ProcessOrder(
            "Alice",
            2,
            -10m
        );

        Console.WriteLine();


        // ========================================================
        // TEST 4: Valid order but SaveOrder fails
        //
        // Validation succeeds, but simulated database failure
        // is wrapped inside OrderValidationException.
        // ========================================================

        Console.WriteLine(
            "-- Valid order, SaveOrder fails --"
        );

        ProcessOrder(
            "Alice",
            2,
            99.98m
        );

        Console.WriteLine();


        // ========================================================
        // TEST 5: Fully valid order
        //
        // For this test we need SaveOrder to succeed.
        // ========================================================

        Console.WriteLine("-- Fully valid order --");

        // Directly demonstrate the successful validation result.
        decimal total = ValidateOrder(
            "Alice",
            2,
            99.98m
        );

        Console.WriteLine($"Order total: ${total:F2}");
        Console.WriteLine("Order attempt complete.");
    }
}