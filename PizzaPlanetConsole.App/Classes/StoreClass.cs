using PizzaPlanetConsole.DataAccess.DataModels;
using System;
using System.Linq;

namespace PizzaPlanetConsole.App.Classes
{
    public class StoreClass
    {
        private static readonly ShoelessJoeContext ctx = new ShoelessJoeContext();

        public static Store PickAStore(Users user)
        {
            Console.WriteLine($"Welcome baack, {user.FirstName}!");

            var stores = ctx.Store
                .ToList();

            foreach (var item in stores)
            {
                Console.WriteLine($"{item.StoreId}. {item.Street} {item.City} {item.State}, {item.ZipCode}");
            }
            GeneralClass.WriteExit();

            int userInput = GeneralClass.UserPicks();

            GeneralClass.Exit(userInput);

            var store = ctx.Store
                .FirstOrDefault(s => s.StoreId == userInput);

            return store;
        }

        public static void AddStore(Users user)
        {
            try
            {
                while (true)
                {
                    var newStore = new Store();

                    Console.Write("Enter street: ");
                    newStore.Street = Console.ReadLine();
                    Console.WriteLine();

                    Console.Write("Enter city: ");
                    newStore.City = Console.ReadLine();
                    Console.WriteLine();

                    Console.Write("Enter state: ");
                    newStore.State = Console.ReadLine();
                    Console.WriteLine();

                    Console.Write("Enter zip code: ");
                    newStore.ZipCode = int.Parse(Console.ReadLine());
                    Console.WriteLine();

                    Console.Write("Enter phone number: ");
                    newStore.Phone = Console.ReadLine();

                    ctx.Store.Add(newStore);
                    ctx.SaveChanges();
                    Console.WriteLine("Store added!");

                    Console.Write("Add another one? (y/n)");
                    string again = Console.ReadLine();

                    if (again == "n")
                        break;
                }

                Navigation.PlaceOrder(user);
            }
            catch (Exception)
            {
                Console.WriteLine("Something went wrong.");
                GeneralClass.PressEnter();
                Navigation.PlaceOrder(user);
            }
        }
    }
}
