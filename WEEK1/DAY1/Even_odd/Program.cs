// Summary: Count the number of even and odd integers in a fixed array.
// Prints the total even and odd counts after evaluation.
using System;

class Program
{
    static void Main()
    {
        // Define the sample list of integers to evaluate.
        int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        int evenCount = 0; // count of even numbers
        int oddCount = 0;  // count of odd numbers

        // Iterate through each number and categorize it.
        foreach (int num in arr)
        {
            if (num % 2 == 0)
            {
                evenCount++; // increment if number is even
            }
            else
            {
                oddCount++; // increment if number is odd
            }
        }

        // Print the final counts to the console.
        Console.WriteLine("Even count: " + evenCount);
        Console.WriteLine("Odd count: " + oddCount);
    }
}