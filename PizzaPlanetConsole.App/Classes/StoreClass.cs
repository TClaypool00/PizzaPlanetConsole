using PizzaPlanetConsole2.DataAccess.DataModels;
using System;
using System.Linq;

namespace PizzaPlanetConsole.App.Classes
{
    public class StoreClass
    {
        private static readonly ShoelessJoeContext ctx = new ShoelessJoeContext();

        public static Stores PickAStore(Users user)
        {
            Console.WriteLine($"Welcome baack, {user.FirstName}!");

            var stores = ctx.Stores
                .ToList();

            foreach (var item in stores)
            {
                Console.WriteLine($"{item.StoreId}. {item.Street} {item.City} {item.State}, {item.ZipCode}");
            }

            try
            {
                Console.Write("Pick a store: ");
                int userInput = int.Parse(Console.ReadLine());
                var store = ctx.Stores.FirstOrDefault(s => s.StoreId == userInput);

                return store;
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid pick. Try again");
                return PickAStore(user);
            }
        }
    }
}
