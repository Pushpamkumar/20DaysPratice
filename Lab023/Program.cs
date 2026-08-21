using System;
using System.Collections.Generic;

// ================================================================
// Custom exception
// Thrown when someone tries to sell more stock than available.
// ================================================================
public class InsufficientStockException : Exception
{
    public InsufficientStockException(string message)
        : base(message)
    {
    }
}


// ================================================================
// Lab 3 - Inventory System
// ================================================================
public class Lab3
{
    // Dictionary is appropriate because:
    // - SKU is a unique key.
    // - Lookup by SKU is very fast on average.
    // - We do not need to search the entire collection.
    static Dictionary<string, int> inventory =
        new Dictionary<string, int>(
            StringComparer.OrdinalIgnoreCase
        );


    // ============================================================
    // RestockItem
    //
    // If the SKU exists, increase its quantity.
    // Otherwise add a new SKU.
    //
    // TryGetValue avoids doing ContainsKey() followed by another
    // dictionary lookup.
    // ============================================================
    static void RestockItem(string sku, int quantity)
    {
        if (quantity <= 0)
        {
            Console.WriteLine(
                "Restock quantity must be greater than zero."
            );
            return;
        }

        if (inventory.TryGetValue(sku, out int currentQuantity))
        {
            inventory[sku] = currentQuantity + quantity;
        }
        else
        {
            inventory[sku] = quantity;
        }

        Console.WriteLine(
            $"Restocked {sku} by {quantity} units."
        );
    }


    // ============================================================
    // SellItem
    //
    // Checks whether the SKU exists and whether enough stock is
    // available before completing the sale.
    // ============================================================
    static void SellItem(string sku, int quantity)
    {
        if (!inventory.TryGetValue(sku, out int currentQuantity))
        {
            Console.WriteLine(
                $"SKU '{sku}' was not found."
            );
            return;
        }

        if (quantity <= 0)
        {
            Console.WriteLine(
                "Sale quantity must be greater than zero."
            );
            return;
        }

        if (quantity > currentQuantity)
        {
            throw new InsufficientStockException(
                $"Cannot sell {quantity} units of {sku}. " +
                $"Only {currentQuantity} available."
            );
        }

        inventory[sku] = currentQuantity - quantity;

        Console.WriteLine(
            $"Sold {quantity} units of {sku}."
        );
    }


    // ============================================================
    // LowStockReport
    //
    // Returns all SKUs whose quantity is below the threshold.
    //
    // foreach over Dictionary is appropriate because we need to
    // examine each key/value pair.
    // ============================================================
    static List<string> LowStockReport(int threshold)
    {
        List<string> result = new List<string>();

        foreach (KeyValuePair<string, int> item in inventory)
        {
            if (item.Value < threshold)
            {
                result.Add(
                    $"{item.Key}: {item.Value} units"
                );
            }
        }

        return result;
    }


    // ============================================================
    // PrintInventory
    // ============================================================
    static void PrintInventory()
    {
        foreach (KeyValuePair<string, int> item in inventory)
        {
            Console.WriteLine(
                $"{item.Key}: {item.Value} units"
            );
        }
    }


    public static void Main()
    {
        Console.WriteLine("========================================");
        Console.WriteLine("LAB 3 - INVENTORY LOOKUP");
        Console.WriteLine("========================================");


        // ========================================================
        // Load at least 8 sample SKUs
        // ========================================================

        inventory["SKU001"] = 50;
        inventory["SKU002"] = 25;
        inventory["SKU003"] = 10;
        inventory["SKU004"] = 75;
        inventory["SKU005"] = 5;
        inventory["SKU006"] = 100;
        inventory["SKU007"] = 15;
        inventory["SKU008"] = 3;

        Console.WriteLine("\n--- Initial Inventory ---");
        PrintInventory();


        // ========================================================
        // Successful restock
        // ========================================================

        Console.WriteLine("\n--- Restock ---");

        RestockItem("SKU003", 20);

        Console.WriteLine(
            $"SKU003 now has {inventory["SKU003"]} units."
        );


        // ========================================================
        // Successful sale
        // ========================================================

        Console.WriteLine("\n--- Successful Sale ---");

        SellItem("SKU001", 10);

        Console.WriteLine(
            $"SKU001 now has {inventory["SKU001"]} units."
        );


        // ========================================================
        // Oversell attempt
        // ========================================================

        Console.WriteLine("\n--- Oversell Attempt ---");

        try
        {
            SellItem("SKU005", 50);
        }
        catch (InsufficientStockException ex)
        {
            Console.WriteLine(
                $"Sale failed: {ex.Message}"
            );
        }


        // ========================================================
        // Unknown SKU
        // ========================================================

        Console.WriteLine("\n--- Unknown SKU ---");

        SellItem("UNKNOWN", 5);


        // ========================================================
        // Low-stock report
        // ========================================================

        Console.WriteLine(
            "\n--- Low Stock Report (Below 10) ---"
        );

        List<string> lowStock = LowStockReport(10);

        foreach (string item in lowStock)
        {
            Console.WriteLine(item);
        }
    }
}