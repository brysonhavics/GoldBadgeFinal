using KomodoClaims_Classes;
using KomodoClaims_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KomodoClaimsConsole
{
    public class ProgramUI
    {
        private ClaimRepo _repo = new ClaimRepo();

        public void Run()
        {
            SeedContent();

            Menu();
        }

        public void SeedContent()
        {
            Claims claim = new Claims(1, ClaimType.Car, "Test test test", 450.23, new DateTime(2012, 5, 17), new DateTime(2012, 5, 10));
            Claims claim2 = new Claims(2, ClaimType.Home, "Test2 Test2 Test2", 486.23, new DateTime(2012, 5, 17), new DateTime(2016, 5, 10));

            _repo.AddClaimToRepo(claim);
            _repo.AddClaimToRepo(claim2);

        }

        public void Menu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();

                Console.WriteLine("Menu:\n" +
                    "1. Show all claims\n" +
                    "2. Handle claim\n" +
                    "3. Create claim\n" +
                    "4. Exit");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        //display Claims
                        _repo.ShowClaims();
                        Console.ReadKey();
                        break;
                    case "2":
                        //remove claim from stack
                        DealWithClaim();
                        break;
                    case "3":
                        CreateClaim();
                        Console.WriteLine("\nClaim has been created, press any key to continue");
                        Console.ReadKey();
                        break;
                    case "exit":
                    case "EXIT":
                    case "4":
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

        public void DealWithClaim()
        {
            _repo.GetNextClaim();
            bool run = true;
            while (run)
            {
                Console.WriteLine("\nWould you like to deal with this claim now? y/n");
                string choice = Console.ReadLine();
                if (choice == "y")
                {
                    _repo.HandleClaim();
                    Console.WriteLine("\nClaim dealt with.");
                    run = false;
                }
                else if (choice == "n")
                {
                    run = false;
                }
                else
                    Console.WriteLine("\nPlease enter a valid option");
            }
        }

        public void CreateClaim()
        {
            int id = GetID();
            string desc = GetDescription();
            ClaimType claimType = GetClaimType();
            double amount = GetClaimAmount();
            Console.WriteLine("Date of incident\n");
            DateTime dateOfIncident = GetDate();
            Console.WriteLine("Date of claim\n");
            DateTime dateOfClaim = GetDate();

            Claims claim = new Claims(id, claimType, desc, amount, dateOfIncident, dateOfClaim);
            _repo.AddClaimToRepo(claim);
        }

        public int GetID()
        {
            Console.WriteLine("\nPlease enter an id: ");
            int id = Convert.ToInt32(Console.ReadLine());
            return id;
        }
        public string GetDescription()
        {
            Console.WriteLine("\nPlease enter a description: ");
            string desc = Console.ReadLine();
            return desc;
        }

        public double GetClaimAmount()
        {
            Console.WriteLine("\nPlease enter a claim amount: ");
            double amount = Convert.ToDouble(Console.ReadLine());
            return amount;
        }

        public ClaimType GetClaimType()
        {
            bool run = true;
            while (run)
            {
                Console.WriteLine("\nEnter a number: 1=Car\n2=Home\n3=Theft\n4=Medical");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        return ClaimType.Car;
                    case "2":
                        return ClaimType.Home;
                    case "3":
                        return ClaimType.Theft;
                    case "4":
                        return ClaimType.Medical;
                    default:
                        Console.WriteLine("\nPlease enter a valid selection");
                        break;
                }
            }
            return ClaimType.Car;
        }

        public DateTime GetDate()
        {
            Console.WriteLine("\nPlease enter a date in the format: 05/25/2005");
            string date = Console.ReadLine();
            DateTime dateTime1 = new DateTime();
            dateTime1 = Convert.ToDateTime(date);
            return dateTime1;
        }
    }

}

