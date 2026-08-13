using System;
using System.Collections.Generic;

/// <summary>
/// Represents a customer support ticket.
/// </summary>
class Ticket
{
    /// <summary>
    /// Ticket ID.
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    /// Customer name.
    /// </summary>
    public string Customer { get; set; }

    /// <summary>
    /// Issue type.
    /// </summary>
    public string Issue { get; set; }

    /// <summary>
    /// Initializes a new ticket.
    /// </summary>
    public Ticket(string id, string customer, string issue)
    {
        Id = id;
        Customer = customer;
        Issue = issue;
    }
}

/// <summary>
/// Entry point of the Customer Support Ticket Management application.
/// </summary>
class Program
{
    /// <summary>
    /// Main method of the application.
    /// Demonstrates all queue operations.
    /// </summary>
    static void Main()
    {
        Queue<Ticket> tickets = new Queue<Ticket>();

        // Task 1: Enqueue Tickets
        tickets.Enqueue(new Ticket("T001", "John", "Login Issue"));
        tickets.Enqueue(new Ticket("T002", "Alice", "Payment Failed"));
        tickets.Enqueue(new Ticket("T003", "David", "Account Locked"));
        tickets.Enqueue(new Ticket("T004", "Emma", "Refund Request"));
        tickets.Enqueue(new Ticket("T005", "James", "Password Reset"));

        // Task 2: Display All Tickets
        Console.WriteLine("Task 2: Display All Tickets\n");

        foreach (Ticket ticket in tickets)
        {
            Console.WriteLine($"{ticket.Id} | {ticket.Customer} | {ticket.Issue}");
        }

        // Task 3: Process First Ticket
        Console.WriteLine("\nTask 3: Process First Ticket");

        Ticket processed = tickets.Dequeue();

        Console.WriteLine($"Processed: {processed.Id} | {processed.Customer} | {processed.Issue}");

        // Task 4: View Next Ticket
        Console.WriteLine("\nTask 4: View Next Ticket");

        Ticket next = tickets.Peek();

        Console.WriteLine($"{next.Id} | {next.Customer} | {next.Issue}");

        // Task 5: Check Queue Count
        Console.WriteLine("\nTask 5: Queue Count");
        Console.WriteLine("Total Tickets: " + tickets.Count);

        // Task 6: Search Ticket by ID
        Console.WriteLine("\nTask 6: Search Ticket");

        string searchId = "T004";

        bool found = false;

        foreach (Ticket ticket in tickets)
        {
            if (ticket.Id.Equals(searchId, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Ticket Found");
                Console.WriteLine($"{ticket.Id} | {ticket.Customer} | {ticket.Issue}");
                found = true;
                break;
            }
        }

        if (!found)
        {
            Console.WriteLine("Ticket Not Found");
        }

        // Task 7: Count Tickets by Issue Type
        Console.WriteLine("\nTask 7: Count Tickets By Issue Type");

        Dictionary<string, int> issueCount = new Dictionary<string, int>();

        foreach (Ticket ticket in tickets)
        {
            if (issueCount.ContainsKey(ticket.Issue))
            {
                issueCount[ticket.Issue]++;
            }
            else
            {
                issueCount[ticket.Issue] = 1;
            }
        }

        foreach (var item in issueCount)
        {
            Console.WriteLine(item.Key + " = " + item.Value);
        }

        // Task 8: Remove All Processed Tickets
        Console.WriteLine("\nTask 8: Remove All Remaining Tickets");

        while (tickets.Count > 0)
        {
            Ticket removed = tickets.Dequeue();
            Console.WriteLine("Removed: " + removed.Id);
        }

        Console.WriteLine("\nRemaining Tickets: " + tickets.Count);
    }
}