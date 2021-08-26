using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsurance_Repository
{
    public class BadgeRepository
    {
        private readonly List<Badge> _badges = new List<Badge>();

        //CRUD

        //Create

        public void AddBadge(Badge badge)
        {
            _badges.Add(badge);
        }

        //Read
        public void DisplayBadges()
        {
            Console.WriteLine("BadgeID        Accessible Doors");
            foreach (Badge badge in _badges)
            {
                Console.WriteLine($"\n{badge.BadgeID}              {string.Join(",", badge.AccessibleDoors)}");
            }
        }

        public void DisplayBadgeDoors(int id)
        {
            Badge badge = GetBadgeByID(id);
            Console.WriteLine($"\n{badge.BadgeID}              {string.Join(",", badge.AccessibleDoors)}");
        }

        private Badge GetBadgeByID(int id)
        {
            foreach (Badge badge in _badges)
            {
                if (badge.BadgeID == id)
                {
                    return badge;
                }
            }
            return null;
        }

        //Update

        public void AddDoorBadge(int id, string doorChange)
        {
            Badge badge = GetBadgeByID(id);

            if (badge != null)
            {
                badge.AccessibleDoors.Add(doorChange);
                Console.WriteLine("\nBadge was updated successfully");
            }
            else
            {
                Console.WriteLine("\nCould not update badge");
                Console.ReadKey();
            }



        }

        //Delete
        public void RemoveDoorBadge(int id, string doorChange)
        {
            Badge badge = GetBadgeByID(id);

            if (badge != null)
            {
                badge.AccessibleDoors.Remove(doorChange);
                Console.WriteLine("\nBadge was updated successfully");
            }
            else
            {
                Console.WriteLine("\nCould not update badge");
                Console.ReadKey();
            }
        }
    }
}
