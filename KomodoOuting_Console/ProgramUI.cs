using KomodoOutings_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KomodoOuting_Console
{
    public class ProgramUI
    {
        private OutingsRepository _outingRepository = new OutingsRepository();


        public void Run()
        {
            SeedContent();

            Menu();
        }

        public void SeedContent()
        {
            Outing outing1 = new Outing(OutingType.Golf, 100, new DateTime(01 / 01 / 2001), 1500.13);
            Outing outing2 = new Outing(OutingType.Bowling, 100, new DateTime(01 / 01 / 2002), 120.32);
            Outing outing3 = new Outing(OutingType.AmusementPark, 100, new DateTime(01 / 01 / 2003), 600.12);
            Outing outing4 = new Outing(OutingType.Concert, 100, new DateTime(01 / 01 / 2004), 400.53);

            _outingRepository.AddOuting(outing1);
            _outingRepository.AddOuting(outing2);
            _outingRepository.AddOuting(outing3);
            _outingRepository.AddOuting(outing4);
        }

        public void Menu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();

                Console.WriteLine("Menu:\n" +
                    "1. Show all outings\n" +
                    "2. Show total outing costs\n" +
                    "3. Create outing\n" +
                    "4. Exit");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        //display outings
                        _outingRepository.DisplayOutings();
                        break;
                    case "2":
                        //Displays specific costs
                        _outingRepository.ShowOutingsCosts();
                        break;
                    case "3":
                        AddOuting();
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

        public DateTime GetDate()
        {
            Console.WriteLine("\nPlease enter a date in the format: 05/25/2005");
            string date = Console.ReadLine();
            DateTime dateTime = new DateTime();
            dateTime = Convert.ToDateTime(date);
            return dateTime;
        }

        public OutingType GetOutingType()
        {
            bool run = true;
            while (run)
            {
                Console.WriteLine("\nEnter a number: 1=Golf\n2=Bowling\n3=Amusement park\n4=Concert");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        return OutingType.Golf;
                    case "2":
                        return OutingType.Bowling; ;
                    case "3":
                        return OutingType.AmusementPark; ;
                    case "4":
                        return OutingType.Concert;
                    default:
                        Console.WriteLine("\nPlease enter a valid selection");
                        break;
                }
            }
            return OutingType.Outing;
        }

        public int GetAttendence()
        {
            Console.WriteLine("\nPlease enter how many people were in attendence: ");
            return Convert.ToInt32(Console.ReadLine());
        }

        public double GetTotalCost()
        {
            Console.WriteLine("\nPlease enter the total cost: ");
            return Convert.ToDouble(Console.ReadLine());
        }

        public void AddOuting()
        {
            OutingType type = GetOutingType();
            int attendence = GetAttendence();
            DateTime date = GetDate();
            double cost = GetTotalCost();
            Outing outing = new Outing(type, attendence, date, cost);
            Console.WriteLine("\nOuting was created, press any key to continue");
            Console.ReadKey();
            _outingRepository.AddOuting(outing);
            Console.WriteLine("\nOuting was added to database, press any key to continue");
            Console.ReadKey();
        }
    }
}
