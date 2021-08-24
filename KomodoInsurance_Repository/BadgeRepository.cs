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
            foreach (Badge badge in _badges)
            {
                Console.WriteLine($"\n{badge.BadgeID}");
                foreach (string item in badge.AccessibleDoors)
                {
                    Console.WriteLine($"{item}  ");
                }
            }
        }

        //Update
    }
}
