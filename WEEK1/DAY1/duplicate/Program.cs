// Summary: Identify and print duplicate elements from an integer array.
// Uses a dictionary to count occurrences and prints values that appear more than once.
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // duplicate elements

        int[] arr = { 1, 2, 3, 2, 4, 5, 1, 6 };

        Dictionary<int, int> dict = new Dictionary<int, int>();

        // Count how many times each number occurs in the array.
        foreach (int num in arr)
        {
            if (dict.ContainsKey(num))
                dict[num]++;
            else
                dict[num] = 1;
        }

        Console.WriteLine("Duplicate Elements:");

        foreach (var item in dict)
        {
            if (item.Value > 1)
            {
                Console.WriteLine(item.Key);
            }
        }
        

        // removing the duplicate
        // int[] arr = { 1, 2, 3, 2, 4, 5, 1, 6 };

        // List<int> result = new List<int>();

        // foreach (int num in arr)
        // {
        //     if (!result.Contains(num))
        //     {
        //         result.Add(num);
        //     }
        // }

        // Console.WriteLine("Array After Removing Duplicates:");

        // foreach (int num in result)
        // {
        //     Console.Write(num + " ");
        // }
    }
}