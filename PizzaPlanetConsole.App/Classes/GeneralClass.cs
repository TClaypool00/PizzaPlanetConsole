using PizzaPlanetConsole2.DataAccess.DataModels;
using System;
using System.Collections.Generic;

namespace PizzaPlanetConsole.App.Classes
{
    public class GeneralClass
    {
        public static int UserPicks()
        {
            Console.Write("Enter a number: ");
            int userInput = int.Parse(Console.ReadLine());

            return userInput;
        }

        public static void PressEnter()
        {
            Console.Write("Press Enter to contenue...");
            Console.ReadLine();
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

        public static string ListToString(List<int> list)
        {
            return string.Join(" ", list);
        }
    }
}
