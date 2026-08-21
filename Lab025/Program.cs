using System;
using System.Collections.Generic;
using System.Linq;

public class Lab5
{
    public static void Main()
    {
        Console.WriteLine("========================================");
        Console.WriteLine("LAB 5 - CUSTOMER OVERLAP ANALYZER");
        Console.WriteLine("========================================");


        // ============================================================
        // Create two sets of customers.
        //
        // HashSet<T> is ideal because:
        // - Duplicate values are automatically removed.
        // - Set operations such as Union, Intersection and
        //   Difference are directly supported.
        // ============================================================

        HashSet<string> newsletterSubscribers =
            new HashSet<string>(
                StringComparer.OrdinalIgnoreCase
            )
            {
                "alice@example.com",
                "bob@example.com",
                "charlie@example.com",
                "david@example.com",
                "emma@example.com"
            };


        HashSet<string> appUsers =
            new HashSet<string>(
                StringComparer.OrdinalIgnoreCase
            )
            {
                "bob@example.com",
                "charlie@example.com",
                "frank@example.com",
                "emma@example.com",
                "grace@example.com"
            };


        // ============================================================
        // INTERSECTION
        //
        // Customers who are BOTH newsletter subscribers and app users.
        //
        // IntersectWith modifies the current HashSet.
        // Therefore create a copy first.
        // ============================================================

        HashSet<string> both =
            new HashSet<string>(newsletterSubscribers);

        both.IntersectWith(appUsers);

        Console.WriteLine("\n--- Both Subscribers and App Users ---");

        foreach (string email in both)
        {
            Console.WriteLine(email);
        }


        // ============================================================
        // EXCEPT
        //
        // Customers who are subscribers but NOT app users.
        // ============================================================

        HashSet<string> subscribersOnly =
            new HashSet<string>(newsletterSubscribers);

        subscribersOnly.ExceptWith(appUsers);

        Console.WriteLine(
            "\n--- Subscribers but NOT App Users ---"
        );

        foreach (string email in subscribersOnly)
        {
            Console.WriteLine(email);
        }


        // ============================================================
        // UNION
        //
        // All unique customers from both collections.
        // ============================================================

        HashSet<string> allCustomers =
            new HashSet<string>(newsletterSubscribers);

        allCustomers.UnionWith(appUsers);

        Console.WriteLine(
            "\n--- All Unique Customers ---"
        );

        foreach (string email in allCustomers)
        {
            Console.WriteLine(email);
        }


        // ============================================================
        // SUBSET
        //
        // Checks whether every newsletter subscriber is also an
        // app user.
        // ============================================================

        bool isSubset =
            newsletterSubscribers.IsSubsetOf(appUsers);

        Console.WriteLine(
            $"\nNewsletter subscribers are subset of app users: " +
            $"{isSubset}"
        );


        // ============================================================
        // DUPLICATE REMOVAL
        //
        // Generate 100 emails with intentional duplicates.
        // HashSet automatically keeps only unique values.
        // ============================================================

        Console.WriteLine(
            "\n--- Duplicate Removal ---"
        );

        Random random = new Random(42);

        List<string> emailList =
            new List<string>();

        for (int i = 0; i < 100; i++)
        {
            // Only generate 50 possible emails,
            // so duplicates are intentionally created.
            int number = random.Next(1, 51);

            emailList.Add(
                $"customer{number}@example.com"
            );
        }


        // Convert List to HashSet to remove duplicates.
        HashSet<string> uniqueEmails =
            new HashSet<string>(emailList);

        int originalCount = emailList.Count;
        int uniqueCount = uniqueEmails.Count;
        int duplicatesRemoved =
            originalCount - uniqueCount;

        Console.WriteLine(
            $"Original emails: {originalCount}"
        );

        Console.WriteLine(
            $"Unique emails: {uniqueCount}"
        );

        Console.WriteLine(
            $"Duplicates removed: {duplicatesRemoved}"
        );
    }
}