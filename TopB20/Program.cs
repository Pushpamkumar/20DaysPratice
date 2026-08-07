using System;

class Program
{
    // =========================================================
    // 1. HEAD RECURSION
    // =========================================================
    // The recursive call happens FIRST.
    // The work happens AFTER the recursive call returns.
    //
    // Pattern:
    // Recursion -> Work
    // =========================================================
    static void HeadRecursion(int n)
    {
        if (n <= 0)
            return;

        HeadRecursion(n - 1);

        Console.WriteLine(n);
    }


    // =========================================================
    // 2. TAIL RECURSION
    // =========================================================
    // The recursive call is the LAST operation.
    // There is no work left after the recursive call.
    //
    // Pattern:
    // Work -> Recursion
    // =========================================================
    static void TailRecursion(int n)
    {
        if (n <= 0)
            return;

        Console.WriteLine(n);

        TailRecursion(n - 1);
    }


    // =========================================================
    // 3. TREE RECURSION
    // =========================================================
    // The method makes MORE THAN ONE recursive call.
    //
    // Pattern:
    //          Method
    //          /    \
    //      Method  Method
    //
    // =========================================================
    static void TreeRecursion(int n)
    {
        if (n <= 0)
            return;

        Console.WriteLine(n);

        TreeRecursion(n - 1);
        TreeRecursion(n - 2);
    }


    // =========================================================
    // 4. INDIRECT RECURSION
    // =========================================================
    // One method calls another method,
    // and the second method calls the first method.
    //
    // Pattern:
    // A() -> B() -> A() -> B()
    // =========================================================
    static void MethodA(int n)
    {
        if (n <= 0)
            return;

        Console.WriteLine("A: " + n);

        MethodB(n - 1);
    }

    static void MethodB(int n)
    {
        if (n <= 0)
            return;

        Console.WriteLine("B: " + n);

        MethodA(n - 1);
    }


    // =========================================================
    // MAIN METHOD
    // =========================================================
    static void Main()
    {
        int n = 5;

        Console.WriteLine("HEAD RECURSION:");
        HeadRecursion(n);

        Console.WriteLine("\nTAIL RECURSION:");
        TailRecursion(n);

        Console.WriteLine("\nTREE RECURSION:");
        TreeRecursion(4);

        Console.WriteLine("\nINDIRECT RECURSION:");
        MethodA(n);
    }
}