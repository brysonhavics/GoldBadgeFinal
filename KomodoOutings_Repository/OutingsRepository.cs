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
                Console.WriteLine("\nOuting as been added");
            }
            else
                Console.WriteLine("\nError: Could not add outing");
        }
        public void ShowOutings()
        {
            double golf = 0;
            double bowling = 0;
            double anmusementPark = 0;
            double concert = 0;
            double total = 0;
            foreach (Outing outing in _outingsRepo)
            {
                Console.WriteLine($"\n");
            }
        }
    }
}
