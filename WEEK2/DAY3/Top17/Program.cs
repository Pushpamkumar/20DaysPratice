using System;
using System.Collections.Generic;
using System.Linq;

namespace OrganizationHierarchyManagement
{
    // Employee Class
    class Employee
    {
        public int Id;
        public string Name;
        public string Designation;
        public string Department;
        public int ManagerId;

        public Employee(int id, string name, string designation, string department, int managerId)
        {
            Id = id;
            Name = name;
            Designation = designation;
            Department = department;
            ManagerId = managerId;
        }
    }

    class Program
    {
        // Employee List
        static List<Employee> employees = new List<Employee>
        {
            new Employee(1001, "John Smith", "CEO", "Management", 0),
            new Employee(1002, "Michael Johnson", "IT Manager", "IT", 1001),
            new Employee(1003, "Sarah Williams", "HR Manager", "HR", 1001),
            new Employee(1004, "David Brown", "Finance Manager", "Finance", 1001),
            new Employee(1005, "Robert Davis", "Team Lead", "IT", 1002),
            new Employee(1006, "Jennifer Miller", "QA Lead", "IT", 1002),
            new Employee(1007, "William Wilson", "Senior Developer", "IT", 1005),
            new Employee(1008, "Emma Moore", "Senior Developer", "IT", "1005".Length == 4 ? 1005 : 1005),
            new Employee(1009, "Daniel Taylor", "QA Engineer", "IT", 1006),
            new Employee(1010, "Sophia Anderson", "QA Engineer", "IT", 1006),
            new Employee(1011, "James Thomas", "Recruiter", "HR", 1003),
            new Employee(1012, "Olivia Jackson", "Recruiter", "HR", 1003),
            new Employee(1013, "Benjamin White", "Accountant", "Finance", 1004),
            new Employee(1014, "Charlotte Harris", "Accountant", "Finance", 1004),
            new Employee(1015, "Lucas Martin", "Developer", "IT", 1007),
            new Employee(1016, "Ethan Walker", "Developer", "IT", 1007),
            new Employee(1017, "Mia Hall", "UI Developer", "IT", 1008),
            new Employee(1018, "Alexander Young", "Business Analyst", "IT", 1005),
            new Employee(1019, "Harper King", "HR Executive", "HR", 1011),
            new Employee(1020, "Jack Scott", "Finance Executive", "Finance", 1013)
        };

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine("==========================================");
                Console.WriteLine("ABC TECHNOLOGIES");
                Console.WriteLine("Organization Hierarchy Management System");
                Console.WriteLine("==========================================");
                Console.WriteLine();

                Console.WriteLine("1. Display Complete Organization Chart");
                Console.WriteLine("2. Find Employee by ID");
                Console.WriteLine("3. Find Employee by Name");
                Console.WriteLine("4. Display Employees under a Manager");
                Console.WriteLine("5. Count Total Employees under a Manager");
                Console.WriteLine("6. Display Hierarchy Level");
                Console.WriteLine("7. Exit");
                Console.Write("\nEnter Your Choice : ");

                int choice = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine();

                switch (choice)
                {
                    case 1:
                        DisplayOrganization();
                        break;

                    case 2:
                        FindEmployeeById();
                        break;

                    case 3:
                        FindEmployeeByName();
                        break;

                    case 4:
                        DisplayEmployeesUnderManager();
                        break;

                    case 5:
                        CountEmployeesUnderManager();
                        break;

                    case 6:
                        DisplayHierarchyLevel();
                        break;

                    case 7:
                        return;

                    default:
                        Console.WriteLine("Invalid Choice!");
                        break;
                }

                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
        }

        //=========================================================
        // 1. Display Complete Organization Chart (Recursion)
        //=========================================================
        static void DisplayOrganization()
        {
            Employee ceo = employees.FirstOrDefault(e => e.ManagerId == 0);

            Console.WriteLine("Organization Hierarchy\n");
            DisplayHierarchy(ceo.Id, 0);
        }

