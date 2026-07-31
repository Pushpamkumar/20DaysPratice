// Summary: Simple customer support ticket queue simulation.
// Displays the remaining tickets after dequeuing the front of the queue.
using System;

namespace CustomerSupportTicket
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] tickets =
            {
                "T001|John|Login Issue",
                "T002|Alice|Payment Failed",
                "T003|David|Account Locked",
                "T004|Emma|Refund Request",
                "T005|James|Password Reset"
            };

            // Console.WriteLine("Task 1: Enqueue Tickets");

            // for (int i = 0; i < tickets.Length; i++)
            // {
            //     string[] data = tickets[i].Split('|');
            //     Console.WriteLine(data[0]);
            // }

            // // task2

            // for (int i = 0; i < tickets.Length; i++)
            // {
            //     string[] data = tickets[i].Split('|');

            //     Console.WriteLine(data[0] + " " + data[1] + " " + data[2]);
            // }

            // // task 3
            // Console.WriteLine("Processing Ticket");
            // Console.WriteLine();

            // string[] data = tickets[0].Split('|');

            // Console.WriteLine(data[0] + " " + data[1] + " " + data[2]);


            // // task 4
            // int front = 1;   // T001 has already been processed

            // Console.WriteLine("Next Ticket");
            // Console.WriteLine();

            // string[] data = tickets[front].Split('|');

            // Console.WriteLine(data[0] + " " + data[1] + " " + data[2]);


            // // task 5

            // int front = 1;

            // int pendingTickets = tickets.Length - front;

            // Console.WriteLine("Pending Tickets = " + pendingTickets);


            // // task 6

            // Console.Write("Enter Ticket ID: ");
            // string searchId = Console.ReadLine();

            // bool found = false;

            // for (int i = 0; i < tickets.Length; i++)
            // {
            //     string[] data = tickets[i].Split('|');

            //     if (data[0] == searchId)
            //     {
            //         Console.WriteLine("\nTicket Found");
            //         Console.WriteLine("Customer : " + data[1]);
            //         Console.WriteLine("Issue : " + data[2]);
            //         found = true;
            //         break;
            //     }
            // }

            // if (!found)
            // {
            //     Console.WriteLine("Ticket Not Found");
            // }


            // //  task 7
            // int login = 0;
            // int payment = 0;
            // int refund = 0;

            // for (int i = 0; i < tickets.Length; i++)
            // {
            //     string[] data = tickets[i].Split('|');

            //     if (data[2] == "Login Issue")
            //         login++;
            //     else if (data[2] == "Payment Failed")
            //         payment++;
            //     else if (data[2] == "Refund Request")
            //         refund++;
            // }

            // Console.WriteLine("Login Issue = " + login);
            // Console.WriteLine("Payment Failed = " + payment);
            // Console.WriteLine("Refund Request = " + refund);



            // Task 8: Simulate processing all tickets in the queue and show any remaining tickets.
            int front=0;
            int rear= tickets.Length-1;

            while(front <= rear){
                front++;
            }
            Console.WriteLine("Display remaining queue");
            if(front> rear){
                Console.WriteLine("Queue is Empty");
            }else{
                for ( int i=front;i<= rear;i++){
                    string [] data= tickets[i].Split('|');
                    Console.WriteLine(data[0] +" "+ data[1]+" "+ data[2]);
                }
            }
        }
    }
}