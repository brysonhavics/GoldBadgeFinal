using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoCafe_Repository
{
    public class Menu
    {
        public int MealNumber { get; set; }
        public string Name { get; set; }
        public string MealDescription { get; set; }
        public List<string> Ingredients { get; set; }
        public double Price { get; set; }


        public Menu() { }
        public Menu(int mealNumber, string name, string mealDescription, List<string> ingredients, double price)
        {
            MealNumber = mealNumber;
            Name = name;
            MealDescription = mealDescription;
            Ingredients = ingredients;
            Price = price;
        }
    }
}