        // Recursive Function
        static void DisplayHierarchy(int managerId, int level)
        {
            Employee manager = employees.First(e => e.Id == managerId);

            Console.WriteLine(new string(' ', level * 4) +
                              manager.Name + " (" + manager.Designation + ")");

            var subordinates = employees.Where(e => e.ManagerId == managerId);

            foreach (var emp in subordinates)
            {
                DisplayHierarchy(emp.Id, level + 1);
            }
        }

        //=========================================================
        // 2. Find Employee by ID
        //=========================================================
        static void FindEmployeeById()
        {
            Console.Write("Enter Employee ID : ");
            int id = Convert.ToInt32(Console.ReadLine());

            Employee emp = employees.FirstOrDefault(e => e.Id == id);

            if (emp != null)
            {
                Console.WriteLine("\nEmployee Found");
                Console.WriteLine("-----------------------");
                Console.WriteLine("ID          : " + emp.Id);
                Console.WriteLine("Name        : " + emp.Name);
                Console.WriteLine("Designation : " + emp.Designation);
                Console.WriteLine("Department  : " + emp.Department);
            }
            else
            {
                Console.WriteLine("Employee Not Found.");
            }
        }

        //=========================================================
        // 3. Find Employee by Name
        //=========================================================
        static void FindEmployeeByName()
        {
            Console.Write("Enter Employee Name : ");
            string name = Console.ReadLine();

            Employee emp = employees.FirstOrDefault(e =>
                e.Name.ToLower().Contains(name.ToLower()));

            if (emp != null)
            {
                Console.WriteLine("\nEmployee Found");
                Console.WriteLine("-----------------------");
                Console.WriteLine("ID          : " + emp.Id);
                Console.WriteLine("Name        : " + emp.Name);
                Console.WriteLine("Designation : " + emp.Designation);
                Console.WriteLine("Department  : " + emp.Department);
            }
            else
            {
                Console.WriteLine("Employee Not Found.");
            }
        }

        //=========================================================
        // 4. Display Employees Under Manager (Recursion)
        //=========================================================
        static void DisplayEmployeesUnderManager()
        {
            Console.Write("Enter Manager ID : ");
            int id = Convert.ToInt32(Console.ReadLine());

            Employee manager = employees.FirstOrDefault(e => e.Id == id);

            if (manager == null)
            {
                Console.WriteLine("Manager Not Found.");
                return;
            }

            Console.WriteLine("\nEmployees under " + manager.Name);

            DisplaySubordinates(id, 1);
        }

        static void DisplaySubordinates(int managerId, int level)
        {
            var list = employees.Where(e => e.ManagerId == managerId);

            foreach (var emp in list)
            {
                Console.WriteLine(new string(' ', level * 4) + emp.Name);

                // Recursive Call
                DisplaySubordinates(emp.Id, level + 1);
            }
        }

        //=========================================================
        // 5. Count Employees Under Manager (Recursion)
        //=========================================================
        static void CountEmployeesUnderManager()
        {
            Console.Write("Enter Manager ID : ");
            int id = Convert.ToInt32(Console.ReadLine());

            Employee manager = employees.FirstOrDefault(e => e.Id == id);

            if (manager == null)
            {
                Console.WriteLine("Manager Not Found.");
                return;
            }

            int total = CountSubordinates(id);

            Console.WriteLine("\nTotal Employees under "
                + manager.Name + " : " + total);
        }

        static int CountSubordinates(int managerId)
        {
            int count = 0;

            var list = employees.Where(e => e.ManagerId == managerId);

            foreach (var emp in list)
            {
                count++;

                // Recursive Call
                count += CountSubordinates(emp.Id);
            }

            return count;
        }

        //=========================================================
        // 6. Display Hierarchy Level
        //=========================================================
        static void DisplayHierarchyLevel()
        {
            Console.Write("Enter Employee ID : ");
            int id = Convert.ToInt32(Console.ReadLine());

            Employee emp = employees.FirstOrDefault(e => e.Id == id);

            if (emp == null)
            {
                Console.WriteLine("Employee Not Found.");
                return;
            }

            int level = 0;

            while (emp.ManagerId != 0)
            {
                level++;

                emp = employees.First(e => e.Id == emp.ManagerId);
            }

            Console.WriteLine("Hierarchy Level : " + level);
        }
    }
}