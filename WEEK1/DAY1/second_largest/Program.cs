// Summary: Find the second largest distinct element in an integer array.
// Handles duplicate values and prints a message if no second largest exists.
using System;

class Program
{
    static void Main()
    {
        // Define the array to search for the first and second largest values.
        int[] arr = { 10, 20, 30, 40, 50, 50 };

        int? largest = null; // holds the largest distinct value found so far.
        int? second = null; // holds the second largest distinct value found so far.

        foreach (int x in arr)
        {
            if (largest == null || x > largest)
            {
                // Current value becomes the new largest, previous largest becomes second.
                second = largest;
                largest = x;
            }
            else if (x != largest && (second == null || x > second))
            {
                // Current value is distinct from the largest and is bigger than current second.
                second = x;
            }
        }

        if (second == null)
        {
            Console.WriteLine("No second largest element (all elements equal or only one element).");
        }
        else
        {
            Console.WriteLine("Second largest: " + second);
        }
    }
}
