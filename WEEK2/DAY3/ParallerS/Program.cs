using System;
using System.Threading.Tasks;

class ParallelQuickSortProgram
{
    // Threshold to avoid creating too many tasks
    const int THRESHOLD = 10000;

    //=====================================================
    // Parallel Quick Sort
    //=====================================================
    static void ParallelQuickSort(int[] arr, int low, int high)
    {
        if (low >= high)
            return;

        int pivot = Partition(arr, low, high);

        // Small partition -> normal Quick Sort
        if (high - low < THRESHOLD)
        {
            QuickSort(arr, low, pivot - 1);
            QuickSort(arr, pivot + 1, high);
        }
        else
        {
            Parallel.Invoke(
                () => ParallelQuickSort(arr, low, pivot - 1),
                () => ParallelQuickSort(arr, pivot + 1, high)
            );
        }
    }

    //=====================================================
    // Normal Quick Sort
    //=====================================================
    static void QuickSort(int[] arr, int low, int high)
    {
        if (low < high)
        {
            int pivot = Partition(arr, low, high);

            QuickSort(arr, low, pivot - 1);
            QuickSort(arr, pivot + 1, high);
        }
    }

    //=====================================================
    // Partition
    //=====================================================
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

    //=====================================================
    // Swap
    //=====================================================
    static void Swap(int[] arr, int i, int j)
    {
        int temp = arr[i];
        arr[i] = arr[j];
        arr[j] = temp;
    }

    //=====================================================
    // Print
    //=====================================================
    static void PrintArray(int[] arr)
    {
        foreach (int x in arr)
            Console.Write(x + " ");

        Console.WriteLine();
    }

    //=====================================================
    // Main
    //=====================================================
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

        ParallelQuickSort(arr, 0, arr.Length - 1);

        Console.WriteLine("\nSorted Array:");

        PrintArray(arr);
    }
}