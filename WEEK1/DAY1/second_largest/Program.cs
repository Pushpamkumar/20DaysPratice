// Summary: Find the second largest distinct element in an integer array.
// Handles duplicate values and prints a message if no second largest exists.
using System;

class Program
{
    static void Main()
    {
    
        int[] arr = { 10, 20, 30, 40, 50, 50 };

        int? largest = null;
        int? second = null;

        foreach (int x in arr)
        {
            if (largest == null || x > largest)
            {
                second = largest;
                largest = x;
            }
            else if (x != largest && (second == null || x > second))
            {
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
