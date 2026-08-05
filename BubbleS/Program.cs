using System;
using System.Diagnostics;

class SortingAlgorithms
{
    // Bubble Sort
    static void BubbleSort(int[] arr)
    {
        int n = arr.Length;

        for (int i = 0; i < n - 1; i++)
        {
            bool swapped = false;

            for (int j = 0; j < n - i - 1; j++)
            {
                if (arr[j] > arr[j + 1])
                {
                    int temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                    swapped = true;
                }
            }

            if (!swapped)
                break;
        }
    }

    // Insertion Sort
    static void InsertionSort(int[] arr)
    {
        int n = arr.Length;

        for (int i = 1; i < n; i++)
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

    // Selection Sort
    static void SelectionSort(int[] arr)
    {
        int n = arr.Length;

        for (int i = 0; i < n - 1; i++)
        {
            int minIndex = i;

            for (int j = i + 1; j < n; j++)
            {
                if (arr[j] < arr[minIndex])
                    minIndex = j;
            }

            int temp = arr[minIndex];
            arr[minIndex] = arr[i];
            arr[i] = temp;
        }
    }

    // Merge Sort
    static void MergeSort(int[] arr, int left, int right)
    {
        if (left < right)
        {
            int mid = (left + right) / 2;

            MergeSort(arr, left, mid);
            MergeSort(arr, mid + 1, right);

            Merge(arr, left, mid, right);
        }
    }

    static void Merge(int[] arr, int left, int mid, int right)
    {
        int n1 = mid - left + 1;
        int n2 = right - mid;

        int[] L = new int[n1];
        int[] R = new int[n2];

        for (int i = 0; i < n1; i++)
            L[i] = arr[left + i];

        for (int j = 0; j < n2; j++)
            R[j] = arr[mid + 1 + j];

        int a = 0, b = 0, k = left;

        while (a < n1 && b < n2)
        {
            if (L[a] <= R[b])
            {
                arr[k] = L[a];
                a++;
            }
            else
            {
                arr[k] = R[b];
                b++;
            }
            k++;
        }

        while (a < n1)
        {
            arr[k] = L[a];
            a++;
            k++;
        }

        while (b < n2)
        {
            arr[k] = R[b];
            b++;
            k++;
        }
    }

    // Quick Sort
    static void QuickSort(int[] arr, int low, int high)
    {
        if (low < high)
        {
            int pi = Partition(arr, low, high);

            QuickSort(arr, low, pi - 1);
            QuickSort(arr, pi + 1, high);
        }
    }

    static int Partition(int[] arr, int low, int high)
    {
        int pivot = arr[high];
        int i = low - 1;

        for (int j = low; j < high; j++)
        {
            if (arr[j] < pivot)
            {
                i++;

                int temp = arr[i];
                arr[i] = arr[j];
                arr[j] = temp;
            }
        }

        int t = arr[i + 1];
        arr[i + 1] = arr[high];
        arr[high] = t;

        return i + 1;
    }

    // Print Array
    static void PrintArray(int[] arr)
    {
        foreach (int num in arr)
            Console.Write(num + " ");

        Console.WriteLine();
    }

    static void Main()
    {
        // int[] original = { 64, 34, 25, 12, 22, 11, 90, 5, 18, 72 };
        Random random = new Random();
        int n = 100000;
        int[] original = new int[n];

        for (int i = 0; i < n; i++)
        {
            original[i] = random.Next(1, 1000000);
        }

        int[] bubble = (int[])original.Clone();
        int[] insertion = (int[])original.Clone();
        int[] selection = (int[])original.Clone();
        int[] merge = (int[])original.Clone();
        int[] quick = (int[])original.Clone();

        Stopwatch sw = new Stopwatch();

        // Bubble Sort
        sw.Start();
        BubbleSort(bubble);
        sw.Stop();
        Console.WriteLine("Bubble Sort:");
        // PrintArray(bubble);
        Console.WriteLine("Time = " + sw.ElapsedTicks + " ticks\n");

        // Insertion Sort
        sw.Restart();
        InsertionSort(insertion);
        sw.Stop();
        Console.WriteLine("Insertion Sort:");
        // PrintArray(insertion);
        Console.WriteLine("Time = " + sw.ElapsedTicks + " ticks\n");

        // Selection Sort
        sw.Restart();
        SelectionSort(selection);
        sw.Stop();
        Console.WriteLine("Selection Sort:");
        // PrintArray(selection);
        Console.WriteLine("Time = " + sw.ElapsedTicks + " ticks\n");

        // Merge Sort
        sw.Restart();
        MergeSort(merge, 0, merge.Length - 1);
        sw.Stop();
        Console.WriteLine("Merge Sort:");
        // PrintArray(merge);
        Console.WriteLine("Time = " + sw.ElapsedTicks + " ticks\n");

        // Quick Sort
        sw.Restart();
        QuickSort(quick, 0, quick.Length - 1);
        sw.Stop();
        Console.WriteLine("Quick Sort:");
        // PrintArray(quick);
        Console.WriteLine("Time = " + sw.ElapsedTicks + " ticks");
    }
}