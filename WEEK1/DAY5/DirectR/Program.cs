using System;

class Program
{
    static int Factorial(int n)
    {
        if (n == 0 || n == 1)   // Base case
            return 1;

        return n * Factorial(n - 1);   // Recursive call
    }

    static void Main()
    {
        int num = 5;
        Console.WriteLine("Factorial of " + num + " = " + Factorial(num));
    }
}