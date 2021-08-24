using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsurance_Repository
{
    public class Badge
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

        public int BadgeID { get; set; }
        public int BadgeKey { get; set; } 
        public List<string> AccessibleDoors { get; set; } 

        public Badge(int id, List<string> accessibleDoors)
        {
            BadgeID = id;
            AccessibleDoors = accessibleDoors;
            BadgeKey = 0;
        }

        public Badge(int id, int badgeKeyRef)
        {
            BadgeID = id;
            BadgeKey = badgeKeyRef;
            AccessibleDoors = badgeKeys[badgeKeyRef];
        }
    }
}
