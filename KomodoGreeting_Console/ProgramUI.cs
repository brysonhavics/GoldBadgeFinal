using KomodoGreeting_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KomodoGreeting_Console
{
    public class ProgramUI
    {
        private CustomerRepository customerRepository = new CustomerRepository();
        public void Run()
        {
            SeedContent();

            Menu();
        }

        public void SeedContent()
        {
            Customer customer1 = new Customer("Mitchell", "Price", CustomerType.Current);
            Customer customer2 = new Customer("Bryson", "Havics", CustomerType.Past);
            Customer customer3 = new Customer("Ezra", "Davis", CustomerType.Potential);

            customerRepository.AddCustomer(customer1);
            customerRepository.AddCustomer(customer2);
            customerRepository.AddCustomer(customer3);
        }

        public void Menu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();

                Console.WriteLine("Menu:\n" +
                    "1. Show all customers\n" +
                    "2. Create customer\n" +
                    "3. Update customer\n" +
                    "4. Delete customer\n" +
                    "5. Exit");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        customerRepository.DisplayCustomers();
                        Console.WriteLine("\nPress any key to continue...");
                        Console.ReadKey();
                        break;
                    case "2":
                        CreateCustomer();
                        Console.WriteLine("\nPress any key to continue...");
                        Console.ReadKey();                        
                        break;
                    case "3":
                        UpdateCustomer();
                        Console.WriteLine("\nPress any key to continue...");
                        Console.ReadKey();
                        break;
                    case "4":
                        DeleteCustomer();
                        Console.WriteLine("\nPress any key to continue...");
                        Console.ReadKey();
                        break;
                    case "exit":
                    case "EXIT":
                    case "5":
                        continueToRun = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid selection\n" +
                            "Press any key to continue...");
                        Console.ReadKey();
                        break;
                }
            }

            Console.Clear();
            Console.WriteLine("Goodbye!");
            Thread.Sleep(2000);

        }

        public void CreateCustomer()
        {
            Console.WriteLine("\nPlease enter the first name of the customer:");
            string firstName = Console.ReadLine();
            Console.WriteLine("\nPlease enter the last name of the customer:");
            string lastName = Console.ReadLine();
            CustomerType customerType = GetCustomerType();

            customerRepository.AddCustomer(new Customer(firstName, lastName, customerType));
            Console.WriteLine("\nCustomer created.");
        }


        public CustomerType GetCustomerType()
        {
            while (true)
            {
                Console.WriteLine("\nPlease enter a customer type: 1. Current  2. Past  3. Potential");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        return CustomerType.Current;
                    case "2":
                        return CustomerType.Past;
                    case "3":
                        return CustomerType.Potential;
                    default:
                        Console.WriteLine("\nPlease enter a valid input.");
                        break;
                }
            }
        }

        public void DeleteCustomer()
        {
            Console.WriteLine("\nEnter customer's full name that should be deleted");
            string fullName = Console.ReadLine();
            customerRepository.DeleteCustomer(fullName);
        }

        public void UpdateCustomer()
        {
            Customer customer = null;
            while (customer == null)
            {
                Console.WriteLine("\nPlease enter a customers full name");
                string input = Console.ReadLine().ToLower();
                customer = customerRepository.GetCustomerByFullName(input);
            }
            string firstName = GetFirstName();
            string lastName = GetLastName();
            CustomerType customerType = GetCustomerType();
            Customer newCustomer = new Customer(firstName, lastName, customerType);
            customerRepository.UpdateCustomer(newCustomer, customer.FullName);
        }


        public string GetFirstName()
        {
            while (true)
            {
                Console.WriteLine("\nWould you like to update the first name? y/n");
                string input = Console.ReadLine().ToLower();
                if (input == "y")
                {
                    Console.WriteLine("\nEnter new first name:");
                    return Console.ReadLine();

                }
                else if (input == "n")
                {
                    return null;
                }
                else
                {
                    Console.WriteLine("\nEnter a valid input please");
                }
            }
        }
        public string GetLastName()
        {
            while (true)
            {
                Console.WriteLine("\nWould you like to update the last name? y/n");
                string input = Console.ReadLine().ToLower();
                if (input == "y")
                {
                    Console.WriteLine("\nEnter new last name:");
                   return Console.ReadLine();

                }
                else if (input == "n")
                {
                    return null;
                }
                else
                {
                    Console.WriteLine("\nEnter a valid input please");
                }
            }
        }
    }
}

