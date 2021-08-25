using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoOutings_Repository
{
    public enum OutingType { Golf = 0, Bowling, AmusementPark, Concert, Outing }
    public class Outing
    {
        public OutingType TypeOfOuting { get; set; }
        public int Attendence { get; set; }
        public DateTime Date { get; set; }
        public double TotalCost { get; set; }
        public double CostPerPerson { get; set; }

        public Outing() { }
        public Outing(OutingType type, int attendence, DateTime date, double totalCost)
        {
            TypeOfOuting = type;
            Attendence = attendence;
            Date = date;
            TotalCost = totalCost;
            CostPerPerson = totalCost / attendence;
        }
    }
}
