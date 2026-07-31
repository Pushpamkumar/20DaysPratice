// Summary: Simple browser history simulator using a fixed-size stack-like history buffer.
// This program supports visiting pages, going back, viewing the current page, and displaying stored history.
using System;

class BrowserHistory
{
    private string[] history = new string[10];
    private int top = -1;

    // Visit a new page
    // Add a new page to the browser history.
    public void VisitPage(string page)
    {
        if (top == history.Length - 1)
        {
            Console.WriteLine("History Full");
            return;
        }

        history[++top] = page;
        Console.WriteLine("Visited: " + page);
    }

    // Back
    public void Back()
    {
        if (top == -1)
        {
            Console.WriteLine("No Pages in History");
            return;
        }

        Console.WriteLine("Back From: " + history[top--]);
    }

    // Current Page
    public void CurrentPage()
    {
        if (top == -1)
        {
            Console.WriteLine("No Current Page");
            return;
        }

        Console.WriteLine("Current Page: " + history[top]);
    }

    // Display History
    public void DisplayHistory()
    {
        if (top == -1)
        {
            Console.WriteLine("History Empty");
            return;
        }

        Console.WriteLine("Browser History:");

        for (int i = top; i >= 0; i--)
        {
            Console.WriteLine(history[i]);
        }
    }

    // Clear History
    public void ClearHistory()
    {
        top = -1;
        Console.WriteLine("History Cleared");
    }

    // Total Pages
    public void TotalPages()
    {
        Console.WriteLine("Total Pages: " + (top + 1));
    }
}

class Program
{
    static void Main()
    {
        // Main loop presents a menu to the user and performs browser history operations.
        BrowserHistory browser = new BrowserHistory();

        while (true)
        {
            Console.WriteLine("\n=================================");
            Console.WriteLine("Browser History System");
            Console.WriteLine("=================================");
            Console.WriteLine("1. Visit Page");
            Console.WriteLine("2. Back");
            Console.WriteLine("3. Current Page");
            Console.WriteLine("4. Display History");
            Console.WriteLine("5. Clear History");
            Console.WriteLine("6. Total Pages");
            Console.WriteLine("7. Exit");

            Console.Write("Enter Choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    // Console.Write("Enter Website: ");
                    // string page = Console.ReadLine();
                    // browser.VisitPage(page);

                    Console.Write("Enter Website: ");
                    string? page = Console.ReadLine();

                    if (!string.IsNullOrWhiteSpace(page))
                    {
                        browser.VisitPage(page);
                    }
                    else
                    {
                        Console.WriteLine("Invalid website.");
                    }
                    break;

                case 2:
                    browser.Back();
                    break;

                case 3:
                    browser.CurrentPage();
                    break;

                case 4:
                    browser.DisplayHistory();
                    break;

                case 5:
                    browser.ClearHistory();
                    break;

                case 6:
                    browser.TotalPages();
                    break;

                case 7:
                    Console.WriteLine("Thank You");
                    return;

                default:
                    Console.WriteLine("Invalid Choice");
                    break;
            }
        }
    }
}