using System;

class IntroSortProgram
{
    const int SIZE_THRESHOLD = 16;

    //==================================================
    // Main IntroSort Function
    //==================================================
    static void IntroSort(int[] arr)
    {
        int depthLimit = 2 * FloorLog2(arr.Length);

        IntroSortUtil(arr, 0, arr.Length - 1, depthLimit);
    }

    //==================================================
    // IntroSort Utility
    //==================================================
    static void IntroSortUtil(int[] arr, int low, int high, int depthLimit)
    {
        while (high - low > SIZE_THRESHOLD)
        {
            // If recursion depth exceeds limit,
            // switch to Heap Sort
            if (depthLimit == 0)
            {
                HeapSortRange(arr, low, high);
                return;
            }

            depthLimit--;

            int pivot = Partition(arr, low, high);

            // Sort smaller part first
            if (pivot - low < high - pivot)
            {
                IntroSortUtil(arr, low, pivot - 1, depthLimit);
                low = pivot + 1;
            }
            else
            {
                IntroSortUtil(arr, pivot + 1, high, depthLimit);
                high = pivot - 1;
            }
        }

        // Small partitions -> Insertion Sort
        InsertionSortRange(arr, low, high);
    }

    //==================================================
    // Partition (Quick Sort)
    //==================================================
    static int Partition(int[] arr, int low, int high)
    {
        int pivot = arr[high];

        int i = low - 1;

        for (int j = low; j < high; j++)
        {
            if (arr[j] <= pivot)
            {
                i++;

                Swap(arr, i, j);
            }
        }

        Swap(arr, i + 1, high);

        return i + 1;
    }

    //==================================================
    // Insertion Sort
    //==================================================
    static void InsertionSortRange(int[] arr, int left, int right)
    {
        for (int i = left + 1; i <= right; i++)
        {
            int key = arr[i];
            int j = i - 1;

            while (j >= left && arr[j] > key)
            {
                arr[j + 1] = arr[j];
                j--;
            }

            arr[j + 1] = key;
        }
    }

    //==================================================
    // Heap Sort for Subarray
    //==================================================
    static void HeapSortRange(int[] arr, int left, int right)
    {
        int size = right - left + 1;

        // Build Heap
        for (int i = size / 2 - 1; i >= 0; i--)
        {
            Heapify(arr, size, i, left);
        }

        // Extract
        for (int i = size - 1; i > 0; i--)
        {
            Swap(arr, left, left + i);

            Heapify(arr, i, 0, left);
        }
    }

    //==================================================
    // Heapify
    //==================================================
    static void Heapify(int[] arr, int size, int root, int offset)
    {
        int largest = root;

        int leftChild = 2 * root + 1;
        int rightChild = 2 * root + 2;

        if (leftChild < size &&
            arr[offset + leftChild] > arr[offset + largest])
        {
            largest = leftChild;
        }

        if (rightChild < size &&
            arr[offset + rightChild] > arr[offset + largest])
        {
            largest = rightChild;
        }

        if (largest != root)
        {
            Swap(arr, offset + root, offset + largest);

            Heapify(arr, size, largest, offset);
        }
    }

    //==================================================
    // Swap
    //==================================================
    static void Swap(int[] arr, int i, int j)
    {
        int temp = arr[i];
        arr[i] = arr[j];
        arr[j] = temp;
    }

    //==================================================
    // floor(log2(n))
    //==================================================
    static int FloorLog2(int n)
    {
        int result = 0;

        while (n > 1)
        {
            result++;
            n /= 2;
        }

        return result;
    }

    //==================================================
    // Print Array
    //==================================================
    static void PrintArray(int[] arr)
    {
        foreach (int x in arr)
            Console.Write(x + " ");

        Console.WriteLine();
    }

    //==================================================
    // Main
    //==================================================
    static void Main()
    {
        int[] arr =
        {
            64,34,25,12,22,11,90,5,
            18,72,43,9,1,55,30,15,
            99,88,76,2,100,67,45,33
        };

        Console.WriteLine("Original Array:");

        PrintArray(arr);

        IntroSort(arr);

        Console.WriteLine("\nSorted Array:");

        PrintArray(arr);
    }
}