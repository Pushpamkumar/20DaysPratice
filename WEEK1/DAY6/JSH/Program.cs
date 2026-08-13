using System;
using System.Collections.Generic;

class Program
{
    // ------------------ Jump Search ------------------
    static int JumpSearch(int[] arr, int key)
    {
        int n = arr.Length;
        int step = (int)Math.Sqrt(n);
        int prev = 0;

        while (arr[Math.Min(step, n) - 1] < key)
        {
            prev = step;
            step += (int)Math.Sqrt(n);

            if (prev >= n)
                return -1;
        }

        while (arr[prev] < key)
        {
            prev++;

            if (prev == Math.Min(step, n))
                return -1;
        }

        if (arr[prev] == key)
            return prev;

        return -1;
    }

    // ------------------ Hashing Search ------------------
    static bool HashSearch(Dictionary<int, int> hashTable, int key)
    {
        return hashTable.ContainsKey(key);
    }

    // ------------------ Fibonacci Search ------------------
    static int FibonacciSearch(int[] arr, int key)
    {
        int n = arr.Length;

        int fibMMm2 = 0;
        int fibMMm1 = 1;
        int fibM = fibMMm2 + fibMMm1;

        while (fibM < n)
        {
            fibMMm2 = fibMMm1;
            fibMMm1 = fibM;
            fibM = fibMMm2 + fibMMm1;
        }

        int offset = -1;

        while (fibM > 1)
        {
            int i = Math.Min(offset + fibMMm2, n - 1);

            if (arr[i] < key)
            {
                fibM = fibMMm1;
                fibMMm1 = fibMMm2;
                fibMMm2 = fibM - fibMMm1;
                offset = i;
            }
            else if (arr[i] > key)
            {
                fibM = fibMMm2;
                fibMMm1 = fibMMm1 - fibMMm2;
                fibMMm2 = fibM - fibMMm1;
            }
            else
            {
                return i;
            }
        }

        if (fibMMm1 == 1 && offset + 1 < n && arr[offset + 1] == key)
            return offset + 1;

        return -1;
    }

    static void Main()
    {
        int[] arr = { 5, 10, 15, 20, 25, 30, 35, 40, 45, 50 };
        int key = 35;

        Console.WriteLine("Array:");
        foreach (int num in arr)
            Console.Write(num + " ");

        Console.WriteLine("\n");

        // Jump Search
        int jumpResult = JumpSearch(arr, key);
        Console.WriteLine("Jump Search:");
        Console.WriteLine(jumpResult != -1
            ? $"Element found at index {jumpResult}"
            : "Element not found");

        Console.WriteLine();

        // Hashing Search
        Dictionary<int, int> hashTable = new Dictionary<int, int>();
        for (int i = 0; i < arr.Length; i++)
            hashTable[arr[i]] = i;

        Console.WriteLine("Hashing Search:");
        if (HashSearch(hashTable, key))
            Console.WriteLine($"Element found at index {hashTable[key]}");
        else
            Console.WriteLine("Element not found");

        Console.WriteLine();

        // Fibonacci Search
        int fibResult = FibonacciSearch(arr, key);
        Console.WriteLine("Fibonacci Search:");
        Console.WriteLine(fibResult != -1
            ? $"Element found at index {fibResult}"
            : "Element not found");
    }
}