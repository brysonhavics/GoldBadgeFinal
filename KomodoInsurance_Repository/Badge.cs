using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsurance_Repository
{
    public class Badge
    {
        Dictionary<int, string[]> badgeKeys = new Dictionary<int, string[]>
        {
            {1, new string[]{"A1", "A2", "A3", "A4", "A5"} },
            {2, new string[]{"A1", "A2", "A3", "A4"} },
            {3, new string[]{"A1", "A2", "A3"} },
            {4, new string[]{"A1", "A2"} },
            {5, new string[]{"A1"} },
        };

        public int BadgeID { get; set; }
        public List<string> AccessibleDoors { get; set; }
    }
}
