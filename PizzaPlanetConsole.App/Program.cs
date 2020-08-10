using PizzaPlanetConsole.App.Classes;
using PizzaPlanetConsole2.DataAccess.DataModels;
using System;

namespace PizzaPlanetConsole.App
{
    class Program
    {
        static void Main()
        {
            var user = Start();
            Navigation.MainMenu(user);
        }

        public static Users Start()
        {
            Console.WriteLine("Welcome to the Pizza Planet Console Application!");
            Console.Write("Have you been here before(y/n):");

            return AccountClass.RegisterOrLogin();
        }
    }
}
