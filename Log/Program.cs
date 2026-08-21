using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

// Represents one parsed log entry
public class LogEntry
{
    public string Date { get; init; } = string.Empty;
    public string Time { get; init; } = string.Empty;
    public string Level { get; init; } = string.Empty;
    public string Message { get; init; } = string.Empty;
}

public class Lab5
{
    // Parses every line of the raw log and converts it into LogEntry objects
    public static List<LogEntry> ParseLog(string rawLog)
    {
        // Named groups:
        // (?<date>)    -> captures the date
        // (?<time>)    -> captures the time
        // (?<level>)   -> captures INFO, WARN, or ERROR
        // (?<message>) -> captures the complete message
        //
        // ^ and $ make the pattern work line-by-line with Multiline
        string pattern =
            @"^(?<date>\d{4}-\d{2}-\d{2})\s+" +
            @"(?<time>\d{2}:\d{2}:\d{2})\s+" +
            @"(?<level>INFO|WARN|ERROR)\s+" +
            @"(?<message>.*)$";

        // RegexOptions.Multiline allows ^ and $ to work for every line
        Regex regex = new Regex(pattern, RegexOptions.Multiline);

        List<LogEntry> entries = new List<LogEntry>();

        // Find every matching log line
        foreach (Match match in regex.Matches(rawLog))
        {
            // Build a LogEntry using an object initializer
            LogEntry entry = new LogEntry
            {
                Date = match.Groups["date"].Value,
                Time = match.Groups["time"].Value,
                Level = match.Groups["level"].Value,
                Message = match.Groups["message"].Value
            };

            entries.Add(entry);
        }

        return entries;
    }

    // Replaces numeric error codes only on ERROR log lines
    public static string RedactErrorCodes(string rawLog)
    {
        // Pattern checks that the line starts with a valid date and time,
        // followed by ERROR, and then searches for code=NNN.
        //
        // (?<code>\d{3}) captures exactly three digits.
        string pattern =
            @"^(?<prefix>\d{4}-\d{2}-\d{2}\s+\d{2}:\d{2}:\d{2}\s+ERROR.*?\bcode=)(?<code>\d{3})";

        // MatchEvaluator allows us to control exactly what replacement is made
        MatchEvaluator evaluator = match =>
        {
            // Keep everything before the number and replace the number with ###
            return match.Groups["prefix"].Value + "###";
        };

        // Multiline makes ^ work on every individual log line
        return Regex.Replace(
            rawLog,
            pattern,
            evaluator,
            RegexOptions.Multiline
        );
    }

    public static void Main()
    {
        // Multi-line raw log containing INFO, WARN and ERROR entries
        // At least two ERROR entries contain numeric error codes.
        string rawLog = """
2026-08-19 09:15:20 INFO Application started successfully
2026-08-19 09:16:05 INFO User logged in
2026-08-19 09:17:30 WARN Disk space is getting low
2026-08-19 09:18:42 ERROR Failed to fetch resource code=404
2026-08-19 09:19:10 INFO Data processing completed
2026-08-19 09:20:55 ERROR Database connection failed code=500
""";

        // Parse the raw log into a list of LogEntry objects
        List<LogEntry> entries = ParseLog(rawLog);

        Console.WriteLine("===== PARSED LOG SUMMARY =====");

        // Print every parsed log entry
        foreach (LogEntry entry in entries)
        {
            Console.WriteLine(
                $"{entry.Date} {entry.Time} {entry.Level} {entry.Message}"
            );
        }

        // LINQ is used to group entries according to their log level
        var summary = entries
            .GroupBy(entry => entry.Level)
            .Select(group => new
            {
                Level = group.Key,
                Count = group.Count()
            });

        Console.WriteLine();
        Console.WriteLine("===== LEVEL SUMMARY =====");

        // Print the count for each log level
        foreach (var item in summary)
        {
            Console.WriteLine($"{item.Level}: {item.Count}");
        }

        // Redact error codes using the MatchEvaluator
        string redactedLog = RedactErrorCodes(rawLog);

        Console.WriteLine();
        Console.WriteLine("===== REDACTED LOG =====");

        // Print the modified log
        Console.WriteLine(redactedLog);
    }
}