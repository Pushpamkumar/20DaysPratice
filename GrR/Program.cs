using System;
using System.Text.RegularExpressions;
using System.Globalization;

public class Lab3
{
    public static void Main()
    {
        // ============================================================
        // TODO 1: Named Groups - Parse a structured log line
        // ============================================================

        string logLine = "2026-08-14 09:15:32 ERROR Connection timed out";

        // Named groups capture date, time, level and message separately
        string logPattern =
            @"^(?<date>\d{4}-\d{2}-\d{2})\s+" +
            @"(?<time>\d{2}:\d{2}:\d{2})\s+" +
            @"(?<level>INFO|WARN|ERROR)\s+" +
            @"(?<message>.*)$";

        Match logMatch = Regex.Match(logLine, logPattern);

        Console.WriteLine("===== LOG DETAILS =====");

        // Print each named group's value separately
        Console.WriteLine($"Date    : {logMatch.Groups["date"].Value}");
        Console.WriteLine($"Time    : {logMatch.Groups["time"].Value}");
        Console.WriteLine($"Level   : {logMatch.Groups["level"].Value}");
        Console.WriteLine($"Message : {logMatch.Groups["message"].Value}");

        // ============================================================
        // TODO 2: Named Groups - Parse key=value pairs
        // ============================================================

        string kvText = "name=Alice;age=30;city=NYC";

        // The pattern captures the key before '='
        // and the value after '=' until the next semicolon
        string kvPattern = @"(?<key>[^=;]+)=(?<value>[^;]+)";

        Console.WriteLine();
        Console.WriteLine("===== KEY/VALUE PAIRS =====");

        // Regex.Matches finds every key=value pair
        MatchCollection pairs = Regex.Matches(kvText, kvPattern);

        foreach (Match pair in pairs)
        {
            Console.WriteLine(
                $"Key: {pair.Groups["key"].Value}, " +
                $"Value: {pair.Groups["value"].Value}"
            );
        }

        // ============================================================
        // TODO 3: MatchEvaluator - Format numbers
        // ============================================================

        string numbers = "Revenue: 1234567, Costs: 89000";

        // \b\d+\b finds every complete whole number
        string numberPattern = @"\b\d+\b";

        // MatchEvaluator allows us to programmatically format
        // each number instead of using a simple $1 replacement
        string formattedNumbers = Regex.Replace(
            numbers,
            numberPattern,
            match =>
            {
                // Convert the matched text into a number
                long number = long.Parse(match.Value);

                // Format the number with thousands separators
                return number.ToString("N0", CultureInfo.InvariantCulture);
            }
        );

        Console.WriteLine();
        Console.WriteLine("===== FORMATTED NUMBERS =====");
        Console.WriteLine(formattedNumbers);

        // ============================================================
        // TODO 4: MatchEvaluator - Convert ALL CAPS words
        // to Title Case
        // ============================================================

        string shouting = "THIS IS URGENT please respond";

        // Finds words containing only uppercase letters.
        // {2,} means the word must contain at least 2 letters.
        string capsPattern = @"\b[A-Z]{2,}\b";

        // MatchEvaluator converts each ALL CAPS word individually
        string titleCaseText = Regex.Replace(
            shouting,
            capsPattern,
            match =>
            {
                // Convert the word to lowercase first
                string lowerWord = match.Value.ToLowerInvariant();

                // Capitalize the first letter
                return char.ToUpperInvariant(lowerWord[0]) +
                       lowerWord.Substring(1);
            }
        );

        Console.WriteLine();
        Console.WriteLine("===== TITLE CASE =====");
        Console.WriteLine(titleCaseText);
    }
}