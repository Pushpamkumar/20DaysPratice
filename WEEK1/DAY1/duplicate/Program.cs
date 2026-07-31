using System;
using System.Collections.Generic;

/// <summary>
/// Demonstrates how to identify duplicate elements in an integer array
/// using a dictionary to count the frequency of each element.
/// It also removes duplicate elements while preserving
/// the order of their first occurrence.
/// </summary>
class Program
{
    /// <summary>
    /// Entry point of the program.
    /// Finds duplicate elements and removes duplicates from the array.
    /// </summary>
    static void Main()
    {
        // Sample array containing duplicate values.
        int[] arr = { 1, 2, 3, 2, 4, 5, 1, 6 };

        // Dictionary stores each number along with
        // the number of times it appears.
        Dictionary<int, int> dict = new Dictionary<int, int>();

        // Count the frequency of every element.
        foreach (int num in arr)
        {
            if (dict.ContainsKey(num))
            {
                // Increment count if the element already exists.
                dict[num]++;
            }
            else
            {
                // Add the element with an initial count of 1.
                dict[num] = 1;
            }
        }

        Console.WriteLine("Duplicate Elements:");

        // Print elements whose frequency is greater than 1.
        foreach (var item in dict)
        {
            if (item.Value > 1)
            {
                Console.WriteLine(item.Key);
            }
        }

        // List to store unique elements while maintaining
        // the original order of appearance.
        List<int> result = new List<int>();

        // Traverse the array and add only unseen elements.
        foreach (int num in arr)
        {
            if (!result.Contains(num))
            {
                result.Add(num);
            }
        }

        Console.WriteLine("\nArray After Removing Duplicates:");

        // Display the array after removing duplicates.
        foreach (int num in result)
        {
            Console.Write(num + " ");
        }
    }
}