using System;

namespace StringHandlingAssignment
{
    /// <summary>
    /// Demonstrates various string handling operations on employee records.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Stores employee records in the format:
        /// ID|Name|Department|Email
        /// </summary>
        static string[] employees =
        {
            "EMP001|John Smith|IT|john.smith@company.com",
            "EMP002|Alice Johnson|HR|alice.johnson@company.com",
            "EMP003|David Wilson|Finance|david.wilson@company.com",
            "EMP004|Emma Brown|IT|emma.brown@company.com",
            "EMP005|James Miller|Sales|james.miller@company.com"
        };

        /// <summary>
        /// Entry point of the application.
        /// Executes all string handling tasks.
        /// </summary>
        static void Main(string[] args)
        {
            Console.WriteLine("========== STRING HANDLING ASSIGNMENT ==========\n");

            DisplayEmployees();

            Console.WriteLine("\n------------------------------------");
            DisplayUpperCaseNames();

            Console.WriteLine("\n------------------------------------");
            DisplayInitials();

            Console.WriteLine("\n------------------------------------");
            DisplayITEmployees();

            Console.WriteLine("\n------------------------------------");
            CountEmployees();

            Console.WriteLine("\n------------------------------------");
            SearchEmployee("EMP003");

            Console.WriteLine("\n------------------------------------");
            ValidateEmails();

            Console.WriteLine("\n------------------------------------");
            ReplaceDepartment();

            Console.WriteLine("\n------------------------------------");
            CountNameCharacters();

            Console.WriteLine("\n------------------------------------");
            ExtractEmailUserNames();

            Console.ReadKey();
        }

        /// <summary>
        /// Displays all employee details.
        /// </summary>
        static void DisplayEmployees()
        {
            Console.WriteLine("TASK 1 : Employee Details\n");

            foreach (string emp in employees)
            {
                string[] data = emp.Split('|');

                Console.WriteLine("Employee ID : " + data[0]);
                Console.WriteLine("Name        : " + data[1]);
                Console.WriteLine("Department  : " + data[2]);
                Console.WriteLine("Email       : " + data[3]);
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Displays employee names in uppercase.
        /// </summary>
        static void DisplayUpperCaseNames()
        {
            Console.WriteLine("TASK 2 : Uppercase Names\n");

            foreach (string emp in employees)
            {
                string[] data = emp.Split('|');
                Console.WriteLine(data[1].ToUpper());
            }
        }

        /// <summary>
        /// Displays the initials of each employee.
        /// </summary>
        static void DisplayInitials()
        {
            Console.WriteLine("TASK 3 : Employee Initials\n");

            foreach (string emp in employees)
            {
                string[] data = emp.Split('|');
                string[] names = data[1].Split(' ');
                string initials = "";

                foreach (string n in names)
                {
                    initials += n.Substring(0, 1);
                }

                Console.WriteLine(data[1] + " -> " + initials);
            }
        }

        /// <summary>
        /// Displays all employees from the IT department.
        /// </summary>
        static void DisplayITEmployees()
        {
            Console.WriteLine("TASK 4 : IT Department Employees\n");

            foreach (string emp in employees)
            {
                if (emp.Contains("|IT|"))
                {
                    Console.WriteLine(emp.Split('|')[1]);
                }
            }
        }

        /// <summary>
        /// Displays the total number of employees.
        /// </summary>
        static void CountEmployees()
        {
            Console.WriteLine("TASK 5 : Count Employees\n");
            Console.WriteLine("Total Employees = " + employees.Length);
        }

        /// <summary>
        /// Searches for an employee using the given ID.
        /// </summary>
        static void SearchEmployee(string id)
        {
            Console.WriteLine("TASK 6 : Search Employee\n");

            bool found = false;

            foreach (string emp in employees)
            {
                if (emp.StartsWith(id + "|"))
                {
                    string[] data = emp.Split('|');

                    Console.WriteLine("Employee Found");
                    Console.WriteLine("ID : " + data[0]);
                    Console.WriteLine("Name : " + data[1]);
                    Console.WriteLine("Department : " + data[2]);
                    Console.WriteLine("Email : " + data[3]);

                    found = true;
                    break;
                }
            }

            if (!found)
            {
                Console.WriteLine("Employee Not Found");
            }
        }

        /// <summary>
        /// Validates all employee email addresses.
        /// </summary>
        static void ValidateEmails()
        {
            Console.WriteLine("TASK 7 : Validate Emails\n");

            foreach (string emp in employees)
            {
                string[] data = emp.Split('|');

                bool isValid = data[3].Contains("@") &&
                               data[3].Contains(".") &&
                               !data[3].Contains(" ");

                Console.WriteLine(data[1] + " -> " + (isValid ? "Valid" : "Invalid"));
            }
        }

        /// <summary>
        /// Replaces "IT" with "Information Technology".
        /// </summary>
        static void ReplaceDepartment()
        {
            Console.WriteLine("TASK 8 : Replace Department\n");

            foreach (string emp in employees)
            {
                string[] data = emp.Split('|');

                string department = data[2] == "IT"
                    ? "Information Technology"
                    : data[2];

                Console.WriteLine(data[1] + " -> " + department);
            }
        }

        /// <summary>
        /// Counts characters in each employee's name
        /// excluding spaces.
        /// </summary>
        static void CountNameCharacters()
        {
            Console.WriteLine("TASK 9 : Count Name Characters\n");

            foreach (string emp in employees)
            {
                string name = emp.Split('|')[1];
                Console.WriteLine(name + " -> " + name.Replace(" ", "").Length);
            }
        }

        /// <summary>
        /// Extracts usernames from employee email addresses.
        /// </summary>
        static void ExtractEmailUserNames()
        {
            Console.WriteLine("TASK 10 : Extract Email Usernames\n");

            foreach (string emp in employees)
            {
                string email = emp.Split('|')[3];
                Console.WriteLine(email + " -> " + email.Split('@')[0]);
            }
        }
    }
}