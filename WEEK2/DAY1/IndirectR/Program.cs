using System;

class Program
{
    static void MethodA(int n)
    {
        if (n <= 0)
            return;

        Console.WriteLine("MethodA: " + n);

        MethodB(n - 1);
    }

    static void MethodB(int n)
    {
        if (n <= 0)
            return;

        Console.WriteLine("MethodB: " + n);

        MethodA(n - 1);
    }

    static void Main()
    {
        MethodA(5);
    }
}