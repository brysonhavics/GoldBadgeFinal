using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoOutings_Repository
{
    public class OutingsRepository
    {
        private readonly List<Outing> _outingsRepo = new List<Outing>();

        public void AddOuting(Outing outing)
        {
            if (outing != null)
            {
                _outingsRepo.Add(outing);
                //Console.WriteLine("\nOuting as been added");
            }
            else
                Console.WriteLine("\nError: Could not add outing");
        }
        public void ShowOutingsCosts()
        {
            double golf = 0;
            double bowling = 0;
            double amusementPark = 0;
            double concert = 0;
            double total = 0;
            foreach (Outing outing in _outingsRepo)
            {
                total += outing.TotalCost;
                switch (outing.TypeOfOuting)
                {
                    case OutingType.Golf:
                        golf += outing.TotalCost;
                        break;
                    case OutingType.Bowling:
                        bowling += outing.TotalCost;
                        break;
                    case OutingType.AmusementPark:
                        amusementPark += outing.TotalCost;
                        break;
                    case OutingType.Concert:
                        concert += outing.TotalCost;
                        break;
                    default:
                        break;
                }
            }
            Console.WriteLine($"\nGolf: ${golf}\nBowling: ${bowling}\nAmusement Park: ${amusementPark}\nConcert: ${concert}\nTotal costs: ${total}");
            //Console.ReadKey();
        }

        public void DisplayOutings()
        {
            foreach (Outing outing in _outingsRepo)
            {
                Console.WriteLine($"\nOuting type: {outing.TypeOfOuting}  Attendence: {outing.Attendence}  Date: {outing.Date}  Total cost: {outing.TotalCost}  Cost per person: {outing.CostPerPerson}");
            }
            //Console.ReadKey();
        }
    }
}
