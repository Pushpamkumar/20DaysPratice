using System;

class Program
{
    // Linear Search
    static int LinearSearch(int[] arr, int key)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] == key)
                return i;
        }
        return -1;
    }

    // Binary Search (Array must be sorted)
    static int BinarySearch(int[] arr, int key)
    {
        int low = 0;
        int high = arr.Length - 1;

        while (low <= high)
        {
            int mid = (low + high) / 2;

            if (arr[mid] == key)
                return mid;
            else if (arr[mid] < key)
                low = mid + 1;
            else
                high = mid - 1;
        }

        return -1;
    }

    
    static void Main(string[] args)
    {
        int[] arr = { 5, 10, 15, 20, 25, 30, 35, 40 };

        // Linear Search
        int linearKey = 25;
        int linearResult = LinearSearch(arr, linearKey);

        if (linearResult != -1)
            Console.WriteLine($"Linear Search: {linearKey} found at index {linearResult}");
        else
            Console.WriteLine("Linear Search: Element not found");

        // Binary Search
        int binaryKey = 30;
        int binaryResult = BinarySearch(arr, binaryKey);

        if (binaryResult != -1)
            Console.WriteLine($"Binary Search: {binaryKey} found at index {binaryResult}");
        else
            Console.WriteLine("Binary Search: Element not found");

        Console.ReadKey();
    }
}