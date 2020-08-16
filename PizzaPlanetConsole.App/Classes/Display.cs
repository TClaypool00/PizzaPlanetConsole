using PizzaPlanetConsole.DataAccess.DataModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaPlanetConsole.App.Classes
{
    public class Display
    {
        public static void DisplayOptions(string[] options)
        {
            for (int i = 1; i <= options.Length; i++)
            {
                Console.WriteLine($"{i}. {options[i - 1]}");
            }
            GeneralClass.WriteExit();
        }

        public static int DisplayList(List<Foods> list)
        {
            try
            {
                foreach (var item in list)
                {
                    Console.WriteLine($"{item.FoodId}. {item.FoodTitle} {item.FoodGroup.FoodGroups} {item.Price:C2}");
                }

                int input = GeneralClass.UserPicks();

                return input;
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Not an option. Try again.");
                GeneralClass.PressEnter();
                return DisplayList(list);
            }
        }

        public static int DisplayList(Users user)
        {
            var orders = OrderClass.MyOrders(user);

            foreach (var item in orders)
            {
                Console.WriteLine($"{item.OrderId}. Total Price: {item.TotaLprice:C2}, \n Total No. of items: {item.TotalQuantity} \n Date: {item.Cart.TimeStamp}");
                Console.WriteLine();
            }

            int input = GeneralClass.UserPicks();

            return input;
        }

        public static void DisplayList(List<FoodGroup> groups)
        {
            foreach (var item in groups)
            {
                Console.WriteLine($"{item.FoodGroupId}. {item.FoodGroups}");
            }
        }
    }
}
