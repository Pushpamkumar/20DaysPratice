// Summary: Hospital queue management example using a fixed-size array.
// Supports registering patients, calling the next patient, and searching the queue.
using System;

class HospitalQueue
{
    private string[] patients = new string[10];
    private int front = 0;
    private int rear = -1;

    // Register Patient
    public void RegisterPatient(string name)
    {
        if (rear == patients.Length - 1)
        {
            Console.WriteLine("Queue Full");
            return;
        }

        patients[++rear] = name;
        Console.WriteLine("Patient Registered: " + name);
    }

    // Call Next Patient
    public void CallNextPatient()
    {
        if (front > rear)
        {
            Console.WriteLine("No Patients Waiting");
            return;
        }

        Console.WriteLine("Calling: " + patients[front++]);
    }

    // View Next Patient
    public void ViewNextPatient()
    {
        if (front > rear)
        {
            Console.WriteLine("No Patients Waiting");
            return;
        }

        Console.WriteLine("Next Patient: " + patients[front]);
    }

    // Display Waiting Patients
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

    // Search Patient
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

        if (found)
            Console.WriteLine("Patient Found");
        else
            Console.WriteLine("Patient Not Found");
    }

    // Count Waiting Patients
    public void CountWaitingPatients()
    {
        Console.WriteLine("Total Waiting Patients: " + (rear - front + 1));
    }
}

class Program
{
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