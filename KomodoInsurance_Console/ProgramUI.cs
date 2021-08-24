using KomodoInsurance_Repository;
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

        public Dictionary<int, List<string>> badgeKeys = new Dictionary<int, List<string>>
        {
            {0, new List<string>(){" "} },
            {1,  new List<string>(){"A1", } },
            {2,  new List<string>(){"A1","A2"} },
            {3,  new List<string>(){"A1", "A2", "A3"} },
            {4,  new List<string>(){"A1", "A2" ,"A3", "A4"} },
            {5,  new List<string>(){"A1", "A2", "A3", "A4", "A5"} },
        };

        private readonly BadgeRepository badgeRepository = new BadgeRepository();
        public void Run()
        {
            SeedContent();

            Menu();
        }

        public void SeedContent()
        {
            Badge badge1 = new Badge(1, 1);
            Badge badge2 = new Badge(2, 3);
            Badge badge3 = new Badge(3, 5);

            badgeRepository.AddBadge(badge1);
            badgeRepository.AddBadge(badge2);
            badgeRepository.AddBadge(badge3);
        }

        public void Menu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();

                Console.WriteLine("Menu:\n" +
                    "1. Show all badges\n" +
                    "2. Update badge\n" +
                    "3. Create badge\n" +
                    "4. Exit");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        badgeRepository.DisplayBadges();
                        Console.ReadKey();
                        break;
                    case "2":
                        UpdateBadgeAccess();
                        Console.ReadKey();
                        break;
                    case "3":
                        CreateBadge();
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

        public void CreateBadge()
        {
            Console.WriteLine("\nPlease enter a badge ID:");
            int id = Convert.ToInt32(Console.ReadLine());
            bool run = true;
            List<string> accessList = new List<string>(); 
            while (run)
            {
                Console.WriteLine("\nWould you like a preset access list or a custom one: p/c");
                string choice = Console.ReadLine();
                if (choice == "c")
                {
                    accessList = CustomBadge();
                    run = false;
                }
                else if (choice == "p")
                {
                    accessList = PresetBadge();
                    run = false;
                }
                else
                    Console.WriteLine("\nPlease enter a valid option");
            }
            Badge badge = new Badge(id, accessList);
            badgeRepository.AddBadge(badge);
            Console.WriteLine("\nYour badge was added, press any key to continue");
            Console.ReadKey();
        }

        public List<string> CustomBadge()
        {
            List<string> accessList = new List<string>();
            while (true)
            {
                Console.WriteLine("\nPlease input a door this badge should have access to:");
                string accessDoor = Console.ReadLine();
                accessList.Add(accessDoor);
                Console.WriteLine("\nWould you like to add another door? y/n");
                string choice = Console.ReadLine();
                while (choice != "y")
                {
                    if (choice == "n")
                    {
                        return accessList;
                    }
                    else
                    {
                        Console.WriteLine("\nPlease enter a valid input");
                        choice = Console.ReadLine();
                    }
                }
            }
        }

        public List<string> PresetBadge()
        {
            List<string> accessList = new List<string>();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Key    Doors Accessible");
                List<List<string>> list = badgeKeys.Values.ToList();
                int i = 0;
                foreach (List<string> item in list)
                {
                    Console.WriteLine(string.Join(",",item));
                    string l = "";
                    foreach (string s in item)
                    {
                        l += s + ",";
                    }
                    Console.WriteLine($"\n{i}             {l}");
                    i++;
                }
                // var lines = badgeKeys.Select(kvp => kvp.Key + ": ");
                //Console.WriteLine(string.Join(Environment.NewLine, lines) ) ;
                Console.WriteLine("\nPlease select one of the presets:");
                int choice = Convert.ToInt32(Console.ReadLine());
                if (choice < 6 && choice > -1)
                {
                    accessList = badgeKeys[choice];
                    return accessList;
                }
                else
                {
                    Console.WriteLine("\nPlease enter a valid input:");
                }
            }
        }

        public void UpdateBadgeAccess()
        {
            Console.WriteLine("\nWhat badge would you like to update?");
            int id = Convert.ToInt32(Console.ReadLine());
            bool run = true;
            while (run)
            {
                Console.WriteLine("\nWould you like to add or remove a door?\n1. Add\n2. Remove");
                string choice = Console.ReadLine();
                if (choice == "1")
                {
                    badgeRepository.DisplayBadgeDoors(id);
                    Console.WriteLine("\nEnter door to add access to:");
                    string door = Console.ReadLine();
                    badgeRepository.AddDoorBadge(id, door);
                    run = false;
                }
                else if (choice == "2")
                {
                    badgeRepository.DisplayBadgeDoors(id);
                    Console.WriteLine("\nEnter door to remove access to:");
                    string door = Console.ReadLine();
                    badgeRepository.RemoveDoorBadge(id, door);
                    run = false;
                }
                else
                    Console.WriteLine("\nPlease enter a valid input.");
            }
        }
    }
}
