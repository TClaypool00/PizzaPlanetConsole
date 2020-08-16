using PizzaPlanetConsole.DataAccess.DataModels;
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

        public static void Exit(int input)
        {
            if (input == 0)
                Environment.Exit(0);
        }

        public static void WriteExit()
        {
            Console.WriteLine("0. Exit");
        }
    }
}
