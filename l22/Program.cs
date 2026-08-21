using System;
using System.Text.RegularExpressions;

class Lab2
{
    static void Main()
    {
        // ---------------------------------------------------------
        // 1. Extract order numbers using Regex.Matches
        // ---------------------------------------------------------

        string text = "Order #4521 was shipped. order #99 is pending. ORDER #12345 was cancelled.";

        // Matches Order # followed by one or more digits.
        // IgnoreCase allows Order, order, ORDER, etc.
        MatchCollection orders = Regex.Matches(
            text,
            @"Order\s+#(\d+)",
            RegexOptions.IgnoreCase
        );

        Console.WriteLine("Order Numbers:");

        // Group 1 contains only the numeric part of the order number.
        foreach (Match match in orders)
        {
            Console.WriteLine(match.Groups[1].Value);
        }


        // ---------------------------------------------------------
        // 2. Mask credit card number using Regex.Replace
        // ---------------------------------------------------------

        string cardText = "Card on file: 4111-1111-1111-1234";

        // Capture the first 12 digits/groups and keep the last 4 digits.
        // Replace the first 12 digits with X while preserving separators.
        string maskedCard = Regex.Replace(
            cardText,
            @"\b(\d{4})[- ](\d{4})[- ](\d{4})[- ](\d{4})\b",
            "XXXX-XXXX-XXXX-$4"
        );

        Console.WriteLine("\nMasked Card:");
        Console.WriteLine(maskedCard);


        // ---------------------------------------------------------
        // 3. Reformat "lastname, firstname" to "firstname lastname"
        // ---------------------------------------------------------

        string names = "Smith, John";

        // Group 1 = lastname
        // Group 2 = firstname
        // Replace with firstname followed by lastname.
        string formattedName = Regex.Replace(
            names,
            @"^\s*(\w+)\s*,\s*(\w+)\s*$",
            "$2 $1"
        );

        Console.WriteLine("\nFormatted Name:");
        Console.WriteLine(formattedName);


        // ---------------------------------------------------------
        // 4. Split tags using comma or semicolon
        // ---------------------------------------------------------

        string tags = "red, blue;green , yellow";

        // Split using either comma or semicolon.
        string[] tagArray = Regex.Split(tags, @"[,;]");

        Console.WriteLine("\nClean Tags:");

        // Trim whitespace from every tag before printing.
        foreach (string tag in tagArray)
        {
            string cleanTag = tag.Trim();

            if (cleanTag.Length > 0)
            {
                Console.WriteLine(cleanTag);
            }
        }
    }
}