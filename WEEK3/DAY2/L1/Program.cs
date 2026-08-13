using System;

public class InventoryItem
{
    // Private backing field for Quantity
    // This prevents direct access from outside the class.
    private int quantity;

    // Name can only be assigned during object initialization.
    // The init accessor prevents changing it after construction.
    public string Name { get; init; }

    // Quantity property with validation.
    public int Quantity
    {
        get
        {
            return quantity;
        }

        set
        {
            // Quantity cannot be negative.
            if (value < 0)
            {
                throw new ArgumentException(
                    "Quantity cannot be negative."
                );
            }

            quantity = value;
        }
    }

    // UnitPrice property with validation.
    public decimal UnitPrice { get; set; }

    // Read-only computed property.
    // No separate backing field is required.
    public decimal TotalValue
    {
        get
        {
            return Quantity * UnitPrice;
        }
    }

    // Constructor
    public InventoryItem(string name, int quantity, decimal unitPrice)
    {
        // Validate Name
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException(
                "Name cannot be null or whitespace."
            );
        }

        // Validate UnitPrice
        if (unitPrice <= 0)
        {
            throw new ArgumentException(
                "UnitPrice must be greater than 0."
            );
        }

        // Assign values through properties.
        // This ensures validation is applied.
        Name = name;
        Quantity = quantity;
        UnitPrice = unitPrice;
    }
}

public class Program
{
    public static void Main()
    {
        // Create a valid InventoryItem
        InventoryItem item = new InventoryItem(
            "Laptop",
            10,
            50000m
        );

        Console.WriteLine("Inventory Item Details");
        Console.WriteLine("----------------------");

        Console.WriteLine($"Name: {item.Name}");
        Console.WriteLine($"Quantity: {item.Quantity}");
        Console.WriteLine($"Unit Price: {item.UnitPrice}");
        Console.WriteLine($"Total Value: {item.TotalValue}");

        Console.WriteLine("\nTesting Validation...");

        // Try to set negative quantity
        try
        {
            item.Quantity = -5;
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Quantity Error: {ex.Message}");
        }

        // Try to set invalid UnitPrice
        try
        {
            item.UnitPrice = 0;
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Unit Price Error: {ex.Message}");
        }
    }
}