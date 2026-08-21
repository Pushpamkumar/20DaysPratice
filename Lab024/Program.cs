using System;
using System.Collections.Generic;

// ================================================================
// LAB 4A - Balanced Parentheses
// ================================================================

public class Lab4
{
    // ============================================================
    // IsBalanced
    //
    // Stack<T> is ideal because parentheses must be checked in
    // Last-In-First-Out order.
    //
    // Example:
    // {[()]}
    //
    // The last opening bracket must be the first one matched.
    // ============================================================
    static bool IsBalanced(string expression)
    {
        Stack<char> stack = new Stack<char>();

        foreach (char character in expression)
        {
            // Opening brackets are pushed onto the stack.
            if (character == '(' ||
                character == '{' ||
                character == '[')
            {
                stack.Push(character);
            }

            // Closing brackets must match the latest opening bracket.
            else if (character == ')' ||
                     character == '}' ||
                     character == ']')
            {
                if (stack.Count == 0)
                {
                    return false;
                }

                char opening = stack.Pop();

                if (!IsMatchingPair(opening, character))
                {
                    return false;
                }
            }
        }

        // If stack is empty, every opening bracket was matched.
        return stack.Count == 0;
    }


    // ============================================================
    // IsMatchingPair
    // Checks whether an opening and closing bracket belong together.
    // ============================================================
    static bool IsMatchingPair(char opening, char closing)
    {
        return
            (opening == '(' && closing == ')') ||
            (opening == '{' && closing == '}') ||
            (opening == '[' && closing == ']');
    }


    // ============================================================
    // PrintJob
    // Represents one printer job.
    // ============================================================
    class PrintJob
    {
        public string DocumentName { get; set; }
        public int Pages { get; set; }
        public bool IsPriority { get; set; }

        public PrintJob(
            string documentName,
            int pages,
            bool isPriority = false)
        {
            DocumentName = documentName;
            Pages = pages;
            IsPriority = isPriority;
        }
    }


    // ============================================================
    // ProcessPrintQueue
    //
    // Queue<T> follows FIFO:
    // First-In-First-Out.
    //
    // However, a normal Queue cannot insert a priority job at
    // the front.
    //
    // Therefore we use TWO queues:
    // 1. priorityQueue
    // 2. normalQueue
    //
    // Priority jobs are always processed first.
    // ============================================================
    static void ProcessPrintQueue()
    {
        Queue<PrintJob> priorityQueue =
            new Queue<PrintJob>();

        Queue<PrintJob> normalQueue =
            new Queue<PrintJob>();


        // ========================================================
        // Add 5 normal jobs
        // ========================================================

        normalQueue.Enqueue(
            new PrintJob("Report.pdf", 10)
        );

        normalQueue.Enqueue(
            new PrintJob("Resume.docx", 5)
        );

        normalQueue.Enqueue(
            new PrintJob("Invoice.pdf", 3)
        );

        normalQueue.Enqueue(
            new PrintJob("Notes.txt", 7)
        );

        normalQueue.Enqueue(
            new PrintJob("Presentation.pptx", 20)
        );


        // ========================================================
        // Add a priority job
        // ========================================================

        priorityQueue.Enqueue(
            new PrintJob(
                "URGENT.pdf",
                2,
                true
            )
        );


        // ========================================================
        // Process all jobs
        // ========================================================

        while (
            priorityQueue.Count > 0 ||
            normalQueue.Count > 0)
        {
            Queue<PrintJob> activeQueue;

            // Priority jobs are processed first.
            if (priorityQueue.Count > 0)
            {
                activeQueue = priorityQueue;
            }
            else
            {
                activeQueue = normalQueue;
            }

            // Peek shows the next job without removing it.
            PrintJob nextJob = activeQueue.Peek();

            Console.WriteLine(
                $"Now printing next: " +
                $"{nextJob.DocumentName} " +
                $"({nextJob.Pages} pages)"
            );

            // Dequeue removes the job from the queue.
            PrintJob currentJob = activeQueue.Dequeue();

            Console.WriteLine(
                $"Printing {currentJob.DocumentName} " +
                $"({currentJob.Pages} pages)..."
            );
        }
    }


    public static void Main()
    {
        Console.WriteLine("========================================");
        Console.WriteLine("LAB 4 - STACK AND QUEUE");
        Console.WriteLine("========================================");


        // ========================================================
        // LAB 4A
        // ========================================================

        Console.WriteLine("\n--- 4A: Balanced Parentheses ---");

        string expression1 = "{[a+(b*c)]-d}";
        string expression2 = "{[(a+b)]";
        string expression3 = "(a+b]";

        Console.WriteLine(
            $"{expression1} -> {IsBalanced(expression1)}"
        );

        Console.WriteLine(
            $"{expression2} -> {IsBalanced(expression2)}"
        );

        Console.WriteLine(
            $"{expression3} -> {IsBalanced(expression3)}"
        );


        // ========================================================
        // LAB 4B
        // ========================================================

        Console.WriteLine("\n--- 4B: Print Queue ---");

        ProcessPrintQueue();
    }
}