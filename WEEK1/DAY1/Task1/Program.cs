// Summary: Order management tasks including delivered order display and order count.
// Demonstrates splitting records and conditional filtering on order status.
using System;

namespace StringHandlingAssignment
{
    class Program
    {
        static string[] orders =
        {
            "ORD1001|John Smith|Laptop|2|1200|Delivered",
            "ORD1002|Alice Johnson|Mobile Phone|1|800|Pending",
            "ORD1003|David Wilson|Headphones|3|150|Shipped",
            "ORD1004|Emma Brown|Monitor|2|300|Delivered",
            "ORD1005|James Miller|Keyboard|5|50|Cancelled"
        };

        static void Main(string[] args)
        {
            Console.WriteLine("========== ORDER MANAGEMENT ==========\n");

            // // Task 1
            // DisplayOrders();

            // Console.WriteLine("\n------------------------------------");

            // // Task 2
            // DisplayUpperCaseCustomers();

            // Console.ReadKey();

            Console.WriteLine("\n------------------------------------");
            DisplayOrder();
        
        }

        // // TASK 1 : Display All Order Details
        // static void DisplayOrders()
        // {
        //     Console.WriteLine("TASK 1 : Display All Order Details\n");

        //     foreach (string order in orders)
        //     {
        //         string[] data = order.Split('|');

        //         Console.WriteLine("Order ID : " + data[0]);
        //         Console.WriteLine("Customer : " + data[1]);
        //         Console.WriteLine("Product  : " + data[2]);
        //         Console.WriteLine("Quantity : " + data[3]);
        //         Console.WriteLine("Price    : $" + data[4]);
        //         Console.WriteLine("Status   : " + data[5]);
        //         Console.WriteLine();
        //     }
        // }

        // // TASK 2 : Convert Customer Names to Uppercase
        // static void DisplayUpperCaseCustomers()
        // {
        //     Console.WriteLine("TASK 2 : Customer Names in Uppercase\n");

        //     foreach (string order in orders)
        //     {
        //         string[] data = order.Split('|');

        //         Console.WriteLine(data[1].ToUpper());
        //     }
        // }

        // TASK 3 : Display Customer Initials
        // static void DisplayCustomerInitials()
        // {
        //     Console.WriteLine("TASK 3 : Display Customer Initials\n");

        //     foreach (string order in orders)
        //     {
        //         string[] data = order.Split('|');

        //         string[] names = data[1].Split(' ');

        //         string initials = "";

        //         foreach (string name in names)
        //         {
        //             initials += name.Substring(0, 1);
        //         }

        //         Console.WriteLine(data[1] + " -> " + initials);
        //     }
        // }

        //  task 4 : display order  only

        // TASK 4 : Display delivered order IDs and count total orders.
        static void DisplayOrder(){
            Console.WriteLine("Task 4\n");
            int c=0;

            Console.WriteLine("Delivered Orders: ");
            foreach( string order in orders){
                c++;
                string[] data= order.Split('|');
                if(data[data.Length-1]=="Delivered"){
                    Console.WriteLine(data[0]);
                }
            }

            Console.WriteLine("Task 5\n");
            Console.WriteLine("Order count is : "+ c);
        }


    }
}