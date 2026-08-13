using System;

/// <summary>
/// Simulates a simple browser history using a fixed-size stack.
/// Supports visiting pages, going back, viewing the current page,
/// displaying history, clearing history, and counting stored pages.
/// </summary>
class BrowserHistory
{
    /// <summary>
    /// Fixed-size array used to store visited web pages.
    /// </summary>
    private string[] history = new string[10];

    /// <summary>
    /// Points to the current page in the history.
    /// A value of -1 indicates that no pages have been visited.
    /// </summary>
    private int top = -1;

    /// <summary>
    /// Adds a new page to the browser history.
    /// </summary>
    /// <param name="page">The website or page name to visit.</param>
    public void VisitPage(string page)
    {
        // Check if the history is already full.
        if (top == history.Length - 1)
        {
            Console.WriteLine("History Full");
            return;
        }

        // Move to the next position and store the new page.
        history[++top] = page;

        Console.WriteLine("Visited: " + page);
    }

    /// <summary>
    /// Goes back to the previous page by removing
    /// the current page from the history.
    /// </summary>
    public void Back()
    {
        // Check if there are any pages in history.
        if (top == -1)
        {
            Console.WriteLine("No Pages in History");
            return;
        }

        Console.WriteLine("Back From: " + history[top--]);
    }

    /// <summary>
    /// Displays the page that is currently open.
    /// </summary>
    public void CurrentPage()
    {
        // Check whether any page exists.
        if (top == -1)
        {
            Console.WriteLine("No Current Page");
            return;
        }

        Console.WriteLine("Current Page: " + history[top]);
    }

    /// <summary>
    /// Displays all visited pages in reverse order,
    /// starting from the most recently visited page.
    /// </summary>
    public void DisplayHistory()
    {
        // Check whether history is empty.
        if (top == -1)
        {
            Console.WriteLine("History Empty");
            return;
        }

        Console.WriteLine("Browser History:");

        // Print history from newest to oldest.
        for (int i = top; i >= 0; i--)
        {
            Console.WriteLine(history[i]);
        }
    }

    /// <summary>
    /// Clears all browser history.
    /// </summary>
    public void ClearHistory()
    {
        // Reset the top pointer.
        top = -1;

        Console.WriteLine("History Cleared");
    }

    /// <summary>
    /// Displays the total number of stored pages.
    /// </summary>
    public void TotalPages()
    {
        Console.WriteLine("Total Pages: " + (top + 1));
    }
}

/// <summary>
/// Entry point of the Browser History application.
/// Displays a menu and performs user-selected operations.
/// </summary>
class Program
{
    /// <summary>
    /// Main method of the application.
    /// </summary>
    static void Main()
    {
        // Create a BrowserHistory object.
        BrowserHistory browser = new BrowserHistory();

        // Continue running until the user chooses Exit.
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

                    // Read the website name from the user.
                    Console.Write("Enter Website: ");
                    string? page = Console.ReadLine();

                    // Validate that the input is not empty.
                    if (!string.IsNullOrWhiteSpace(page))
                    {
                        browser.VisitPage(page);
                    }
                    else
                    {
                        Console.WriteLine("Invalid Website.");
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
                    Console.WriteLine("Thank You!");
                    return;

                default:
                    Console.WriteLine("Invalid Choice");
                    break;
            }
        }
    }
}