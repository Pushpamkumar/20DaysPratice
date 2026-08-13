using System;
using System.Collections.Generic;
using System.Linq;

// ---------------------------------------------------------
// 1. Base interface
// ---------------------------------------------------------

// Any identifiable payment method must provide an Id.
public interface IIdentifiable
{
    string Id { get; }
}


// ---------------------------------------------------------
// 2. Payment method interface
// ---------------------------------------------------------

// IPaymentMethod inherits Id from IIdentifiable.
// It also defines payment-specific members.
public interface IPaymentMethod : IIdentifiable
{
    string DisplayName { get; }

    PaymentResult Charge(decimal amount);
}


// ---------------------------------------------------------
// 3. Encapsulated PaymentResult class
// ---------------------------------------------------------

public class PaymentResult
{
    // Read-only properties
    public bool Success { get; }
    public string Message { get; }

    public PaymentResult(bool success, string message)
    {
        // Message cannot be null
        if (message == null)
        {
            throw new ArgumentNullException(nameof(message));
        }

        Success = success;
        Message = message;
    }
}


// ---------------------------------------------------------
// 4. Abstract base class
// ---------------------------------------------------------

// This class provides common implementation for all
// payment methods while leaving Charge() to subclasses.
public abstract class PaymentMethodBase : IPaymentMethod
{
    // Concrete auto-properties from the interface
    public string Id { get; }

    public string DisplayName { get; }

    // Protected constructor
    // Only derived classes can call this constructor.
    protected PaymentMethodBase(string id, string displayName)
    {
        Id = id;
        DisplayName = displayName;
    }

    // Abstract method
    // Every payment method must provide its own implementation.
    public abstract PaymentResult Charge(decimal amount);
}


// ---------------------------------------------------------
// 5. Credit Card Payment
// ---------------------------------------------------------

public class CreditCardPayment : PaymentMethodBase
{
    public CreditCardPayment(string id, string displayName)
        : base(id, displayName)
    {
    }

    public override PaymentResult Charge(decimal amount)
    {
        // Basic amount validation
        if (amount <= 0)
        {
            return new PaymentResult(
                false,
                "Amount must be greater than zero."
            );
        }

        // Credit card payment fails for amounts over 5000
        if (amount > 5000)
        {
            return new PaymentResult(
                false,
                "Credit card limit exceeded."
            );
        }

        return new PaymentResult(
            true,
            "Credit card payment successful."
        );
    }
}


// ---------------------------------------------------------
// 6. Cash Payment
// ---------------------------------------------------------

// sealed means no other class can inherit from CashPayment.
public sealed class CashPayment : PaymentMethodBase
{
    public CashPayment(string id, string displayName)
        : base(id, displayName)
    {
    }

    public override PaymentResult Charge(decimal amount)
    {
        // Cash payment always succeeds for a positive amount.
        if (amount <= 0)
        {
            return new PaymentResult(
                false,
                "Amount must be greater than zero."
            );
        }

        return new PaymentResult(
            true,
            "Cash payment successful."
        );
    }
}


// ---------------------------------------------------------
// 7. Main Driver
// ---------------------------------------------------------

public class Program
{
    public static void Main()
    {
        // List uses the interface type.
        // Therefore, different payment implementations
        // can be stored in the same collection.
        List<IPaymentMethod> paymentMethods =
            new List<IPaymentMethod>
            {
                new CreditCardPayment(
                    "CC001",
                    "Visa Credit Card"
                ),

                new CreditCardPayment(
                    "CC002",
                    "MasterCard"
                ),

                new CashPayment(
                    "CASH001",
                    "Cash"
                )
            };

        // Amounts that we want to charge
        decimal[] amounts =
        {
            3000m,
            7000m
        };

        // List used to store the results temporarily.
        var settlementData =
            new List<(string Id, string DisplayName,
                      decimal Amount, bool Success)>();

        // Charge every payment method with both amounts.
        foreach (IPaymentMethod paymentMethod in paymentMethods)
        {
            foreach (decimal amount in amounts)
            {
                PaymentResult result =
                    paymentMethod.Charge(amount);

                Console.WriteLine(
                    $"{paymentMethod.DisplayName} | " +
                    $"Amount: {amount} | " +
                    $"Success: {result.Success} | " +
                    $"Message: {result.Message}"
                );

                settlementData.Add(
                    (
                        paymentMethod.Id,
                        paymentMethod.DisplayName,
                        amount,
                        result.Success
                    )
                );
            }
        }


        // -----------------------------------------------------
        // 8. Anonymous-type LINQ projection
        // -----------------------------------------------------

        // We create an anonymous type instead of creating
        // a separate SettlementReport class.
        var settlementReport = settlementData
            .Select(x => new
            {
                Id = x.Id,
                DisplayName = x.DisplayName,
                AmountAttempted = x.Amount,
                Success = x.Success
            })
            .ToList();


        // -----------------------------------------------------
        // 9. Print Settlement Report
        // -----------------------------------------------------

        Console.WriteLine("\n===== SETTLEMENT REPORT =====");

        foreach (var report in settlementReport)
        {
            Console.WriteLine(
                $"Id: {report.Id}, " +
                $"Name: {report.DisplayName}, " +
                $"Amount: {report.AmountAttempted}, " +
                $"Success: {report.Success}"
            );
        }


        // -----------------------------------------------------
        // 10. Calculate successfully settled amount
        // -----------------------------------------------------

        decimal totalSettledAmount =
            settlementReport
                .Where(x => x.Success)
                .Sum(x => x.AmountAttempted);

        Console.WriteLine(
            $"\nTotal Successfully Settled Amount: " +
            $"{totalSettledAmount}"
        );
    }
}