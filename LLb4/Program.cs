using System;
using System.Collections.Generic;

public abstract class Employee
{
    public string Name { get; }

    public decimal BaseSalary { get; }

    protected Employee(string name, decimal baseSalary)
    {
        Name = name;
        BaseSalary = baseSalary;
    }

    public abstract decimal CalculatePay();

    public void PrintPaySlip()
    {
        Console.WriteLine(
            $"{Name}: {CalculatePay():C}"
        );
    }
}

public class SalariedEmployee : Employee
{
    public SalariedEmployee(
        string name,
        decimal baseSalary)
        : base(name, baseSalary)
    {
    }

    public override decimal CalculatePay()
    {
        return BaseSalary;
    }
}

public class CommissionEmployee : Employee
{
    public decimal CommissionEarned;

    public CommissionEmployee(
        string name,
        decimal baseSalary,
        decimal commission)
        : base(name, baseSalary)
    {
        CommissionEarned = commission;
    }

    public override decimal CalculatePay()
    {
        return BaseSalary + CommissionEarned;
    }
}

class Program
{
    static void Main()
    {
        List<Employee> employees = new List<Employee>
        {
            new SalariedEmployee("Alice", 4500m),

            new SalariedEmployee("Bob", 3200m),

            new CommissionEmployee(
                "Carla",
                3500m,
                650m)
        };

        foreach (Employee employee in employees)
        {
            employee.PrintPaySlip();
        }
    }
}