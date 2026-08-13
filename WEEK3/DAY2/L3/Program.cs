using System;

// ---------------------------------------------------------
// 1. Base Class
// ---------------------------------------------------------

// TaxCalculator is NOT sealed.
// Therefore, other classes can inherit from it.
public class TaxCalculator
{
    // Virtual method can be overridden by derived classes.
    public virtual decimal CalculateTax(decimal amount)
    {
        return amount * 0.1m;
    }
}


// ---------------------------------------------------------
// 2. Regional Tax Calculator
// ---------------------------------------------------------

public class RegionalTaxCalculator : TaxCalculator
{
    // The method is overridden and sealed.
    // This means child classes can no longer override
    // CalculateTax().
    public sealed override decimal CalculateTax(decimal amount)
    {
        // Regional tax is 15%.
        return amount * 0.15m;
    }
}


// ---------------------------------------------------------
// 3. Invalid inheritance attempt
// ---------------------------------------------------------

// This class DOES inherit from RegionalTaxCalculator,
// which is allowed.
//
// However, trying to override CalculateTax() is NOT allowed
// because RegionalTaxCalculator sealed the override.

/*
public class InvalidTaxCalculator : RegionalTaxCalculator
{
    public override decimal CalculateTax(decimal amount)
    {
        return amount * 0.20m;
    }
}
*/

// Compiler error:
// 'InvalidTaxCalculator.CalculateTax(decimal)' cannot override
// inherited member 'RegionalTaxCalculator.CalculateTax(decimal)'
// because it is sealed.


// ---------------------------------------------------------
// 4. Completely sealed class
// ---------------------------------------------------------

// A sealed class cannot be inherited by any class.
public sealed class FixedDiscountCalculator
{
    public decimal ApplyDiscount(decimal price)
    {
        // Applies a 10% discount.
        return price * 0.9m;
    }
}


// ---------------------------------------------------------
// 5. Invalid inheritance from sealed class
// ---------------------------------------------------------

// This will NOT compile because FixedDiscountCalculator
// is completely sealed.

/*
public class InvalidDiscountCalculator : FixedDiscountCalculator
{
    // Compiler error:
    // 'InvalidDiscountCalculator': cannot derive from sealed type
    // 'FixedDiscountCalculator'
}
*/


// ---------------------------------------------------------
// 6. Driver
// ---------------------------------------------------------

public class Program
{
    public static void Main()
    {
        // Using RegionalTaxCalculator is completely allowed.
        RegionalTaxCalculator regionalTax =
            new RegionalTaxCalculator();

        decimal tax = regionalTax.CalculateTax(1000);

        Console.WriteLine(
            $"Regional Tax on 1000: {tax}"
        );


        // Using FixedDiscountCalculator is also allowed.
        FixedDiscountCalculator discountCalculator =
            new FixedDiscountCalculator();

        decimal discountedPrice =
            discountCalculator.ApplyDiscount(1000);

        Console.WriteLine(
            $"Discounted Price: {discountedPrice}"
        );
    }
}