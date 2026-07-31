using System;

/// <summary>
/// Represents a simple hospital queue management system.
/// Supports patient registration, calling patients,
/// viewing the next patient, searching, and counting waiting patients.
/// </summary>
class HospitalQueue
{
    /// <summary>
    /// Stores patient names in the queue.
    /// </summary>
    private string[] patients = new string[10];

    /// <summary>
    /// Points to the first patient in the queue.
    /// </summary>
    private int front = 0;

    /// <summary>
    /// Points to the last patient in the queue.
    /// </summary>
    private int rear = -1;

    /// <summary>
    /// Registers a new patient in the queue.
    /// </summary>
    /// <param name="name">Patient name.</param>
    public void RegisterPatient(string name)
    {
        // Check if the queue is full.
        if (rear == patients.Length - 1)
        {
            Console.WriteLine("Queue Full");
            return;
        }

        patients[++rear] = name;
        Console.WriteLine("Patient Registered: " + name);
    }

    /// <summary>
    /// Calls the next patient from the queue.
    /// </summary>
    public void CallNextPatient()
    {
        if (front > rear)
        {
            Console.WriteLine("No Patients Waiting");
            return;
        }

        Console.WriteLine("Calling: " + patients[front++]);
    }

    /// <summary>
    /// Displays the next patient in the queue.
    /// </summary>
    public void ViewNextPatient()
    {
        if (front > rear)
        {
            Console.WriteLine("No Patients Waiting");
            return;
        }

        Console.WriteLine("Next Patient: " + patients[front]);
    }

    /// <summary>
    /// Displays all waiting patients.
    /// </summary>
    public void DisplayWaitingPatients()
    {
        if (front > rear)
        {
            Console.WriteLine("No Patients Waiting");
            return;
        }

        Console.WriteLine("Waiting Patients:");

        for (int i = front; i <= rear; i++)
        {
            Console.WriteLine(patients[i]);
        }
    }

    /// <summary>
    /// Searches for a patient by name.
    /// </summary>
    /// <param name="name">Patient name to search.</param>
    public void SearchPatient(string name)
    {
        if (front > rear)
        {
            Console.WriteLine("No Patients Waiting");
            return;
        }

        bool found = false;

        for (int i = front; i <= rear; i++)
        {
            if (patients[i].Equals(name, StringComparison.OrdinalIgnoreCase))
            {
                found = true;
                break;
            }
        }

        Console.WriteLine(found ? "Patient Found" : "Patient Not Found");
    }

    /// <summary>
    /// Displays the total number of waiting patients.
    /// </summary>
    public void CountWaitingPatients()
    {
        Console.WriteLine("Total Waiting Patients: " + (rear - front + 1));
    }
}

/// <summary>
/// Entry point of the Hospital Queue Management application.
/// Displays a menu and performs queue operations.
/// </summary>
class Program
{
    /// <summary>
    /// Main method of the application.
    /// </summary>
    static void Main()
    {
        HospitalQueue hospital = new HospitalQueue();

        while (true)
        {
            Console.WriteLine("\n====================================");
            Console.WriteLine("ABC Hospital Queue Management System");
            Console.WriteLine("====================================");
            Console.WriteLine("1. Register Patient");
            Console.WriteLine("2. Call Next Patient");
            Console.WriteLine("3. View Next Patient");
            Console.WriteLine("4. Display Waiting Patients");
            Console.WriteLine("5. Search Patient");
            Console.WriteLine("6. Count Waiting Patients");
            Console.WriteLine("7. Exit");

            Console.Write("Enter Choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Enter Patient Name: ");
                    string? name = Console.ReadLine();

                    if (!string.IsNullOrWhiteSpace(name))
                    {
                        hospital.RegisterPatient(name);
                    }
                    else
                    {
                        Console.WriteLine("Invalid Name");
                    }
                    break;

                case 2:
                    hospital.CallNextPatient();
                    break;

                case 3:
                    hospital.ViewNextPatient();
                    break;

                case 4:
                    hospital.DisplayWaitingPatients();
                    break;

                case 5:
                    Console.Write("Enter Patient Name to Search: ");
                    string? search = Console.ReadLine();

                    if (!string.IsNullOrWhiteSpace(search))
                    {
                        hospital.SearchPatient(search);
                    }
                    else
                    {
                        Console.WriteLine("Invalid Name");
                    }
                    break;

                case 6:
                    hospital.CountWaitingPatients();
                    break;

                case 7:
                    Console.WriteLine("Thank You");
                    return;

                default:
                    Console.WriteLine("Invalid Choice");
                    break;
            }
        }
    }
}