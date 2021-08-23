using System;
using System.Collections.Generic;

namespace KomodoCafe_Repository
{
    public class MenuRepository
    {
        private readonly List<Menu> _menuDirectory = new List<Menu>();

        public MenuRepository() { }

        //CRUD

        //Create

        public bool AddItemToMenu(Menu item)
        {
            int startingCount = _menuDirectory.Count;

            _menuDirectory.Add(item);

            bool wasAdded = _menuDirectory.Count > startingCount;
            return wasAdded;
        }

        //Read
        public List<Menu> ReturnMenus()
        {
            return _menuDirectory;
        }

        public void ShowMenus()
        {
            foreach (Menu item in _menuDirectory)
            {
                Console.WriteLine($"\nNumber: {item.MealNumber}\nName: {item.Name}\nDescription: {item.MealDescription}\nIngredients:{string.Join(", ", item.Ingredients)}\nPrice: {item.Price}");
            }
            Console.ReadKey();
        }

        public Menu GetMenuByName(string menuName)
        {
            foreach (Menu item in _menuDirectory)
            {
                if (item.Name == menuName)
                {
                    return item;
                }
            }
            return null;
        }

        //Update

        public bool UpdateExistingMenu(string menuName, Menu menu)
        {
            Menu oldContent = GetMenuByName(menuName);

            if (oldContent != null)
            {
                oldContent.MealNumber = menu.MealNumber;
                oldContent.Name = menu.Name;
                oldContent.MealDescription = menu.MealDescription;
                oldContent.Ingredients = menu.Ingredients;
                oldContent.Price = menu.Price;

                return true;
            }

            return false;
        }

        //Delete

        public bool DeleteMenuItem(string name)
        {
            Menu menu = GetMenuByName(name);
            if (menu != null)
            {
                _menuDirectory.Remove(menu);
                return true;
            }
            return false;
        }


    }
}