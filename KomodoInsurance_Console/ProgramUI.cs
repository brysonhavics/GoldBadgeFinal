using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KomodoInsurance_Console
{
    public class ProgramUI
    {
        public void Run()
        {
            SeedContent();

            Menu();
        }

        public void SeedContent()
        {


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
                        Console.ReadKey();
                        break;
                    case "2":

                        break;
                    case "3":

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
    }
}
