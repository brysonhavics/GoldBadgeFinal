using KomodoGreeting_Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace KomodoGreeting_Tests
{
    [TestClass]
    public class GreetingsTest
    {
        [TestMethod]
        public void TestRepo()
        {
            CustomerRepository customerRepository = new CustomerRepository();

            Customer customer1 = new Customer("Mitchell", "Price", CustomerType.Current);
            Customer customer2 = new Customer("Bryson", "Havics", CustomerType.Past);
            Customer customer3 = new Customer("Ezra", "Davis", CustomerType.Potential);

            customerRepository.AddCustomer(customer1);
            customerRepository.AddCustomer(customer2);
            customerRepository.AddCustomer(customer3);

            //Shows whole repo
            customerRepository.DisplayCustomers();

            //shows one customer
            customerRepository.ShowCustomer(customer2);

            //deletes one customer by full name
            customerRepository.DeleteCustomer(customer3.FullName);

            customerRepository.DisplayCustomers();

            //updates customer by taking in a new customer and comparing it to the old one found by fullname
            customerRepository.UpdateCustomer(customer1, customer2.FullName);

            customerRepository.DisplayCustomers();
        }
    }
}
