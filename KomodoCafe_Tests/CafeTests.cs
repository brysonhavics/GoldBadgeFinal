using KomodoCafe_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace KomodoCafe_Tests
{
    [TestClass]
    public class KomodoCafe_Test
    {
        [TestMethod]
        public void Test()
        {
            MenuRepository _menu = new MenuRepository();

            Menu m1 = new Menu(1, "Burger", "A juicy burger baby!", new List<string> { "Bun", "Patty", "Sauce" }, 8.99);
            _menu.AddItemToMenu(m1);
            Console.WriteLine((_menu.GetMenuByName("Burger")).MealDescription);
        }
    }
}
