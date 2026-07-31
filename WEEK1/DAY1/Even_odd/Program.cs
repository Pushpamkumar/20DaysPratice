// Summary: Count the number of even and odd integers in a fixed array.
// Prints the total even and odd counts after evaluation.
using System;

class Program
{
    static void Main()
    {
        int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        int evenCount = 0;
        int oddCount = 0;

        foreach (int num in arr)
        {
            if (num % 2 == 0)
            {
                evenCount++;
            }
            else
            {
                oddCount++;
            }
        }

        Console.WriteLine("Even count: " + evenCount);
        Console.WriteLine("Odd count: " + oddCount);
    }
}