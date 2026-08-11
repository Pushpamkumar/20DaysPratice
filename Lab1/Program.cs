using System;

class Lab1
{
    static void Main()
    {
        // Original string
        string original = "  Hello, Training Team!  ";

        // TODO 1: Trim the string into a new variable
        string trimmed = original.Trim();

        // TODO 2: Compare original and trimmed using ReferenceEquals
        Console.WriteLine(
            "ReferenceEquals(original, trimmed): " +
            object.ReferenceEquals(original, trimmed)
        );

        // TODO 3: Contains / StartsWith / IndexOf / Replace

        // Check if string contains "Training"
        Console.WriteLine(
            "Contains \"Training\": " +
            trimmed.Contains("Training")
        );

        // Check if string starts with "Hello"
        Console.WriteLine(
            "StartsWith trimmed \"Hello\": " +
            trimmed.StartsWith("Hello")
        );

        // Find the index of the first comma
        Console.WriteLine(
            "Index of first comma: " +
            trimmed.IndexOf(',')
        );

        // Replace "Training Team" with "Engineering Team"
        string replaced = trimmed.Replace(
            "Training Team",
            "Engineering Team"
        );

        Console.WriteLine(
            "\"Training Team\" replaced -> " + replaced
        );

        // TODO 4: Split into words using spaces and commas
        string[] words = trimmed.Split(
            new char[] { ' ', ',' },
            StringSplitOptions.RemoveEmptyEntries
        );

        foreach (string word in words)
        {
            Console.WriteLine(word);
        }

        // TODO 5: IsNullOrWhiteSpace checks

        string nullString = null;
        string emptyString = "";
        string whitespaceString = "   ";
        string normalString = "ok";

        Console.WriteLine(
            "IsNullOrWhiteSpace(null): " +
            string.IsNullOrWhiteSpace(nullString)
        );

        Console.WriteLine(
            "IsNullOrWhiteSpace(\"\"): " +
            string.IsNullOrWhiteSpace(emptyString)
        );

        Console.WriteLine(
            "IsNullOrWhiteSpace(\"   \"): " +
            string.IsNullOrWhiteSpace(whitespaceString)
        );

        Console.WriteLine(
            "IsNullOrWhiteSpace(\"ok\"): " +
            string.IsNullOrWhiteSpace(normalString)
        );

        // Bonus Challenge
        string text1 = "HELLO";
        string text2 = "hello";

        int comparison = string.Compare(
            text1,
            text2,
            StringComparison.OrdinalIgnoreCase
        );

        // OrdinalIgnoreCase ignores differences in uppercase/lowercase,
        // so "HELLO" and "hello" are considered equal.
        Console.WriteLine(
            "Compare HELLO and hello (OrdinalIgnoreCase): " +
            comparison
        );
    }
}