using System;
using System.Text.RegularExpressions;

public static class PatternLibrary
{
    // ============================================================
    // Reusable Regex patterns
    // RegexOptions.Compiled improves performance when a Regex
    // object is reused multiple times.
    // ============================================================

    // Email pattern: basic validation of username@domain.extension
    public static readonly Regex Email = new Regex(
        @"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$",
        RegexOptions.Compiled
    );

    // US phone number pattern:
    // Supports formats such as 123-456-7890, (123) 456-7890
    public static readonly Regex UsPhone = new Regex(
        @"^(?:\(\d{3}\)\s?|\d{3}[-.\s]?)\d{3}[-.\s]?\d{4}$",
        RegexOptions.Compiled
    );

    // Hex color pattern:
    // Supports #RGB and #RRGGBB formats
    public static readonly Regex HexColor = new Regex(
        @"^#(?:[0-9A-Fa-f]{3}|[0-9A-Fa-f]{6})$",
        RegexOptions.Compiled
    );


    // ============================================================
    // Wrapper methods
    // These methods make the Regex patterns easier to use.
    // ============================================================

    public static bool IsValidEmail(string input)
    {
        return Email.IsMatch(input);
    }

    public static bool IsValidPhone(string input)
    {
        return UsPhone.IsMatch(input);
    }

    public static bool IsValidHexColor(string input)
    {
        return HexColor.IsMatch(input);
    }
}


public class Lab4
{
    public static void Main()
    {
        // ============================================================
        // TODO 3: RegexOptions.IgnoreCase demonstration
        // ============================================================

        string pattern = "hello";

        string upperText = "HELLO";
        string lowerText = "hello";

        // Without IgnoreCase, "hello" does NOT match "HELLO"
        bool withoutIgnoreCase =
            Regex.IsMatch(upperText, pattern);

        // With IgnoreCase, "hello" matches both "HELLO" and "hello"
        bool withIgnoreCase =
            Regex.IsMatch(upperText, pattern, RegexOptions.IgnoreCase);

        Console.WriteLine("===== IGNORECASE DEMO =====");
        Console.WriteLine(
            $"Without IgnoreCase (HELLO): {withoutIgnoreCase}"
        );
        Console.WriteLine(
            $"With IgnoreCase (HELLO): {withIgnoreCase}"
        );
        Console.WriteLine(
            $"With IgnoreCase (hello): " +
            Regex.IsMatch(lowerText, pattern, RegexOptions.IgnoreCase)
        );


        // ============================================================
        // TODO 4: RegexOptions.Multiline demonstration
        // ============================================================

        string multiLineText =
            "First line\n" +
            "Second line\n" +
            "Third line";

        // ^ normally matches only at the beginning of the
        // entire input string.
        MatchCollection withoutMultiline = Regex.Matches(
            multiLineText,
            @"^.+$"
        );

        // With Multiline, ^ and $ work at the beginning and
        // end of EACH line.
        MatchCollection withMultiline = Regex.Matches(
            multiLineText,
            @"^.+$",
            RegexOptions.Multiline
        );

        Console.WriteLine();
        Console.WriteLine("===== MULTILINE DEMO =====");

        Console.WriteLine(
            $"Matches without Multiline: {withoutMultiline.Count}"
        );

        Console.WriteLine(
            $"Matches with Multiline: {withMultiline.Count}"
        );


        // ============================================================
        // TODO 5: Test PatternLibrary methods
        // Each method is tested with one valid and one invalid input.
        // ============================================================

        Console.WriteLine();
        Console.WriteLine("===== PATTERN LIBRARY TESTS =====");

        // ---------------- EMAIL ----------------

        string validEmail = "alice@example.com";
        string invalidEmail = "alice@example";

        Console.WriteLine(
            $"Valid Email ({validEmail}): " +
            PatternLibrary.IsValidEmail(validEmail)
        );

        Console.WriteLine(
            $"Invalid Email ({invalidEmail}): " +
            PatternLibrary.IsValidEmail(invalidEmail)
        );


        // ---------------- PHONE ----------------

        string validPhone = "(123) 456-7890";
        string invalidPhone = "12345";

        Console.WriteLine(
            $"Valid Phone ({validPhone}): " +
            PatternLibrary.IsValidPhone(validPhone)
        );

        Console.WriteLine(
            $"Invalid Phone ({invalidPhone}): " +
            PatternLibrary.IsValidPhone(invalidPhone)
        );


        // ---------------- HEX COLOR ----------------

        string validColor = "#FF5733";
        string invalidColor = "#GGGGGG";

        Console.WriteLine(
            $"Valid Hex Color ({validColor}): " +
            PatternLibrary.IsValidHexColor(validColor)
        );

        Console.WriteLine(
            $"Invalid Hex Color ({invalidColor}): " +
            PatternLibrary.IsValidHexColor(invalidColor)
        );
    }
}