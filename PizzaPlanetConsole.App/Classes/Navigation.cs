using PizzaPlanetConsole2.DataAccess.DataModels;
using System;

namespace PizzaPlanetConsole.App.Classes
{
    public class Navigation
    {
        public static void MainMenu(Users user)
        {
            var store = StoreClass.PickAStore(user);
            FoodClass.Order(store, user);
        }

        public static void Exit(int input)
        {
            if (input == 0)
                Environment.Exit(0);
        }
    }
}
