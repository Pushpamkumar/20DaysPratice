// Summary: Read a line of text and print the reversed version of the string.
// Uses built-in char array reversal to invert the input string.
// Summary: Read a string from the user and print the reversed version.
using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter a string to reverse:");
        string? input = Console.ReadLine(); // read the user input
        if (string.IsNullOrEmpty(input))
        {
            Console.WriteLine("No input provided.");
            return; // exit if there is no valid input
        }

        char[] arr = input.ToCharArray(); // convert the string to a character array
        Array.Reverse(arr); // reverse the array in place
        string reversed = new string(arr); // build a new string from the reversed array

        Console.WriteLine("Reversed: " + reversed);
    }
}
