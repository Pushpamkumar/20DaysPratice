using System;

class HeapSortProgram
{
    // Heap Sort Function
    static void HeapSort(int[] arr)
    {
        int n = arr.Length;

        // Step 1: Build Max Heap
        for (int i = n / 2 - 1; i >= 0; i--)
        {
            Heapify(arr, n, i);
        }

        // Step 2: Extract elements one by one
        for (int i = n - 1; i > 0; i--)
        {
            // Move current root to end
            int temp = arr[0];
            arr[0] = arr[i];
            arr[i] = temp;

            // Heapify the reduced heap
            Heapify(arr, i, 0);
        }
    }

    // Heapify Function
    static void Heapify(int[] arr, int n, int i)
    {
        int largest = i;

        int left = 2 * i + 1;
        int right = 2 * i + 2;

        // Check left child
        if (left < n && arr[left] > arr[largest])
        {
            largest = left;
        }

        // Check right child
        if (right < n && arr[right] > arr[largest])
        {
            largest = right;
        }

        // If largest is not root
        if (largest != i)
        {
            int temp = arr[i];
            arr[i] = arr[largest];
            arr[largest] = temp;

            // Recursively heapify affected subtree
            Heapify(arr, n, largest);
        }
    }

    // Print Array
    static void PrintArray(int[] arr)
    {
        foreach (int num in arr)
        {
            Console.Write(num + " ");
        }
        Console.WriteLine();
    }

    static void Main()
    {
        int[] arr = { 64, 34, 25, 12, 22, 11, 90, 5 };

        Console.WriteLine("Original Array:");
        PrintArray(arr);

        HeapSort(arr);

        Console.WriteLine("\nSorted Array:");
        PrintArray(arr);
    }
}