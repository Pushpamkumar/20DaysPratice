using System;

class TimSortProgram
{
    // Minimum run size
    const int RUN = 32;

    // ------------------------------
    // Insertion Sort
    // ------------------------------
    static void InsertionSort(int[] arr, int left, int right)
    {
        for (int i = left + 1; i <= right; i++)
        {
            int temp = arr[i];
            int j = i - 1;

            while (j >= left && arr[j] > temp)
            {
                arr[j + 1] = arr[j];
                j--;
            }

            arr[j + 1] = temp;
        }
    }

    // ------------------------------
    // Merge Function
    // ------------------------------
    static void Merge(int[] arr, int left, int mid, int right)
    {
        int len1 = mid - left + 1;
        int len2 = right - mid;

        int[] leftArray = new int[len1];
        int[] rightArray = new int[len2];

        Array.Copy(arr, left, leftArray, 0, len1);
        Array.Copy(arr, mid + 1, rightArray, 0, len2);

        int i = 0;
        int j = 0;
        int k = left;

        while (i < len1 && j < len2)
        {
            if (leftArray[i] <= rightArray[j])
            {
                arr[k] = leftArray[i];
                i++;
            }
            else
            {
                arr[k] = rightArray[j];
                j++;
            }

            k++;
        }

        while (i < len1)
        {
            arr[k] = leftArray[i];
            i++;
            k++;
        }

        while (j < len2)
        {
            arr[k] = rightArray[j];
            j++;
            k++;
        }
    }

    // ------------------------------
    // Tim Sort
    // ------------------------------
    static void TimSort(int[] arr)
    {
        int n = arr.Length;

        // Step 1: Sort each RUN using insertion sort
        for (int i = 0; i < n; i += RUN)
        {
            InsertionSort(arr, i, Math.Min(i + RUN - 1, n - 1));
        }

        // Step 2: Merge runs
        for (int size = RUN; size < n; size *= 2)
        {
            for (int left = 0; left < n; left += 2 * size)
            {
                int mid = left + size - 1;

                if (mid >= n - 1)
                    continue;

                int right = Math.Min(left + 2 * size - 1, n - 1);

                Merge(arr, left, mid, right);
            }
        }
    }

    // ------------------------------
    // Print Array
    // ------------------------------
    static void PrintArray(int[] arr)
    {
        foreach (int x in arr)
            Console.Write(x + " ");

        Console.WriteLine();
    }

    // ------------------------------
    // Main
    // ------------------------------
    static void Main()
    {
        int[] arr =
        {
            64,34,25,12,22,11,90,5,
            18,72,43,9,1,55,30,15,
            88,17,2,60,99,45,31,27,
            80,10,6,14,13,8,3,4
        };

        Console.WriteLine("Original Array:");
        PrintArray(arr);

        TimSort(arr);

        Console.WriteLine("\nSorted Array:");
        PrintArray(arr);
    }
}