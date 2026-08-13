using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

static class StringToolkit
{
    // 1. Reverse a string
    public static string Reverse(string input)
    {
        char[] characters = input.ToCharArray();

        Array.Reverse(characters);

        return new string(characters);
    }


    // 2. Count occurrences of a character
    public static int CountChar(string text, char searchChar)
    {
        int count = 0;

        foreach (char character in text)
        {
            if (character == searchChar)
            {
                count++;
            }
        }

        return count;
    }


    // 3. Remove duplicate characters
    public static string RemoveDuplicates(string input)
    {
        HashSet<char> seen = new HashSet<char>();
        StringBuilder result = new StringBuilder();

        foreach (char character in input)
        {
            if (!seen.Contains(character))
            {
                seen.Add(character);
                result.Append(character);
            }
        }

        return result.ToString();
    }


    // 4. Check whether a string is a palindrome
    // Ignores case and spaces
    public static bool IsPalindrome(string input)
    {
        string cleaned = input
            .Replace(" ", "")
            .ToLower();

        string reversed = Reverse(cleaned);

        return cleaned == reversed;
    }


    // 5. Convert string to Title Case
    public static string ToTitleCase(string input)
    {
        TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;

        return textInfo.ToTitleCase(input.ToLower());
    }


    // 6. Extract only digits from a string
    public static string ExtractNumbers(string input)
    {
        StringBuilder result = new StringBuilder();

        foreach (char character in input)
        {
            if (char.IsDigit(character))
            {
                result.Append(character);
            }
        }

        return result.ToString();
    }


    // Bonus: Count frequency of each word
    public static Dictionary<string, int> WordFrequency(string text)
    {
        Dictionary<string, int> frequency =
            new Dictionary<string, int>();

        // Convert punctuation to spaces
        StringBuilder cleaned = new StringBuilder();

        foreach (char character in text)
        {
            if (char.IsLetterOrDigit(character) || char.IsWhiteSpace(character))
            {
                cleaned.Append(character);
            }
            else
            {
                cleaned.Append(' ');
            }
        }

        string[] words = cleaned.ToString()
            .ToLower()
            .Split(
                new char[] { ' ', '\t', '\n' },
                StringSplitOptions.RemoveEmptyEntries
            );

        foreach (string word in words)
        {
            if (frequency.ContainsKey(word))
            {
                frequency[word]++;
            }
            else
            {
                frequency[word] = 1;
            }
        }

        return frequency;
    }
}


class Lab3
{
    static void Main()
    {
        // Reverse
        Console.WriteLine(
            "Reverse(\"Hello\") -> " +
            StringToolkit.Reverse("Hello")
        );


        // CountChar
        Console.WriteLine(
            "CountChar(\"banana\", 'a') -> " +
            StringToolkit.CountChar("banana", 'a')
        );


        // RemoveDuplicates
        Console.WriteLine(
            "RemoveDuplicates(\"mississippi\") -> " +
            StringToolkit.RemoveDuplicates("mississippi")
        );


        // IsPalindrome
        Console.WriteLine(
            "IsPalindrome(\"race car\") -> " +
            StringToolkit.IsPalindrome("race car")
        );


        // ToTitleCase
        Console.WriteLine(
            "ToTitleCase(\"hello training team\") -> " +
            StringToolkit.ToTitleCase("hello training team")
        );


        // ExtractNumbers
        Console.WriteLine(
            "ExtractNumbers(\"Order #4521, qty 3\") -> " +
            StringToolkit.ExtractNumbers("Order #4521, qty 3")
        );


        // Bonus: WordFrequency
        Console.WriteLine("\nWord Frequency:");

        Dictionary<string, int> frequencies =
            StringToolkit.WordFrequency(
                "Hello hello world! Training world."
            );

        foreach (var item in frequencies)
        {
            Console.WriteLine(
                item.Key + " -> " + item.Value
            );
        }
    }
}