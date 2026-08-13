using System;

class Program
{
    // =========================================================
    // TREE RECURSION - CountPaths
    // =========================================================
    // We can move only:
    // 1. Right  -> rows remain same, cols decrease
    // 2. Down   -> rows decrease, cols remain same
    //
    // Therefore, each call creates TWO recursive calls.
    // This makes it Tree Recursion.
    //
    // Example for CountPaths(3, 3):
    //
    //              (3,3)
    //             /     \
    //          (2,3)    (3,2)
    //          /  \      /  \
    //       (1,3)(2,2) (2,2)(3,1)
    //
    // =========================================================

    static int CountPaths(int rows, int cols)
    {
        // Base case:
        // If there is only one row or one column,
        // there is only ONE possible path.
        if (rows == 1 || cols == 1)
            return 1;

        // Tree recursion:
        // Move down + Move right
        return CountPaths(rows - 1, cols)
             + CountPaths(rows, cols - 1);
    }


    static void Main()
    {
        Console.Write("Enter number of rows: ");
        int rows = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter number of columns: ");
        int cols = Convert.ToInt32(Console.ReadLine());

        int result = CountPaths(rows, cols);

        Console.WriteLine("Number of paths = " + result);
    }
}