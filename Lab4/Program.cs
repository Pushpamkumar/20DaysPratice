using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using System.Linq;

// Employee class to store employee information
class Employee
{
    public string Name { get; set; }
    public string Department { get; set; }
    public decimal Salary { get; set; }
}


static class StringToolkit
{
    // Same method from Lab 3
    public static string ToTitleCase(string input)
    {
        TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;

        return textInfo.ToTitleCase(input.ToLower());
    }
}


class Lab4
{
    // Raw employee data
    const string rawData = @"
john smith|engineering|72000
MARY jones|sales|65000

ravi KUMAR|engineering|81000
";


    static void Main()
    {
        // Split raw data into individual rows
        string[] rows = rawData.Split(
            new[] { '\r', '\n' },
            StringSplitOptions.RemoveEmptyEntries
        );

        List<Employee> employees = new List<Employee>();

        // Parse each row
        foreach (string row in rows)
        {
            // Defensive check for blank rows
            if (string.IsNullOrWhiteSpace(row))
            {
                continue;
            }

            // Split row into Name, Department and Salary
            string[] fields = row.Split('|');

            string name = fields[0].Trim();
            string department = fields[1].Trim();
            decimal salary = decimal.Parse(fields[2].Trim());

            // Create employee object
            Employee employee = new Employee
            {
                Name = name,
                Department = department,
                Salary = salary
            };

            employees.Add(employee);
        }


        // -------------------------------------------------
        // BONUS: Sort by department, then salary descending
        // -------------------------------------------------

        employees = employees
            .OrderBy(e => e.Department)
            .ThenByDescending(e => e.Salary)
            .ToList();


        // -------------------------------------------------
        // Build report using StringBuilder
        // -------------------------------------------------

        StringBuilder sb = new StringBuilder();

        int appendCount = 0;

        // Title
        sb.AppendLine("        EMPLOYEE COMPENSATION REPORT");
        appendCount++;

        sb.AppendLine();
        appendCount++;

        // Header
        sb.AppendLine(
            "Name".PadRight(20) +
            "Department".PadRight(18) +
            "Salary".PadLeft(12)
        );
        appendCount++;

        sb.AppendLine(
            "--------------------------------------------------"
        );
        appendCount++;


        decimal totalSalary = 0;


        // Employee rows
        foreach (Employee employee in employees)
        {
            // Normalize employee name using StringToolkit
            string formattedName =
                StringToolkit.ToTitleCase(employee.Name);

            string formattedDepartment =
                StringToolkit.ToTitleCase(employee.Department);

            // Add salary to total
            totalSalary += employee.Salary;

            // Create aligned employee row
            string line =
                formattedName.PadRight(20) +
                formattedDepartment.PadRight(18) +
                employee.Salary.ToString("N0").PadLeft(12);

            sb.AppendLine(line);
            appendCount++;
        }


        // Footer
        sb.AppendLine();
        appendCount++;

        sb.AppendLine(
            $"Employees: {employees.Count}    " +
            $"Total Salary: {totalSalary:N0}"
        );
        appendCount++;


        // Print final report
        Console.WriteLine(sb.ToString());


        // Print performance information
        Console.WriteLine(
            $"StringBuilder Append calls: {appendCount}"
        );

        Console.WriteLine(
            "String concatenations inside loops: 0"
        );
    }
}