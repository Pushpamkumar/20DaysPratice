using System;

class Program
{
    static int Factorial(int n, int accumulator = 1)
    {
        if (n <= 1)
            return accumulator;

        return Factorial(n - 1, accumulator * n);
    }

    static void Main()
    {
        Console.Write("Enter a number: ");
        int n = Convert.ToInt32(Console.ReadLine());

        int result = Factorial(n);

        Console.WriteLine("Factorial = " + result);
    }
}