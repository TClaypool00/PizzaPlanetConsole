using PizzaPlanetConsole.DataAccess.DataModels;
using System;

namespace PizzaPlanetConsole.App.Classes
{
    public class Navigation
    {
        public static void MainMenu(Users user)
        {
            string[] options = { "Place Order", "Add Store", "Add Food", "My Orders" };

            Console.WriteLine($"Welcome, {user.FirstName}!");
            Console.WriteLine();

            Display.DisplayOptions(options);
            MenuOptions(user);
        }

        public static void MenuOptions(Users user)
        {
            try
            {
                int userInput = GeneralClass.UserPicks();

                switch (userInput)
                {
                    case 1:
                        PlaceOrder(user);
                        break;
                    case 2:
                        StoreClass.AddStore(user);
                        break;
                    case 3:
                        FoodClass.AddFood(user);
                        break;
                    case 4:
                        int orderId = Display.DisplayList(user);
                        OrderClass.OrderDetails(orderId, user);
                        break;
                    case 0:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Not an option. Try again");
                        MenuOptions(user);
                        break;
                }
                GeneralClass.PressEnter();
                MainMenu(user);
            }
            catch (FormatException)
            {
                Console.WriteLine("You must enter a number.");
                MenuOptions(user);
            }
        }

        public static void PlaceOrder(Users user)
        {
            var store = StoreClass.PickAStore(user);
            FoodClass.Order(store, user);
        }

        

        public static void BackToMainMenu(int input, Users user)
        {
            if (input == 999)
                MainMenu(user);
        }

        public static void WriteBackMainMenu()
        {
            Console.WriteLine("Type '999' to go back to the main menu");
        }
    }
}
