using System;

namespace EcommerceOrderManagement
{
    /// <summary>
    /// Demonstrates string handling operations
    /// using e-commerce order records.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Order Format:
        /// OrderID|Customer|Product|Category|Amount|Email
        /// </summary>
        static string[] orders =
        {
            "ORD001|John Smith|Laptop|Electronics|75000|john@gmail.com",
            "ORD002|Alice Johnson|Shoes|Fashion|2500|alice@gmail.com",
            "ORD003|David Wilson|Mobile|Electronics|35000|david@gmail.com",
            "ORD004|Emma Brown|Watch|Accessories|5000|emma@gmail.com",
            "ORD005|James Miller|T-Shirt|Fashion|1200|james@gmail.com"
        };

        /// <summary>
        /// Entry point of the application.
        /// </summary>
        static void Main(string[] args)
        {
            DisplayOrders();

            Console.WriteLine("\n---------------------------");
            DisplayCustomerNames();

            Console.WriteLine("\n---------------------------");
            DisplayElectronicsOrders();

            Console.WriteLine("\n---------------------------");
            CountOrders();

            Console.WriteLine("\n---------------------------");
            SearchOrder("ORD003");

            Console.WriteLine("\n---------------------------");
            ValidateEmails();

            Console.WriteLine("\n---------------------------");
            CalculateTotalAmount();

            Console.WriteLine("\n---------------------------");
            DisplayUpperCaseProducts();

            Console.WriteLine("\n---------------------------");
            ExtractEmailUserNames();

            Console.WriteLine("\n---------------------------");
            CountCategoryWiseOrders();
        }

        /// <summary>
        /// Displays all order details.
        /// </summary>
        static void DisplayOrders()
        {
            Console.WriteLine("Task 1 : Display Orders\n");

            foreach (string order in orders)
            {
                string[] data = order.Split('|');

                Console.WriteLine("Order ID : " + data[0]);
                Console.WriteLine("Customer : " + data[1]);
                Console.WriteLine("Product  : " + data[2]);
                Console.WriteLine("Category : " + data[3]);
                Console.WriteLine("Amount   : " + data[4]);
                Console.WriteLine("Email    : " + data[5]);
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Displays customer names.
        /// </summary>
        static void DisplayCustomerNames()
        {
            Console.WriteLine("Task 2 : Customer Names\n");

            foreach (string order in orders)
            {
                Console.WriteLine(order.Split('|')[1]);
            }
        }

        /// <summary>
        /// Displays Electronics category orders.
        /// </summary>
        static void DisplayElectronicsOrders()
        {
            Console.WriteLine("Task 3 : Electronics Orders\n");

            foreach (string order in orders)
            {
                string[] data = order.Split('|');

                if (data[3] == "Electronics")
                {
                    Console.WriteLine(data[2] + " - " + data[1]);
                }
            }
        }

        /// <summary>
        /// Displays total number of orders.
        /// </summary>
        static void CountOrders()
        {
            Console.WriteLine("Task 4 : Total Orders");
            Console.WriteLine("Total Orders = " + orders.Length);
        }

        /// <summary>
        /// Searches an order using Order ID.
        /// </summary>
        static void SearchOrder(string id)
        {
            Console.WriteLine("Task 5 : Search Order\n");

            bool found = false;

            foreach (string order in orders)
            {
                string[] data = order.Split('|');

                if (data[0] == id)
                {
                    Console.WriteLine("Order Found");
                    Console.WriteLine("Customer : " + data[1]);
                    Console.WriteLine("Product  : " + data[2]);
                    Console.WriteLine("Amount   : " + data[4]);
                    found = true;
                    break;
                }
            }

            if (!found)
                Console.WriteLine("Order Not Found");
        }

        /// <summary>
        /// Validates customer email addresses.
        /// </summary>
        static void ValidateEmails()
        {
            Console.WriteLine("Task 6 : Email Validation\n");

            foreach (string order in orders)
            {
                string email = order.Split('|')[5];

                bool valid = email.Contains("@") &&
                             email.Contains(".") &&
                             !email.Contains(" ");

                Console.WriteLine(email + " -> " + (valid ? "Valid" : "Invalid"));
            }
        }

        /// <summary>
        /// Calculates the total order amount.
        /// </summary>
        static void CalculateTotalAmount()
        {
            Console.WriteLine("Task 7 : Total Sales\n");

            int total = 0;

            foreach (string order in orders)
            {
                total += Convert.ToInt32(order.Split('|')[4]);
            }

            Console.WriteLine("Total Sales = ₹" + total);
        }

        /// <summary>
        /// Displays product names in uppercase.
        /// </summary>
        static void DisplayUpperCaseProducts()
        {
            Console.WriteLine("Task 8 : Uppercase Products\n");

            foreach (string order in orders)
            {
                Console.WriteLine(order.Split('|')[2].ToUpper());
            }
        }

        /// <summary>
        /// Extracts usernames from customer emails.
        /// </summary>
        static void ExtractEmailUserNames()
        {
            Console.WriteLine("Task 9 : Email Usernames\n");

            foreach (string order in orders)
            {
                string email = order.Split('|')[5];
                Console.WriteLine(email.Split('@')[0]);
            }
        }

        /// <summary>
        /// Counts orders by category.
        /// </summary>
        static void CountCategoryWiseOrders()
        {
            Console.WriteLine("Task 10 : Category Wise Orders\n");

            int electronics = 0;
            int fashion = 0;
            int accessories = 0;

            foreach (string order in orders)
            {
                string category = order.Split('|')[3];

                if (category == "Electronics")
                    electronics++;
                else if (category == "Fashion")
                    fashion++;
                else if (category == "Accessories")
                    accessories++;
            }

            Console.WriteLine("Electronics = " + electronics);
            Console.WriteLine("Fashion = " + fashion);
            Console.WriteLine("Accessories = " + accessories);
        }
    }
}