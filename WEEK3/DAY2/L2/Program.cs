using System;
using System.Collections.Generic;
using System.Linq;

// ---------------------------------------------------------
// 1. Abstract Base Class
// ---------------------------------------------------------

public abstract class NotificationChannel
{
    // Public concrete method.
    // It provides common error handling for all channels.
    public bool TrySend(string message)
    {
        try
        {
            // Calls the abstract Send() method.
            // The actual implementation depends on the child class.
            return Send(message);
        }
        catch
        {
            // If Send() throws any exception,
            // TrySend() returns false instead of crashing.
            return false;
        }
    }

    // Abstract method.
    // Every notification channel must implement its own
    // sending logic.
    protected abstract bool Send(string message);
}


// ---------------------------------------------------------
// 2. Email Channel
// ---------------------------------------------------------

public class EmailChannel : NotificationChannel
{
    // Email always succeeds in this example.
    protected override bool Send(string message)
    {
        return true;
    }
}


// ---------------------------------------------------------
// 3. SMS Channel
// ---------------------------------------------------------

public class SmsChannel : NotificationChannel
{
    protected override bool Send(string message)
    {
        // SMS has a maximum length of 160 characters.
        if (message.Length > 160)
        {
            // This exception will be caught by TrySend().
            throw new ArgumentException(
                "SMS message cannot exceed 160 characters."
            );
        }

        return true;
    }
}


// ---------------------------------------------------------
// 4. Main Driver
// ---------------------------------------------------------

public class Program
{
    public static void Main()
    {
        // Create a list using the abstract base class type.
        // It can contain both EmailChannel and SmsChannel objects.
        List<NotificationChannel> channels =
            new List<NotificationChannel>
            {
                new EmailChannel(),
                new EmailChannel(),
                new SmsChannel(),
                new SmsChannel()
            };


        // Short message - should succeed for both Email and SMS.
        string shortMessage =
            "Hello! Your order has been successfully processed.";

        // Long message - Email succeeds, SMS fails
        // because it exceeds 160 characters.
        string longMessage = new string('A', 200);


        // -----------------------------------------------------
        // Send short message
        // -----------------------------------------------------

        var shortResults = channels
            .Select(channel => new
            {
                ChannelType = channel.GetType().Name,
                Success = channel.TrySend(shortMessage)
            })
            .ToList();


        // -----------------------------------------------------
        // Send long message
        // -----------------------------------------------------

        var longResults = channels
            .Select(channel => new
            {
                ChannelType = channel.GetType().Name,
                Success = channel.TrySend(longMessage)
            })
            .ToList();


        // -----------------------------------------------------
        // Combine both anonymous-type sequences
        // -----------------------------------------------------

        var report = shortResults
            .Concat(longResults)
            .ToList();


        // -----------------------------------------------------
        // Print Report
        // -----------------------------------------------------

        Console.WriteLine("===== NOTIFICATION REPORT =====");

        foreach (var result in report)
        {
            Console.WriteLine(
                $"Channel: {result.ChannelType}, " +
                $"Success: {result.Success}"
            );
        }


        // -----------------------------------------------------
        // Count Successful and Failed Notifications
        // -----------------------------------------------------

        int successCount = report.Count(x => x.Success);

        int failedCount = report.Count(x => !x.Success);


        Console.WriteLine("\n===== SUMMARY =====");

        Console.WriteLine(
            $"Successful Notifications: {successCount}"
        );

        Console.WriteLine(
            $"Failed Notifications: {failedCount}"
        );
    }
}