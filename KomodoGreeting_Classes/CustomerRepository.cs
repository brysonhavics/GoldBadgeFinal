using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoGreeting_Classes
{
    public class CustomerRepository
    {
        private readonly List<Customer> _customers = new List<Customer>();


        //CRUD

        //Create
        public void AddCustomer(Customer customer)
        {
            _customers.Add(customer);
        }
        //Read
        public void DisplayCustomers()
        {
            List<Customer> sortedList = _customers.OrderBy(x => x.LastName).ToList();
            Console.WriteLine("Name        Customer Type        Email");
            foreach (Customer customer in sortedList)
            {
                Console.WriteLine($"\n{customer.FullName}     {customer.TypeOfCustomer}     {customer.GetEmailType()}");
            }
        }

        public void ShowCustomer(Customer customer)
        {
            Console.WriteLine($"\n{customer.FullName}     {customer.TypeOfCustomer}     {customer.GetEmailType()}");
        }

        public Customer GetCustomerByFullName(string fullName)
        {
            string fN = fullName.ToLower();
            foreach (Customer customer in _customers)
            {
                string customerFN = customer.FullName.ToLower();
                if (customerFN == fullName)
                {
                    return customer;
                }
            }
            return null;
        }

        //Update

        public void UpdateCustomer(Customer customer, string fullName)
        {
            string fN = fullName.ToLower();
            Customer oldCustomer = GetCustomerByFullName(fN);
            if (oldCustomer.FirstName != null)
            {
                oldCustomer.FirstName = customer.FirstName;
            }
            if (oldCustomer.LastName != null)
            {
                oldCustomer.LastName = customer.LastName;
            }
            oldCustomer.TypeOfCustomer = customer.TypeOfCustomer;
            Console.WriteLine("\nChanges may have been made, check menu to see");
        }


        //Delete
        public void DeleteCustomer(string fullName)
        {
            string fN = fullName.ToLower();
            Customer customer = GetCustomerByFullName(fN);
            if (customer != null)
            {
                _customers.Remove(customer);
                Console.WriteLine("\nCustomer deleted successfully");
            }
            else
                Console.WriteLine("\nFailed to delete customer. Enter valid name");
        }
    }
}
