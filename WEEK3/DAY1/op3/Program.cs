using System;

public class TaxCalculator
{
    public virtual decimal CalculateTax(decimal amount)
    {
        return amount * 0.10m;
    }
}

public class RegionalTaxCalculator : TaxCalculator
{
    public sealed override decimal CalculateTax(decimal amount)
    {
        return amount * 0.12m;
    }
}

/*
    This will NOT compile.

    Because CalculateTax() was sealed in RegionalTaxCalculator,
    another derived class cannot override it.

public class InvalidTaxCalculator : RegionalTaxCalculator
{
    public override decimal CalculateTax(decimal amount)
    {
        return amount * 0.15m;
    }
}
*/

public sealed class FixedDiscountCalculator
{
    public decimal ApplyDiscount(decimal price)
    {
        return price * 0.90m;
    }
}

/*
    This will NOT compile.

public class InvalidDiscountCalculator : FixedDiscountCalculator
{
}
*/

class Program
{
    static void Main()
    {
        RegionalTaxCalculator regionalTax =
            new RegionalTaxCalculator();

        decimal tax = regionalTax.CalculateTax(200);

        Console.WriteLine(
            $"RegionalTaxCalculator.CalculateTax(200) -> {tax:F2}"
        );

        FixedDiscountCalculator discount =
            new FixedDiscountCalculator();

        decimal discountedPrice =
            discount.ApplyDiscount(50);

        Console.WriteLine(
            $"FixedDiscountCalculator.ApplyDiscount(50) -> {discountedPrice:F2}"
        );
    }
}