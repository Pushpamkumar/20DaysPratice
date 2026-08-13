using System;

class AdaptiveSortProgram
{
    //=========================================
    // Adaptive Sort
    //=========================================
    static void AdaptiveSort(int[] arr)
    {
        // Already sorted
        if (IsSorted(arr))
        {
            return;
        }

        // Nearly sorted
        if (IsNearlySorted(arr))
        {
            Console.WriteLine("Using Insertion Sort");

            InsertionSort(arr);
        }
        else
        {
            Console.WriteLine("Using Merge Sort");

            MergeSort(arr, 0, arr.Length - 1);
        }
    }

    //=========================================
    // Check Sorted
    //=========================================
    static bool IsSorted(int[] arr)
    {
        for (int i = 1; i < arr.Length; i++)
        {
            if (arr[i] < arr[i - 1])
                return false;
        }

        return true;
    }

    //=========================================
    // Check Nearly Sorted
    //=========================================
    static bool IsNearlySorted(int[] arr)
    {
        int disorder = 0;

        for (int i = 1; i < arr.Length; i++)
        {
            if (arr[i] < arr[i - 1])
                disorder++;
        }

        return disorder <= arr.Length / 10;
    }

    //=========================================
    // Insertion Sort
    //=========================================
    static void InsertionSort(int[] arr)
    {
        for (int i = 1; i < arr.Length; i++)
        {
            int key = arr[i];
            int j = i - 1;

            while (j >= 0 && arr[j] > key)
            {
                arr[j + 1] = arr[j];
                j--;
            }

            arr[j + 1] = key;
        }
    }

    //=========================================
    // Merge Sort
    //=========================================
    static void MergeSort(int[] arr, int left, int right)
    {
        if (left >= right)
            return;

        int mid = left + (right - left) / 2;

        MergeSort(arr, left, mid);
        MergeSort(arr, mid + 1, right);

        Merge(arr, left, mid, right);
    }

    //=========================================
    // Merge
    //=========================================
    static void Merge(int[] arr, int left, int mid, int right)
    {
        int n1 = mid - left + 1;
        int n2 = right - mid;

        int[] L = new int[n1];
        int[] R = new int[n2];

        Array.Copy(arr, left, L, 0, n1);
        Array.Copy(arr, mid + 1, R, 0, n2);

        int i = 0;
        int j = 0;
        int k = left;

        while (i < n1 && j < n2)
        {
            if (L[i] <= R[j])
                arr[k++] = L[i++];
            else
                arr[k++] = R[j++];
        }

        while (i < n1)
            arr[k++] = L[i++];

        while (j < n2)
            arr[k++] = R[j++];
    }

    //=========================================
    // Print
    //=========================================
    static void PrintArray(int[] arr)
    {
        foreach (int x in arr)
            Console.Write(x + " ");

        Console.WriteLine();
    }

    //=========================================
    // Main
    //=========================================
    static void Main()
    {
        int[] arr =
        {
            1,2,3,4,6,5,7,8,9,10
        };

        Console.WriteLine("Original Array:");

        PrintArray(arr);

        AdaptiveSort(arr);

        Console.WriteLine("\nSorted Array:");

        PrintArray(arr);
    }
}