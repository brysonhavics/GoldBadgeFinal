using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoGreeting_Classes
{
    public enum CustomerType { Current = 0, Potential, Past }
    public class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get
            {
                return FirstName + " " + LastName;
            }
            set { }
        }
        public CustomerType TypeOfCustomer { get; set; }

        public Customer(string fname, string lname, CustomerType customerType)
        {
            FirstName = fname;
            LastName = lname;
            TypeOfCustomer = customerType;
        }

        public string GetEmailType()
        {
            switch (TypeOfCustomer)
            {
                case CustomerType.Current:
                    return "Thank you for your work with us. We appreciate your loyalty. Here's a coupon.";
                case CustomerType.Past:
                    return "It's been a long time since we've heard from you, we want you back";
                case CustomerType.Potential:
                    return "We currently have the lowest rates on Helicopter Insurance!";
                default:
                    return "Who are you?";
            }

        }
    }
}
